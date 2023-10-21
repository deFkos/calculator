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
            }
            else
                IOperation.FirstNumber = "0";

            foreach (var i in IOperation.Operators) { expression.Replace(i.ToString(), "", 0, 1); }

            IOperation.SecondNumber = String.Join("", expression.ToString().TakeWhile(g => Char.IsDigit(g) || g == ','));
            if (IOperation.SecondNumber != "")
            {
                expression.Replace(IOperation.SecondNumber.ToString(), "", 0, IOperation.SecondNumber.ToString().Length);
            }
            else
                IOperation.SecondNumber = "0";

            ArithmeticOperation arithmetic = new ArithmeticOperation();
        }
        /*
         * ,5 = 0,5 или запрятить первой ставить ,
         *  надо запретить ввод более 2-ух знаков подряд - посчитать если один знак уже написан
         *  возможность вывести операции в excel и дать столбикам имя
         *  стрелочка стирает 1 символ справа 
         *  +/- умножает на -1
         *  ce стирает textbox
         *  c чистить историю
         */
    }
}
