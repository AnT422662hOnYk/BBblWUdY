// 代码生成时间: 2025-08-11 23:31:25
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AlgorithmOptimizer class that provides search algorithm optimization functionality.
/// </summary>
public class AlgorithmOptimizer
{
    /// <summary>
    /// Searches for an element in a list using an optimized algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to search through.</param>
    /// <param name="target">The target element to search for.</param>
    /// <returns>The index of the target element if found, otherwise -1.</returns>
    public int OptimizedSearch<T>(List<T> list, T target) where T : IComparable<T>
    {
        if (list == null)
        {
            Debug.LogError("List cannot be null");
            return -1;
        }

        if (list.Count == 0)
        {
            Debug.Log("List is empty");
            return -1;
        }

        int left = 0;
        int right = list.Count - 1;
        int index = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = list[mid].CompareTo(target);

            if (comparison == 0)
            {
                index = mid;
                break;
            }
            else if (comparison < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return index;
    }

    /// <summary>
    /// Inserts a new element into a sorted list while maintaining order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The sorted list to insert into.</param>
    /// <param name="element">The element to insert.</param>
    public void InsertIntoSortedList<T>(List<T> list, T element) where T : IComparable<T>
    {
        if (list == null)
        {
            Debug.LogError("List cannot be null");
            return;
        }

        int index = FindInsertionIndex(list, element);
        list.Insert(index, element);
    }

    private int FindInsertionIndex<T>(List<T> list, T element) where T : IComparable<T>
    {
        int left = 0;
        int right = list.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = list[mid].CompareTo(element);

            if (comparison == 0)
            {
                return mid; // Element already exists, can insert just after it.
            }
            else if (comparison < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return left; // Return the index where the element should be inserted.
    }
}
