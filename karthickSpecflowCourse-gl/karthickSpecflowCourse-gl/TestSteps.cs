using System;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using NUnit.Framework;

namespace karthickSpecflowCoursegl
{
    [Binding]
    public class TestSteps
    {
        Calculator calculator;

        public TestSteps() {
            calculator = new Calculator();
        }

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
    }
}
