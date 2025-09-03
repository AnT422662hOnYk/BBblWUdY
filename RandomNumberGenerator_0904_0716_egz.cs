// 代码生成时间: 2025-09-04 07:16:49
using System;
using UnityEngine;

/// <summary>
/// RandomNumberGenerator provides functionality to generate random numbers within a specified range.
/// </summary>
public class RandomNumberGenerator
{
    /// <summary>
    /// Generates a random number between min and max (inclusive).
    /// </summary>
    /// <param name="min">The minimum value of the random number.</param>
    /// <param name="max">The maximum value of the random number.</param>
    /// <returns>A random integer between min and max.</returns>
    public static int GenerateRandomNumber(int min, int max)
    {
        if (min > max)
        {
            // Swap min and max if the order is incorrect
            int temp = min;
            min = max;
            max = temp;
        }
        
        // Generate a random number between min and max
        return UnityEngine.Random.Range(min, max + 1);
    }

    /// <summary>
    /// Main method for demonstration purposes.
    /// </summary>
    static void Main(string[] args)
    {
        try
        {
            // Generate random numbers within a range of 1 to 100
            int randomNumber = RandomNumberGenerator.GenerateRandomNumber(1, 100);
            Console.WriteLine("Random Number: " + randomNumber);
        }
        catch (Exception ex)
        {
            // Log or handle any exceptions that may occur
            Debug.LogError("An error occurred: " + ex.Message);
        }
    }
}