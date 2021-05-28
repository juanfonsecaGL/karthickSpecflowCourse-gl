using System;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using NUnit.Framework;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace karthickSpecflowCoursegl
{
    [Binding]
    public class TestSteps
    {
        IConfiguration config;
        Calculator calculator;
        string valueCurrent;
        int pokemonID;

        public TestSteps() {
            calculator = new Calculator();

            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // Scenario 1

        [Given("I have entered \"(.*)\" into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            calculator.enterNumber(number);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            calculator.sumAllNumbers();
        }

        [Then("the result should be \"(.*)\" on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(calculator.getLastResult(), result, $"Obtained result differs from expected: {calculator.getLastResult()} != {result}");
        }

        // Scenario 2

        [Given("the Pokedex is working")]
        public void GivenThePokedexIsWorking()
        {
            
        }

        [When("I have entered ID \"(.*)\" into the Pokedex")]
        public void IHaveEnteredAnIdIntoThePokedex(int id)
        {
            int offset = int.Parse(config["offset"]);
            pokemonID = offset + 1;

            var client = new RestClient("https://pokeapi.co/");
            var request = new RestRequest("api/v2/pokemon/{pokemonID}", Method.GET);
            request.AddUrlSegment("pokemonID", pokemonID);

            var response = client.Execute(request);
            System.Console.WriteLine($"Result: {response.Content}");

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            valueCurrent = output["id"];
        }

        [Then("the result should return a Pokemon with ID \"(.*)\"")]
        public void ThenTheResultShouldReturnAPokemonWithID(int id)
        {
            Assert.AreEqual(valueCurrent, $"{pokemonID}", "ID is not correct.");
        }
    }
}

