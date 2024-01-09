using Actions;

namespace Actions.Test
{
    public class ArithmeticOperationTest : ArithmeticOperation
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void correct_formatting1()
        {
            string resultExprected = "-50";
            IOperation.FirstNumber = "-55";
            IOperation.SecondNumber = "-5";
            IOperation.Operators = "-";
            ArithmeticOperation arithmeticOperation = new();
            Assert.That(IOperation.result, Is.EqualTo(resultExprected));
        }
    }
}