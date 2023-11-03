using Actions;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;

namespace Actions.Test
{
    public class FormattingExpressionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void correct_formatting1()
        {
            string[] firstValue = { "4", ",", "5", "*", "5" }; 
            string[] secondValue = { "22", ",","5",","};
            string str = "";
            string firstExptected = "4,5*5";
            string SecondExptected = "22,5";
            FormattingExpression frmExp = new FormattingExpression();
            foreach (var item in firstValue)
            {
                Debug.WriteLine(item);
                (string val, string st) var = frmExp.format(item, str);
                str = var.st;
            }
            Assert.AreEqual(firstExptected, str);
            str = "";
            foreach (var item in secondValue)
            {
                (string val, string st) var = frmExp.format(item,str);
                str = var.st;
            }
            Assert.AreEqual(SecondExptected, str);
        }
    }
}