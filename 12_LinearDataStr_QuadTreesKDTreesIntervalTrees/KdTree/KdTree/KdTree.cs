﻿using System;

public class KdTree
{
    //2 Dimensions 
    private int K = 2;
    private Node root;

    public class Node
    {
        public Node(Point2D point)
        {
            this.Point = point;
        }

        public Point2D Point { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public Node Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(Point2D point)
    {
        return Search(this.root, point, 0) != null;
    }

    private object Search(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return null;
        }

        int cmp;
        if (depth % 2 == 0)
        {
            cmp = point.X.CompareTo(node.Point.X);

            if (cmp == 0)
            {
                cmp = point.Y.CompareTo(node.Point.Y);
            }
        }
        else
        {
            cmp = point.Y.CompareTo(node.Point.Y);

            if (cmp == 0)
            {
                cmp = point.X.CompareTo(node.Point.X);
            }
        }

        if (cmp < 0)
        {
            return Search(node.Left, point, depth + 1);
        }

        if (cmp > 0)
        {
            return Search(node.Right, point, depth + 1);
        }

        return node;
    }

    public void Insert(Point2D point)
    {
        this.root = this.Insert(this.root, point, 0);
    }

    private Node Insert(Node node, Point2D point, int depth)
    {
        if (node==null)
        {
            return new Node(point);
        }
        int compare = depth % K;
        if (compare == 0)
        {
            int compareX = node.Point.X.CompareTo(point.X);
            
            if (compareX > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareX <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        else
        {
            int compareY = node.Point.Y.CompareTo(point.Y);
            if (compareY > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareY <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        return node;
    }

    public void EachInOrder(Action<Point2D> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<Point2D> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Point);
        this.EachInOrder(node.Right, action);
    }
}
