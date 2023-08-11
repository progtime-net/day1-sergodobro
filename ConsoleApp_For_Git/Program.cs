using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! What is your name, user?");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}! Welcome to our world!");
            
            Console.ReadLine();
        }
    } 

    interface Calculator
    {
        void Start(); //take input

        double SolveEquation(string equation);
        /// 1 - convertToWorkingData
        /// 2 - while not 1 element in data
        ///     solvewithoutSkobkis();

        List<string> SplitEquationToFormat(string equation);
        ///exmplanation
        ///turn 1+2+(7*9-(3-2))
        ///into list {1}{+}{2}{+}{(}{7}{*}{9}{-}{(}{3}{-}{2}{)}{)}


        Tuple<int, int> SelectSkobkaPairs();
        ///turn {1}{+}{2}{+}{(}{7}{*}{9}{-}{(}{3}{-}{2}{)}{)}
        ///into 4-14, 9-13 

             
        double solveSkobka(Tuple<int,int> SkobkaPair); //Replaceold partindata and move all second skobka indexes
    }
    interface Calc_Action
    {
        string Action_signature { get; set; } //+,-,*, etc.
        double GetResult(double num1, double num2); //executeThisAction
    }
}
