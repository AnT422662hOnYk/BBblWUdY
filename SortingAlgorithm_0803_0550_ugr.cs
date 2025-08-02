// 代码生成时间: 2025-08-03 05:50:35
using System;
using System.Collections.Generic;

/// <summary>
/// A class that provides sorting functionality.
/// </summary>
public class SortingAlgorithm
{
    /// <summary>
    /// Sorts the array using the Bubble Sort algorithm.
    /// </summary>
    /// <param name="arr">The array of integers to be sorted.</param>
    public static void BubbleSort(int[] arr)
    {
        if (arr == null)
        {
            throw new ArgumentNullException(nameof(arr), "The array cannot be null.");
        }

        bool swapped;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap the elements
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            // If no two elements were swapped by inner loop, then break
            if (!swapped)
                break;
        }
    }

    /// <summary>
    /// Sorts the list using the Quick Sort algorithm.
    /// </summary>
    /// <param name="list">The list of integers to be sorted.</param>
    public static void QuickSort(List<int> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "The list cannot be null.");
        }

        QuickSortHelper(list, 0, list.Count - 1);
    }

    private static void QuickSortHelper(List<int> list, int first, int last)
    {
        if (first < last)
        {
            int pivotIndex = Partition(list, first, last);
            QuickSortHelper(list, first, pivotIndex - 1);
            QuickSortHelper(list, pivotIndex + 1, last);
        }
    }

    private static int Partition(List<int> list, int first, int last)
    {
        int pivot = list[first];
        int i = first, j = last;
        while (true)
        {
            while (i < last && list[i] < pivot)
                i++;
            while (j > first && list[j] > pivot)
                j--;
            if (i >= j)
                break;
            Swap(list, i, j);
        }
        Swap(list, i, first);
        return i;
    }

    private static void Swap(List<int> list, int i, int j)
    {
        int temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    /// <summary>
    /// Demonstrates the usage of sorting algorithms.
    /// </summary>
    public static void Main()
    {
        int[] arrayToSort = { 5, 3, 8, 4, 2 };
        BubbleSort(arrayToSort);
        Console.WriteLine("Sorted array using Bubble Sort: " + string.Join(", ", arrayToSort));

        List<int> listToSort = new List<int> { 5, 3, 8, 4, 2 };
        QuickSort(listToSort);
        Console.WriteLine("Sorted list using Quick Sort: " + string.Join(", ", listToSort));
    }
}
