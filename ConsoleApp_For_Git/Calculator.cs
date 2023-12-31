﻿using System;
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
            calculator_Operations.Add(new Operations.Operation_Power());
            calculator_Operations.Add(new Operations.Operation_PostLog());
            calculator_Operations.Add(new Operations.Operation_Sin());
            calculator_Operations.Add(new Operations.Operation_Cos());
        }

        public double SolveEquation(string equation) //2+2-(30*(20-2))
        {
            var data = SplitEquationToFormat(equation.Replace('.', ',').Replace("(-", "(0-")
                .Replace("sin", "0sin"));
            List<int> openningSkobkas = new List<int>();
            data.Insert(0, "(");
            data.Add(")");
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == "(")
                    openningSkobkas.Add(i);
                if (data[i]== ")")
                {
                    int from = openningSkobkas.Last(); 
                    openningSkobkas.RemoveAt(openningSkobkas.Count-1);
                    int to = i;
                    var _res=SolveSkobka(data, from, to);
                    i -= (to - from);
                    //1-2+ (1-3)
                    //1-2+ {-2}
                    //1234 56789
                    //1234 5
                    ReplaceRange(data, from, to, _res.ToString());
                }
            } 
            double res = double.Parse(data[0]);
            return res;
        }
        private void ReplaceRange(List<string> span, int from, int to, string item)
        {
            span.RemoveRange(from+1, to-from);
            span[from] = item;
        }
        public double SolveSkobka(List<string> span, int indexFrom, int indexTo)
        {
            List<string> primer = span.GetRange(indexFrom + 1, (indexTo-1) - (indexFrom));
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
            int q = 0;
            string nums = "0123456789,.";
            string skobkas = "()";
            if (skobkas.Contains(equation[0])) q = 2;
            for (int i = 1; i < equation.Length; i++)
            {

                if (nums.Contains(equation[i]) && q != 0)
                {
                    formatString.Add(a);
                    a = equation[i].ToString();
                    q = 0;
                }
                else if (skobkas.Contains(equation[i]))
                {
                    formatString.Add(a);
                    a = equation[i].ToString();


                    q = 2;

                }
                else if (q != 1 && !nums.Contains(equation[i]))
                {
                    formatString.Add(a);
                    a = equation[i].ToString();
                    q = 1;
                }
                else
                {
                    a += equation[i];
                }



            }
            formatString.Add(a);

            return formatString;
        }
        public void Start()
        {
            LoadOperationList();
            while (Ask() != "")
            { }
        }
        private string Ask()
        {
            Console.WriteLine("Write your expression:");
            string expression = Console.ReadLine();
            if (expression == "") return "";
            double result = SolveEquation(expression);
            Console.WriteLine($"{result} it is then!");
            Console.WriteLine("Goodbye!");
            return expression;
        }
    }
}
