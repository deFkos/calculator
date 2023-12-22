using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using Actions;

namespace ActionsOnExpressionStandart
{
    public class Standart
    {

        public Standart(string leftOp, string rightOp,string op,out string? result, out List<string> historyOper, ref bool IsComm)
        {
            ExpressionSpliting frmExp = new ExpressionSpliting(leftOp,rightOp,op);
            result = IOperation.result;
            if (result.Contains('.'))
            {
                IsComm = true;
            }
            historyOper = IOperation.historyOper!;
        }
    }
}