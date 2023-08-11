using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git
{
    interface ICalculator_Action
    {
        string Action_signature { get; set; } //+,-,*, etc.
        double GetResult(double num1, double num2); //executeThisAction
    }
}
