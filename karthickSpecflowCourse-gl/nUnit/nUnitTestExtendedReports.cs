using RestSharp.Serialization.Json;
using System.Collections.Generic;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

/*using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace nUnit
{
    [TestFixture]
    public class nUnitTestExtendedReports
    {
        //public ExtentReports extent;
        //public ExtentTest test;

        public nUnitTestExtendedReports()
        {
        }

        [OneTimeSetUp]
        public void StartReport()
        {
            /*string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "ReportsMyOwnReport.html";

            extent = new ExtentReports(reportPath, true);
            extent
            .AddSystemInfo("Host Name", "Krishna")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Krishna Sakinala");
            extent.LoadConfig(projectPath + "extent-config.xml");*/
        }

        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);
            System.Console.WriteLine($"Result: {response.Content.ToString()}");

            JObject obs = JObject.Parse(response.Content);

            Assert.That(obs["author"].ToString(), Is.EqualTo("typicode"), "Author is not correct.");
        }
    }
}
