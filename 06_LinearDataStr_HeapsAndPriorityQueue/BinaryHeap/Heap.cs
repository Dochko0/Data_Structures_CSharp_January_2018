using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        ConstructHeap(arr);
        HeapSort(arr);
    }

    private static void HeapSort(T[] arr)
    {
        for (int i = arr.Length-1; i >=0; i--)
        {
            Swap(arr, 0, i);
            HeapifyDown(arr, 0, i);
        }
    }

    private static void ConstructHeap(T[] arr)
    {
        for (int i = arr.Length / 2; i >= 0; i--)
        {
            HeapifyDown(arr, i, arr.Length);
        }
    }

    //private static void HeapifyUp(T[] heap, T item, int index)
    //{
    //    int parent = (index - 1) / 2;
    //    //index is a child
    //    if (parent < 0)
    //    {
    //        return;
    //    }
    //    int compare = heap[parent].CompareTo(heap[index]);

    //    if (compare < 0)
    //    {
    //        Swap(heap, parent, index);
    //        HeapifyUp(heap, heap[parent], parent);
    //    }
    //}

    private static void HeapifyDown(T[] arr, int index, int lenght)
    {
        //int leftChild = (index * 2) + 1;
        //int rightChild = leftChild + 1;
        int parentIndex = index;

        while (parentIndex < lenght / 2)
        {
            //left child
            int childIndex = (parentIndex * 2) + 1;
            //check there is right child && rightChild > leftChild
            if (childIndex + 1 < lenght && isGreater(arr, childIndex, childIndex + 1))
            {
                // RightChild
                childIndex += 1;
            }

            int compare = arr[parentIndex].CompareTo(arr[childIndex]);
            if (compare < 0)//parent < child
            {
                Swap(arr, childIndex, parentIndex);

            }
            parentIndex = childIndex;
        }
    }
    private static bool isGreater(T[] heap, int left, int right)
    {
        return heap[left].CompareTo(heap[right]) < 0;
    }
    private static void Swap(T[] heap, int parent, int index)
    {
        T temp = heap[parent];
        heap[parent] = heap[index];
        heap[index] = temp;
    }
}
