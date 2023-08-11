using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git
{
    interface ICalculator
    { 

        void Start(); //take input
        void LoadOperationList();
        ICalculator_Operation FindOperation(string signature);

        double SolveEquation(string equation);
        /// 1 - convertToWorkingData
        /// save indexes of opening skobkas to list, when you find closing skobkas, решите выражение между индексами и удалите использованные элементы 

        List<string> SplitEquationToFormat(string equation);
        ///exmplanation
        ///turn 1+2+(7*9-(3-2))
        ///into list {1}{+}{2}{+}{(}{7}{*}{9}{-}{(}{3}{-}{2}{)}{)}

            
        double solveSkobka(List<string> span, int indexFrom, int indexTo); //Replace old partindata and move all second skobka indexes
    }
}