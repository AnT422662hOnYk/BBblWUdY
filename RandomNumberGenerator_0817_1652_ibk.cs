// 代码生成时间: 2025-08-17 16:52:16
// <summary>
// A simple C# class for generating random numbers using Unity's Random.Range function.
// </summary>

using System;
using UnityEngine;

public class RandomNumberGenerator
{
    // <summary>
    // Generates a random integer within a specified range.
    // </summary>
    // <param name="minValue">The minimum value of the range (inclusive).</param>
    // <param name="maxValue">The maximum value of the range (exclusive).</param>
    // <returns>A random integer between minValue and maxValue.</returns>
    public int GenerateRandomInt(int minValue, int maxValue)
    {
        if (maxValue <= minValue)
        {
            Debug.LogError("Max value must be greater than min value.");
            throw new ArgumentException("Max value must be greater than min value.");
        }

        return UnityEngine.Random.Range(minValue, maxValue);
    }

    // <summary>
    // Generates a random float within a specified range.
    // </summary>
    // <param name="minValue">The minimum value of the range (inclusive).</param>
    // <param name="maxValue">The maximum value of the range (inclusive).</param>
    // <returns>A random float between minValue and maxValue.</returns>
    public float GenerateRandomFloat(float minValue, float maxValue)
    {
        if (maxValue <= minValue)
        {
            Debug.LogError("Max value must be greater than min value.");
            throw new ArgumentException("Max value must be greater than min value.");
        }

        return UnityEngine.Random.Range(minValue, maxValue);
    }
}
