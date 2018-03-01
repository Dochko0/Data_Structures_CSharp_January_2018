using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string expression = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char curr = expression[i];

                if (curr=='(')
                {
                    stack.Push(i);
                }
                else if (curr==')')
                {
                    int prev = stack.Pop();
                    int lenght = i - prev+1;
                    string exp = expression.Substring(prev, lenght);
                    Console.WriteLine(exp);
                }
            }

        }
    }
}
