using RestSharp.Serialization.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RestSharp;

using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using Newtonsoft.Json.Linq;

namespace nUnit
{
    [TestClass]
    public class nUnitTestExtendedReports
    {
        public static ExtentTest test;
        public static ExtentReports extent;
        static string basepath = "/Users/juan.fonseca/Desktop/";

        public nUnitTestExtendedReports()
        {
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {

            /*extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(
                @$"{basepath}\Report{ DateTime.Now.ToString("_MMddyyyy_hhmmtt") }.html");
            extent.AttachReporter(htmlreporter);*/
        }

        [TestMethod]
        public void TestMethod1()
        {

            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(
                @$"{basepath}\Report{ DateTime.Now.ToString("_MMddyyyy_hhmmtt") }.html");
            extent.AttachReporter(htmlreporter);

            test = null;
            test = extent.CreateTest("T001").Info("Login Test");

            // TC
            var client = new RestClient("https://pokeapi.co/");
            var request = new RestRequest("api/v2/pokemon/{pokemonID}", Method.GET);
            request.AddUrlSegment("pokemonID", 1);

            var response = client.Execute(request);
            System.Console.WriteLine($"Result: {response.Content.ToString()}");

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var valueCurrent = output["id"];

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert
                .AreEqual(valueCurrent, "1", "Page is not correct.");
            test.Log(Status.Pass, "Test Pass");

            extent.Flush();

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
