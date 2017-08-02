using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CSharpWebApp2.Models
{
    public class CalculateIDFT
    {
        public double[] Calculate(string parameters)
        {
            String[] parametersSplit = parameters.Split(';');

            String[] cosCoefficientsSplit = parametersSplit[0].Split(null);
            double[] cosCoefficients = new double[cosCoefficientsSplit.Length];
            for(int i = 0; i<cosCoefficientsSplit.Length; i++)
            {
                cosCoefficients[i] = double.Parse(cosCoefficientsSplit[i], CultureInfo.InvariantCulture);
            }

            String[] sinCoefficientsSplit = parametersSplit[1].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            double[] sinCoefficients = new double[cosCoefficientsSplit.Length];
            for (int i = 0; i < sinCoefficientsSplit.Length; i++)
            {
                sinCoefficientsSplit[i] = sinCoefficientsSplit[i].Trim();
            }

            for (int i = 0; i < sinCoefficientsSplit.Length; i++)
            {
               sinCoefficients[i] = double.Parse(sinCoefficientsSplit[i], CultureInfo.InvariantCulture);
            }

            return IDFT(cosCoefficients, sinCoefficients);
        }

        private double[] IDFT(double[] cosCoefficients, double[] sinCoefficients)
        {
            if (cosCoefficients.Length != sinCoefficients.Length) throw new ArgumentException("cos.Length and sin.Length must match!");

            var coefficientsQuantity = (cosCoefficients.Length - 1) * 2;
            double[] timeDomainSignal = new double[coefficientsQuantity];
            int partials = sinCoefficients.Length;

            if (partials > coefficientsQuantity / 2)
                partials = coefficientsQuantity / 2;

            for (int probeNumber = 0; probeNumber <= partials; probeNumber++)
            {
                for (int i = 0; i < coefficientsQuantity; i++)
                {
                    timeDomainSignal[i] += Math.Cos(2 * Math.PI * probeNumber / coefficientsQuantity * i) * cosCoefficients[probeNumber];
                    timeDomainSignal[i] += Math.Sin(2 * Math.PI * probeNumber / coefficientsQuantity * i) * sinCoefficients[probeNumber];
                }
            }

            return timeDomainSignal;
        }
    }
}