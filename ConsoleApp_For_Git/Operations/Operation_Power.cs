using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git.Operations
{
    class Operation_Power : ICalculator_Operation
    {
        public bool isPrioritized { get; set; } = false;
        public string Action_signature { get; set; } = "^";

        public double GetResult(double num1, double num2) => Math.Pow(num1, num2);
    }
}
