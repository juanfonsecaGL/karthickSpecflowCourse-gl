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
            var client = new RestClient("https://pokeapi.co/");
            var request = new RestRequest("api/v2/pokemon/{pokemonID}", Method.GET);
            request.AddUrlSegment("pokemonID", 1);

            var response = client.Execute(request);
            System.Console.WriteLine($"Result: {response.Content.ToString()}");

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var valueCurrent = output["id"];

            Assert.AreEqual(valueCurrent,"1", "Page is not correct.");
        }
    }
}
