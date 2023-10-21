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

            foreach (var i in IOperation.Operators) { expression.Replace(i.ToString(), "", 0, 1); }

            IOperation.SecondNumber = String.Join("", expression.ToString().TakeWhile(g => Char.IsDigit(g) || g == ','));
            if (IOperation.SecondNumber != "")
            {
                expression.Replace(IOperation.SecondNumber.ToString(), "", 0, IOperation.SecondNumber.ToString().Length);
            }

            //вот это плохо
            Regex regex = new Regex(@"\,(\D?)");
            if (IOperation.FirstNumber.Where(x => Regex.IsMatch(x.ToString(), regex.ToString(), RegexOptions.Multiline)).Count() > 1)
            {
                int comma = 0;
                for (int i = 0; i < IOperation.FirstNumber.Length; i++)
                {
                    if (IOperation.FirstNumber[i] == ',')
                        comma++;
                    if (comma > 1)
                        IOperation.FirstNumber = IOperation.FirstNumber.Remove(i, 1);
                }
            }
            if (IOperation.SecondNumber.Where(x => Regex.IsMatch(x.ToString(), regex.ToString(), RegexOptions.Compiled)).Count() > 1)
            {
                int comma = 0;
                for (int i = 0; i < IOperation.SecondNumber.Length; i++)
                {
                    if (IOperation.SecondNumber[i] == ',')
                        comma++;
                    if (comma > 1)
                        IOperation.SecondNumber = IOperation.SecondNumber.Remove(i, 1);
                }
            }
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
