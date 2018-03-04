using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{

    public Node root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }
        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public void Insert(T value)
    {
        this.root = this.Insert(this.root, value);
        //if (this.root == null)
        //{
        //    this.root = new Node(value);
        //    return;
        //}

        //Node parent = null;
        //Node curr = this.root;

        //while (curr != null)
        //{


        //    int compare = curr.Value.CompareTo(value);
        //    if (compare > 0)
        //    {
        //        parent = curr;
        //        curr = curr.Left;

        //    }
        //    else if (compare < 0)
        //    {
        //        parent = curr;
        //        curr = curr.Right;

        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        //Node newNode = new Node(value);

        //if (parent.Value.CompareTo(value) > 0)
        //{
        //    parent.Left = newNode;

        //}
        //else
        //{
        //    parent.Right = newNode;
        //}
    }

    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }
        int compare = node.Value.CompareTo(value);

        if (compare > 0)
        {
            node.Left = this.Insert(node.Left, value);
        }
        else if (compare < 0)
        {
            node.Right = this.Insert(node.Right, value);
        }
        return node;
    }

    public bool Contains(T value)
    {
        Node curr = this.root;

        while (curr != null)
        {

            int compate = curr.Value.CompareTo(value);

            if (compate > 0)
            {
                curr = curr.Left;
            }
            else if (compate < 0)
            {
                curr = curr.Right;
            }
            else
            {
                return true;
            }

        }


        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        if (this.root.Left == null && this.root.Right == null)
        {
            this.root = null;
            return;
        }

        Node parent = null;
        Node curr = this.root;

        while (curr.Left != null)
        {
            parent = curr;
            curr = curr.Left;
        }

        if (curr.Right != null)
        {
            parent.Left = curr.Right;
        }
        else
        {
            parent.Left = null;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node curr = this.root;

        while (curr != null)
        {
            int compare = curr.Value.CompareTo(item);
            if (compare > 0)
            {
                curr = curr.Left;
            }
            else if (compare < 0)
            {
                curr = curr.Right;
            }
            else if (compare == 0)
            {
                return new BinarySearchTree<T>(curr);
            }
        }
        return null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        List<T> result = new List<T>();
        this.Range(this.root, result, startRange, endRange);
        return result;
    }

    private void Range(Node node, List<T> result, T start, T end)
    {
        if (node == null)
        {
            return;
        }
        int compareLow = node.Value.CompareTo(start);
        // 
        int compareHigh = node.Value.CompareTo(end);

        if (compareLow>0)
        {
            this.Range(node.Left, result, start, end);
        }

        if (compareLow >= 0 && compareHigh <= 0)
        {
            result.Add(node.Value);
        }
        if (compareHigh <0)
        {
            this.Range(node.Right, result, start, end);
        }


    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }
        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }



    public class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

    }
}

public class Launcher
{
    public static void Main(string[] args)
    {

    }
}
