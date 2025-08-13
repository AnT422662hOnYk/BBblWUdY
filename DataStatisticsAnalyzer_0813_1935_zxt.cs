// 代码生成时间: 2025-08-13 19:35:00
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataAnalysis
{
    /// <summary>
    /// A class to calculate and analyze data statistics.
    /// </summary>
    public class DataStatisticsAnalyzer
    {
        /// <summary>
        /// Calculates the mean of a list of numbers.
        /// </summary>
        /// <param name="data">The list of numbers to calculate the mean from.</param>
        /// <returns>The mean of the list; or null if the list is empty or null.</returns>
        public double? CalculateMean(List<double> data)
        {
            if (data == null || data.Count == 0)
            {
                Debug.LogError("Data list is null or empty.");
                return null;
            }

            double sum = 0;
            foreach (var number in data)
            {
                sum += number;
            }

            return sum / data.Count;
        }

        /// <summary>
        /// Calculates the median of a list of numbers.
        /// </summary>
        /// <param name="data">The list of numbers to calculate the median from.</param>
        /// <returns>The median of the list; or null if the list is empty or null.</returns>
        public double? CalculateMedian(List<double> data)
        {
            if (data == null || data.Count == 0)
            {
                Debug.LogError("Data list is null or empty.");
                return null;
            }

            data.Sort();
            int middle = data.Count / 2;
            if (data.Count % 2 == 0)
            {
                return (data[middle - 1] + data[middle]) / 2;
            }
            else
            {
                return data[middle];
            }
        }

        /// <summary>
        /// Calculates the mode of a list of numbers.
        /// </summary>
        /// <param name="data">The list of numbers to calculate the mode from.</param>
        /// <returns>The mode of the list; or null if there is no mode or if the list is empty or null.</returns>
        public List<double> CalculateMode(List<double> data)
        {
            if (data == null || data.Count == 0)
            {
                Debug.LogError("Data list is null or empty.");
                return null;
            }

            var frequencyDict = new Dictionary<double, int>();
            foreach (var number in data)
            {
                if (frequencyDict.ContainsKey(number))
                {
                    frequencyDict[number]++;
                }
                else
                {
                    frequencyDict[number] = 1;
                }
            }

            double mode = 0;
            int maxFrequency = 0;
            foreach (var kvp in frequencyDict)
            {
                if (kvp.Value > maxFrequency)
                {
                    maxFrequency = kvp.Value;
                    mode = kvp.Key;
                }
            }

            var modeList = new List<double>();
            foreach (var kvp in frequencyDict)
            {
                if (kvp.Value == maxFrequency)
                {
                    modeList.Add(kvp.Key);
                }
            }

            return modeList;
        }

        /// <summary>
        /// Calculates the variance of a list of numbers.
        /// </summary>
        /// <param name="data">The list of numbers to calculate the variance from.</param>
        /// <returns>The variance of the list; or null if the list is empty or null.</returns>
        public double? CalculateVariance(List<double> data)
        {
            if (data == null || data.Count == 0)
            {
                Debug.LogError("Data list is null or empty.");
                return null;
            }

            double mean = CalculateMean(data) ?? 0;
            double variance = 0;
            foreach (var number in data)
            {
                variance += (number - mean) * (number - mean);
            }

            return variance / data.Count;
        }

        /// <summary>
        /// Calculates the standard deviation of a list of numbers.
        /// </summary>
        /// <param name="data">The list of numbers to calculate the standard deviation from.</param>
        /// <returns>The standard deviation of the list; or null if the list is empty or null.</returns>
        public double? CalculateStandardDeviation(List<double> data)
        {
            double? variance = CalculateVariance(data);
            if (variance == null) return null;
            return Math.Sqrt(variance.Value);
        }
    }
}
