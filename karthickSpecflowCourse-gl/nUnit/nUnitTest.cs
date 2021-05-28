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
            var client = new RestClient("https://pokeapi.co/");
            var request = new RestRequest("api/v2/pokemon/{pokemonID}", Method.GET);
            request.AddUrlSegment("pokemonID", 1);

            var response = client.Execute(request);
            System.Console.WriteLine($"Result: {response.Content.ToString()}");

            JObject obs = JObject.Parse(response.Content);

            Assert.That(obs["id"].ToString(), Is.EqualTo("1"), "ID is not correct.");
        }
    }
}
