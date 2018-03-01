using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            string[] input = Console.ReadLine().Split();
            int number = int.Parse(input[0]);
            int desiredNumber = int.Parse(input[1]);

            queue.Enqueue(number);
            int currIndex = 0;
            while (queue.Count>0)
            {
                int curr = queue.Dequeue();
                int increment = curr + 1;
                int multi = curr * 2;
                queue.Enqueue(increment);
                queue.Enqueue(multi);
                currIndex++;
                if (curr==desiredNumber)
                {
                    Console.WriteLine(currIndex);
                    break;
                }   
            }
        }
    }
}
