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
            List<string> primer = span.GetRange(indexFrom+1, indexTo-1);
            for (int i = 1; i < primer.Count; i+=2)
            {
                ICalculator_Operation _operation = FindOperation(primer[i]);
                if (_operation.isPrioritized)
                {
                   
                    primer[i-1] = _operation.GetResult(double.Parse(primer[i - 1]), double.Parse(primer[i + 1])).ToString();
                    primer.RemoveRange(i, 2);
                    i -= 2;
                }
            }
            for (int i = 1; i < primer.Count; i += 2)
            {
                ICalculator_Operation _operation = FindOperation(primer[i]);
                

                primer[i - 1] = _operation.GetResult(double.Parse(primer[i - 1]), double.Parse(primer[i + 1])).ToString();
                primer.RemoveRange(i, 2);
                i -= 2;
                
            }
            return double.Parse(primer[0]);

        }

        public List<string> SplitEquationToFormat(string equation)
        {
            List<string> formatString = new List<string>();
            string a = equation[0].ToString();
            bool flag = true;
            string nums = "0123456789.";
            for (int i = 1; i < equation.Length; i++)
            {
                if (nums.Contains(equation[i])&&flag)
                {
                    a += equation[i];
                }
                else if (nums.Contains(equation[i]) && !flag)
                {
                    formatString.Add(a);
                    a = "";
                    flag = true;
                }
                else if (!nums.Contains(equation[i]) && flag)
                {
                    formatString.Add(a);
                    a = "";
                    flag = false;
                }
                else
                {
                    a += equation[i];
                }


            }
            return formatString;
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
