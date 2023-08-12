using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Git
{
    class Calculator : ICalculator
    {
        List<ICalculator_Operation> calculator_Operations;
        public ICalculator_Operation FindOperation(string signature)
        {
            foreach (var item in calculator_Operations)
                if (item.Action_signature == signature)
                    return item;
            return null;
        }

        public void LoadOperationList()
        {
            calculator_Operations = new List<ICalculator_Operation>();
            calculator_Operations.Add(new Operations.Operation_Plus());
            calculator_Operations.Add(new Operations.Operation_Minus());
            calculator_Operations.Add(new Operations.Operation_Multiply());
            calculator_Operations.Add(new Operations.Operation_Divide());
        }

        public double SolveEquation(string equation)
        {
            var data = SplitEquationToFormat(equation);
            List<int> openningSkobkas = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == "(")
                    openningSkobkas.Add(i);
                if (data[i]== ")")
                {
                    int oldDataL = data.Count;
                    SolveSkobka(data, openningSkobkas.Last(), i);
                    int newDataL = data.Count;
                    i -= (oldDataL - newDataL);
                    //1-2+ (1-3)
                    //1-2+ {-2}
                    //1234 56789
                    //1234 5
                }
            }
            data.Insert(0, "(");
            data.Add(")");
            SolveSkobka(data, 0, data.Count-1);
            double res = double.Parse(data[0]);
            return res;
        }

        public double SolveSkobka(List<string> span, int indexFrom, int indexTo)
        {
            throw new NotImplementedException();
        }

        public List<string> SplitEquationToFormat(string equation)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            Console.WriteLine("Write your expression:");
            string expression = Console.ReadLine();
            double result = SolveEquation(expression);
            Console.WriteLine($"{result} it is then!");
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
    }
}
