// 代码生成时间: 2025-08-28 13:58:21
// TestDataGenerator.cs
// 这个类用于生成测试数据。
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestDataGenerator
{
    // 生成一系列随机整数
    public List<int> GenerateRandomIntegers(int count, int max)
    {
        List<int> randomNumbers = new List<int>();
        try
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must be greater than zero.");
            }

            if (max <= 0)
            {
                throw new ArgumentException("Max must be greater than zero.");
            }

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                randomNumbers.Add(random.Next(max));
            }

            return randomNumbers;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error generating random integers: " + ex.Message);
            return null;
        }
    }

    // 生成一系列随机浮点数
    public List<float> GenerateRandomFloats(int count, float min, float max)
    {
        List<float> randomFloats = new List<float>();
        try
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must be greater than zero.");
            }

            if (min >= max)
            {
                throw new ArgumentException("Max must be greater than min.");
            }

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                randomFloats.Add((float)random.NextDouble() * (max - min) + min);
            }

            return randomFloats;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error generating random floats: " + ex.Message);
            return null;
        }
    }

    // 生成一系列随机字符串
    public List<string> GenerateRandomStrings(int count, int length)
    {
        List<string> randomStrings = new List<string>();
        try
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must be greater than zero.");
            }

            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than zero.");
            }

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < count; i++)
            {
                char[] value = new char[length];
                for (int j = 0; j < length; j++)
                {
                    value[j] = chars[random.Next(chars.Length)];
                }
                randomStrings.Add(new string(value));
            }

            return randomStrings;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error generating random strings: " + ex.Message);
            return null;
        }
    }
}
