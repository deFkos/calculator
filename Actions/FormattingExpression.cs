using Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Actions
{
    public class FormattingExpression : IOperation
    {
        public FormattingExpression(StringBuilder expression)
        {
            IOperation.Operators = String.Join("", expression.ToString().Where(g => !Char.IsDigit(g) && g != ',')).ToCharArray();

            IOperation.FirstNumber = String.Join("", expression.ToString().TakeWhile(g => Char.IsDigit(g) || g == ','));
            if (IOperation.FirstNumber != "")
            {
                expression.Replace(IOperation.FirstNumber.ToString(), "", 0, IOperation.FirstNumber.ToString().Length);
                if (IOperation.FirstNumber == ",")
                    IOperation.FirstNumber = "0";
            }
            else
                IOperation.FirstNumber = "0";
            foreach (var i in IOperation.Operators) { expression.Replace(i.ToString(), "", 0, 1); }
            IOperation.SecondNumber = String.Join("", expression.ToString().TakeWhile(g => Char.IsDigit(g) || g == ','));
            if (IOperation.SecondNumber != "")
            {
                expression.Replace(IOperation.SecondNumber.ToString(), "", 0, IOperation.SecondNumber.ToString().Length);
                if (IOperation.SecondNumber == ",")
                    IOperation.SecondNumber = "0";
            }
            else
                IOperation.SecondNumber = "0";
            ArithmeticOperation arithmetic = new ArithmeticOperation();
        }
    }
}
