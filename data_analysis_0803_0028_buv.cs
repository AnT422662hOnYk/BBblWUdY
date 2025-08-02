// 代码生成时间: 2025-08-03 00:28:00
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据统计分析器
/// </summary>
public class DataAnalysis : MonoBehaviour
{
    /// <summary>
    /// 数据列表
    /// </summary>
    private List<double> dataList = new List<double>();

    /// <summary>
    /// 计算平均值
    /// </summary>
    /// <returns>平均值</returns>
    public double CalculateAverage()
    {
        if (dataList.Count == 0)
        {
            Debug.LogError("数据列表为空，无法计算平均值");
            return 0;
        }

        double sum = 0;
        foreach (double value in dataList)
        {
            sum += value;
        }
        return sum / dataList.Count;
    }

    /// <summary>
    /// 计算最大值
    /// </summary>
    /// <returns>最大值</returns>
    public double CalculateMax()
    {
        if (dataList.Count == 0)
        {
            Debug.LogError("数据列表为空，无法计算最大值");
            return 0;
        }

        double max = dataList[0];
        foreach (double value in dataList)
        {
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }

    /// <summary>
    /// 计算最小值
    /// </summary>
    /// <returns>最小值</returns>
    public double CalculateMin()
    {
        if (dataList.Count == 0)
        {
            Debug.LogError("数据列表为空，无法计算最小值");
            return 0;
        }

        double min = dataList[0];
        foreach (double value in dataList)
        {
            if (value < min)
            {
                min = value;
            }
        }
        return min;
    }

    /// <summary>
    /// 添加数据
    /// </summary>
    /// <param name="value">数据值</param>
    public void AddData(double value)
    {
        dataList.Add(value);
    }

    /// <summary>
    /// 清除数据
    /// </summary>
    public void ClearData()
    {
        dataList.Clear();
    }
}
