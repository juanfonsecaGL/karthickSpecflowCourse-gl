using RestSharp.Serialization.Json;
using System.Collections.Generic;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace nUnit
{
    [TestFixture]
    public class nUnitTest
    {
        public nUnitTest()
        {
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
