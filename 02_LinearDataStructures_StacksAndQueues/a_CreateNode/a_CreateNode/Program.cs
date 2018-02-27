using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_CreateNode
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> head = new Node<int>();
            Node<int> node1 = new Node<int>();
            head.Next = node1;
        }
    }
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
