// 代码生成时间: 2025-08-22 20:51:02
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// API响应格式化工具
/// </summary>
public class ApiResponseFormatter
{
    /// <summary>
    /// 格式化API响应
    /// </summary>
    /// <param name="response">UnityWebRequest的响应</param>
    /// <returns>格式化后的响应字符串</returns>
    public static string FormatResponse(UnityWebRequest response)
# 扩展功能模块
    {
        try
# TODO: 优化性能
        {
            if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
            {
                // 错误处理
                return "Error: " + response.error;
            }
# 添加错误处理
            else
            {
                // 获取响应数据
                string responseData = response.downloadHandler.text;
                // 格式化响应数据
                return FormatJsonResponse(responseData);
            }
        }
        catch (Exception ex)
# 优化算法效率
        {
# NOTE: 重要实现细节
            // 异常处理
# NOTE: 重要实现细节
            return "Exception: " + ex.Message;
        }
    }

    /// <summary>
    /// 格式化JSON响应
    /// </summary>
# NOTE: 重要实现细节
    /// <param name="jsonData">JSON字符串</param>
    /// <returns>格式化后的JSON字符串</returns>
    private static string FormatJsonResponse(string jsonData)
    {
        try
        {
            // 将JSON字符串转换为字典
            var jsonDict = new Dictionary<string, object>();
            jsonDict = JsonUtility.FromJson<Dictionary<string, object>>(jsonData);

            // 格式化字典为JSON字符串
            string formattedJson = JsonUtility.ToJson(jsonDict, true);
            return formattedJson;
        }
# FIXME: 处理边界情况
        catch (Exception ex)
# 改进用户体验
        {
            // 异常处理
            return "Exception: " + ex.Message;
        }
    }
}
