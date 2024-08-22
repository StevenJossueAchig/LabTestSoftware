using Laboratorio2_Achig.Models;

namespace SpecFlowTest.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        //Instanciamos la clase calculator que hicimos en el modelo del laboratorio 2
        // ctrl + . para ver soluciones
        private readonly Calculator _calculator = new Calculator();
        private int _result;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //debo para empezar traer el numero que tengo en el escenario, consumirlo que esta en el feature
            _calculator.FirstNumber = number;
            
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }
    }
}
