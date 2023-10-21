using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    public interface IOperation
    {
        public static string result { get; internal set; }
        public static char[]? Operators { get; internal set; }
        public static string FirstNumber { get; internal set; }
        public static string SecondNumber { get; internal set; }
    }
}
