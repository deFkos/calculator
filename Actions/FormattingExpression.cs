using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    public class FormattingExpression : IOperation
    {

        public (string, string) format(string value, string str)
        {
            if (IOperation.oper == true && (value == "*" || value == "/" || value == "-" || value == "+")) value = "";
            if (value == "*" || value == "/" || value == "-" || value == "+") IOperation.oper = true;
            switch (value)
            {
                case "," when IOperation.comm == true: value = ""; break;
                case "," when IOperation.comm == false: IOperation.comm = true; goto default;
                case "*" when IOperation.oper == true: IOperation.comm = false; goto default;
                case "/" when IOperation.oper == true: IOperation.comm = false; goto default;
                case "-" when IOperation.oper == true: IOperation.comm = false; goto default;
                case "+" when IOperation.oper == true: IOperation.comm = false; goto default;
                case "←" when
                str.Last() == '*' ||
                str.Last() == '/' ||
                str.Last() == '-' ||
                str.Last() == '+'
                :
                    IOperation.oper = false; str = str.Remove(str.Length - 1); break;

                case "←" when str.Remove(str.Length - 1) == ",":
                    str.Remove(str.Length - 1); IOperation.comm = false; break;
                case "←":
                    str.Remove(str.Length - 1); break;
                case "CE": str = ""; IOperation.comm = false; break;
                default: str += value; break;
            }
            return (value, str);
        }
    }
}
