using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpWebApp2.Models
{
    public class CalculateDFT
    {
        public Tuple<double[], double[]> Calculate(string coefficients)
        {
            String[] coefficientsSplit = coefficients.Split(null);
            List<double> coefficientsDoubles = new List<double>();
            foreach(string coefficient in coefficientsSplit)
            {
               double coefficientDouble = Convert.ToDouble(coefficient);
               coefficientsDoubles.Add(coefficientDouble);
            }
    
            return DFT(coefficientsDoubles);
        }

        private Tuple<double[], double[]> DFT(List<double> inputSignal)
        {
            double[] cosDFTcoefficients = new double[inputSignal.Count / 2 + 1];
            double[] sinDFTcoefficients = new double[inputSignal.Count / 2 + 1];
            double normalizer = 1.0 / inputSignal.Count * 2;
            var partials = inputSignal.Count / 2;

            for (int probeNumber = 0; probeNumber <= partials; probeNumber++)
            {
                double cos = 0.0;
                double sin = 0.0;

                for (int i = 0; i < inputSignal.Count; i++)
                {
                    cos += inputSignal[i] * Math.Cos(2 * Math.PI * probeNumber / inputSignal.Count * i);
                    sin += inputSignal[i] * Math.Sin(2 * Math.PI * probeNumber / inputSignal.Count * i);
                }

                cosDFTcoefficients[probeNumber] = cos * normalizer;
                sinDFTcoefficients[probeNumber] = sin * normalizer;
            }
            return new Tuple<double[], double[]>(cosDFTcoefficients, sinDFTcoefficients);
        }
    }
}