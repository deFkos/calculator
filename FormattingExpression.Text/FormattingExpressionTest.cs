using Actions;
using System.Text;

namespace Actions.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void _30and_45_Multiply()
        {
            StringBuilder str = new StringBuilder("30*45");
            string? firstExpected = "30";
            string? secondExpected = "45";
            char[]? operExpected = {'*'};

            FormattingExpression frmExp = new FormattingExpression(str);

            Assert.AreEqual(firstExpected, IOperation.FirstNumber);
            Assert.AreEqual(secondExpected, IOperation.SecondNumber);
            Assert.AreEqual(operExpected, IOperation.Operators);
        }
        [Test]
        public void _05and_5_Division()
        {
            StringBuilder str = new StringBuilder("05/5");
            string? firstExpected = "0,5";
            string? secondExpected = "5";
            char[]? operExpected = { '/' };

            FormattingExpression frmExp = new FormattingExpression(str);

            Assert.AreEqual(firstExpected, IOperation.FirstNumber);
            Assert.AreEqual(secondExpected, IOperation.SecondNumber);
            Assert.AreEqual(operExpected, IOperation.Operators);
        }
        [Test]
        public void _5and_5_Take()
        {
            StringBuilder str = new StringBuilder("-5-5");
            string firstExpected = "-5";
            string secondExpected = "-5";
            char[] operExpected = { '-' };

            FormattingExpression frmExp = new FormattingExpression(str);

            Assert.AreEqual(firstExpected, IOperation.FirstNumber);
            Assert.AreEqual(secondExpected, IOperation.SecondNumber);
            Assert.AreEqual(operExpected, IOperation.Operators);
        }
    }
}