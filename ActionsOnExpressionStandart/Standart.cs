using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using Actions;

namespace ActionsOnExpressionStandart
{
    public class Standart
    {

        public Standart(StringBuilder stringBuilder,string operation,out string? result,out List<string> historyOper)
        {
            FormattingExpression frmExp = new FormattingExpression(stringBuilder);
            result = IOperation.result;
            historyOper = IOperation.historyOper!;
        }
    }
}