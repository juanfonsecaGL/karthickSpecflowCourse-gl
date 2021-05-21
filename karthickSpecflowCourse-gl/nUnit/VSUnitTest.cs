using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using RestSharp;

namespace nUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);
            System.Console.WriteLine($"Result: {response.Content.ToString()}");

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var authorCurrent = output["author"];

            Assert.AreEqual(authorCurrent,"typicode", "Author is not correct.");
        }
    }
}
