using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using Actions;

namespace ActionsOnExpressionStandart
{
    public class Standart
    {

        public Standart(StringBuilder stringBuilder,string operation,out string result)
        {
            FormattingExpression frmExp = new FormattingExpression(stringBuilder);
            result = IOperation.result!;
            // [05/0 = 1]
        }
    }
}