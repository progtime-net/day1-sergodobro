using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git.Operations
{
    class Operation_PostLog : ICalculator_Operation
    {
        public bool isPrioritized { get; set; } = true;
        public string Action_signature { get; set; } = "log";

        public double GetResult(double num1, double num2) => Math.Log(num1, num2);
    }
}
