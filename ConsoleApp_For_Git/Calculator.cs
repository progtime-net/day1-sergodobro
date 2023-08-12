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
            throw new NotImplementedException();
        }

        public void LoadOperationList()
        {
            throw new NotImplementedException();
        }

        public double SolveEquation(string equation)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
