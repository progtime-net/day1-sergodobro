using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git
{
    interface ICalculator
    {
        void Start(); //greetings, load operations, get equation, output result
        double Calculate(string input); 
                                      //Split equation
                                      //find operation
                                      //Calculate it
                                      //костяк программы короче



        List<ICalculator_Operation> action_List { get; set; }
        void LoadOperations();
        ICalculator_Operation FindOperationInList(string signature);
         
    }
}