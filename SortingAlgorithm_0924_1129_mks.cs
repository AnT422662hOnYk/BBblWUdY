// 代码生成时间: 2025-09-24 11:29:41
// Copyright (c) <Your Name>. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides a set of sorting algorithms for Unity.
/// </summary>
public static class SortingAlgorithm
{
    /// <summary>
    /// Sorts an array of integers using the Bubble Sort algorithm.
    /// </summary>
    /// <param name="array">The array to sort.</param>
    /// <returns>The sorted array.</returns>
    public static int[] BubbleSort(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array cannot be null.");
        }

        int n = array.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap the elements if they are in the wrong order.
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
            }
            // If no elements were swapped, the array is already sorted.
            if (!swapped)
                break;
        }
        return array;
    }

    /// <summary>
    /// Sorts an array of integers using the Quick Sort algorithm.
    /// </summary>
    /// <param name="array">The array to sort.</param>
    /// <returns>The sorted array.</returns>
    public static int[] QuickSort(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array cannot be null.");
        }

        return QuickSortRecursive(array, 0, array.Length - 1);
    }

    private static int[] QuickSortRecursive(int[] array, int left, int right)
    {
        int i = left, j = right;
        int pivot = array[(left + right) / 2];

        while (i <= j)
        {
            while (array[i] < pivot)
                i++;
            while (array[j] > pivot)
                j--;
            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (left < j)
            QuickSortRecursive(array, left, j);
        if (i < right)
            QuickSortRecursive(array, i, right);

        return array;
    }

    // Add additional sorting algorithms as needed.
}
