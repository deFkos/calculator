using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using Actions;

namespace ActionsOnExpressionStandart
{
    public class Standart
    {
        //public string Result { get; private set; }

        public Standart(StringBuilder stringBuilder,string operation,out string result)
        {
             switch(operation)
             {
                case "-": FormattingExpression frmExp = new FormattingExpression(stringBuilder); break;
                case "+/-": frmExp = new FormattingExpression(stringBuilder); break;
                case "ce": frmExp = new FormattingExpression(stringBuilder); break;
                case "c": frmExp = new FormattingExpression(stringBuilder); break;
                case "equlityButton": frmExp = new FormattingExpression(stringBuilder); break;
            }
            result = IOperation.result!;
            // [05/0 = 1]
        }
    }
}