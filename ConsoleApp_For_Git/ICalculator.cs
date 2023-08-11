using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git
{
    interface ICalculator
    {
        void Start(); //get input, start program, load Actions
        void Calculate(string input); //calculator main
                                      //Split equation
                                      //Calculate it
                                      //костяк программы короче



        List<ICalculator_Action> action_List { get; set; }
        void LoadActions();



        double num1 { get; set; }
        double num2 { get; set; }
        ICalculator_Action action { get; set; }
        void SplitEquation(); // set num1, num2, action(Find from action_List)
    }
}
