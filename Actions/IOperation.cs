using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    public interface IOperation
    {
        public static bool comm { get; set; } //temporary property
        public static bool oper { get; set; } //temporary property
        public static string? result { get; internal  set; }
        public static string Operators { get; protected set; }
        public static string? FirstNumber { get; protected set; }
        public static string? SecondNumber { get; protected set; }

        public static List<string?> historyOper = new List<string?>();
    }
}
