using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Actions
{
    public class ArithmeticOperation : IOperation
    {
        public List<string> historyOper = new List<string>();

        private char[] Operators { get; set; }
        private double FirstNumber { get; set; }
        private double SecondNumber { get; set; }

        public ArithmeticOperation()
        { 
            FirstNumber = double.Parse(IOperation.FirstNumber!);
            SecondNumber = double.Parse(IOperation.SecondNumber!);
            Operators = IOperation.Operators!;
            double result = 0;
            foreach (var i in Operators)
            {
                result =
                   i == '+' ? Arithmetic(FirstNumber, SecondNumber, Add)
                 : i == '-' ? Arithmetic(FirstNumber, SecondNumber, Take)
                 : i == '*' ? Arithmetic(FirstNumber, SecondNumber, Multiply)
                 : i == '/' ? Arithmetic(FirstNumber, SecondNumber, Division)
                 : 0;
            }
            IOperation.result = result.ToString();
        }
        private double Arithmetic(double FirstNumber, double SecondNumber, Func<double, double, double> op) => op(FirstNumber, SecondNumber);
        private double Add(double FirstNumber, double SecondNumber)
        {
            historyOper.Add($"{FirstNumber} + {SecondNumber} = {FirstNumber+SecondNumber}");
            return FirstNumber + SecondNumber;
        }
        private double Take(double FirstNumber, double SecondNumber)
        {
            historyOper.Add($"{FirstNumber} - {SecondNumber} = {FirstNumber - SecondNumber}");
            return FirstNumber - SecondNumber;
        }
        private double Multiply(double FirstNumber, double SecondNumber)
        {
            historyOper.Add($"{FirstNumber} * {SecondNumber} = {FirstNumber * SecondNumber}");
            return FirstNumber * SecondNumber;
        }
        private double Division(double FirstNumber, double SecondNumber)
        {
            historyOper.Add($"{FirstNumber} / {SecondNumber} = {FirstNumber / SecondNumber}");
            return FirstNumber / SecondNumber;
        }
    }
}