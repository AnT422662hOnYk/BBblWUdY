// 代码生成时间: 2025-08-07 09:30:15
using System;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// JSON数据格式转换器，负责将JSON数据转换为不同的格式。
/// </summary>
public class JsonDataConverter
{
    /// <summary>
    /// 将JSON字符串转换为指定类型的对象。
    /// </summary>
    /// <typeparam name="T">要转换的目标类型。</typeparam>
    /// <param name="jsonString">JSON字符串。</param>
    /// <returns>转换后的对象。</returns>
    public T ConvertJsonToObject<T>(string jsonString)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        catch (JsonException e)
        {
            Debug.LogError("JSON解析错误: " + e.Message);
            return default(T);
        }
    }

    /// <summary>
    /// 将对象转换为JSON字符串。
    /// </summary>
    /// <param name="obj">要转换的对象。</param>
    /// <returns>JSON字符串。</returns>
    public string ConvertObjectToJson(object obj)
    {
        try
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        catch (Exception e)
        {
            Debug.LogError("对象序列化错误: " + e.Message);
            return string.Empty;
        }
    }

    /// <summary>
    /// 将JSON对象转换为字典。
    /// </summary>
    /// <param name="jsonObject">JSON对象。</param>
    /// <returns>字典。</returns>
    public Dictionary<string, object> ConvertJObjectToDictionary(JObject jsonObject)
    {
        if (jsonObject == null)
        {
            Debug.LogError("JSON对象不能为空。");
            return null;
        }

        var dictionary = new Dictionary<string, object>();
        foreach (var property in jsonObject.Properties())
        {
            dictionary.Add(property.Name, property.Value.ToObject<object>());
        }
        return dictionary;
    }

    /// <summary>
    /// 将字典转换为JSON对象。
    /// </summary>
    /// <param name="dictionary">字典。</param>
    /// <returns>JSON对象。</returns>
    public JObject ConvertDictionaryToJObject(Dictionary<string, object> dictionary)
    {
        if (dictionary == null)
        {
            Debug.LogError("字典不能为空。");
            return null;
        }

        return JObject.FromObject(dictionary);
    }
}
