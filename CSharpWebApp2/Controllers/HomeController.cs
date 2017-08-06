using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CSharpWebApp2.Models;
using Microsoft.Owin.Security;

namespace CSharpWebApp2.Controllers
{
    [System.Web.Mvc.Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calculators()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult RandomPasswordGenerator()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        // HOME/CONVERTERS
        public ActionResult Converters()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult DFT()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Parameters(int numberOfParameters)
        {
            ViewBag.Parameters = numberOfParameters;
            return View("DFT");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CalculateDFT(string parametersDFT)
        {
            Tuple<double[], double[]> resultDFT = new CalculateDFT().Calculate(parametersDFT);
            string resultSin = null;
            string resultCos = null;
            foreach (var sin in resultDFT.Item2)
            {
                resultSin += " " + sin;
            }
            foreach (var cos in resultDFT.Item1)
            {
                resultCos += " " + cos;
            }

            ViewBag.resultSin = resultSin;
            ViewBag.resultCos = resultCos;
            return View("DFT");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CalculateIDFT(string parametersIDFT)
        {
            double[] resultIDFT = new CalculateIDFT().Calculate(parametersIDFT);
            string result = null;
            foreach (var signalParameter in resultIDFT)
            {
                result += signalParameter + " ";
            }
            ViewBag.resultIDFT = result;

            return View("DFT");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult generatePassword()
        {
            ViewBag.Message = "Random password generator";
            ViewBag.Password = new GenerateRandomPassword().GeneratePassword();
            return View("RandomPasswordGenerator");
        }
    }
}
