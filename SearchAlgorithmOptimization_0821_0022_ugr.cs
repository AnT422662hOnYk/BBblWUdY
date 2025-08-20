// 代码生成时间: 2025-08-21 00:22:23
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for optimizing search algorithms in a Unity environment.
/// </summary>
public class SearchAlgorithmOptimization
{
    /// <summary>
    /// Searches for an item in a list using a binary search algorithm.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    /// <param name="list">The sorted list to search through.</param>
    /// <param name="item">The item to search for.</param>
    /// <returns>The index of the item in the list, or -1 if not found.</returns>
    public int BinarySearch<T>(List<T> list, T item) where T : IComparable<T>
    {
        int left = 0;
        int right = list.Count - 1;
        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            int comparisonResult = item.CompareTo(list[middle]);

            // If the item is found, return its index.
            if (comparisonResult == 0)
            {
                return middle;
            }
            else if (comparisonResult < 0)
            {
                // If item is smaller, search in the left half.
                right = middle - 1;
            }
            else
            {
                // If item is larger, search in the right half.
                left = middle + 1;
            }
        }

        // If item is not found, return -1.
        return -1;
    }

    /// <summary>
    /// Searches for an item in a list using a linear search algorithm.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    /// <param name="list">The list to search through.</param>
    /// <param name="item">The item to search for.</param>
    /// <returns>The index of the item in the list, or -1 if not found.</returns>
    public int LinearSearch<T>(List<T> list, T item)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(list[i], item))
            {
                return i;
            }
        }

        // If item is not found, return -1.
        return -1;
    }

    /// <summary>
    /// Optimizes the search algorithm based on the size of the list.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    /// <param name="list">The list to search through.</param>
    /// <param name="item">The item to search for.</param>
    /// <returns>The index of the item in the list, or -1 if not found.</returns>
    public int OptimizedSearch<T>(List<T> list, T item) where T : IComparable<T>
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogError("The list is null or empty.");
            return -1;
        }

        // Use binary search for larger lists, as it is more efficient.
        if (list.Count > 10)
        {
            return BinarySearch(list, item);
        }
        else
        {
            // Use linear search for smaller lists, as it's simpler and
            // doesn't require the list to be sorted.
            return LinearSearch(list, item);
        }
    }
}
