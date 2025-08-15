// 代码生成时间: 2025-08-16 02:34:58
using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Handles the transformation of JSON data.
/// </summary>
public class JsonDataTransformer
{
    /// <summary>
    /// Converts JSON data to a specified object type.
    /// </summary>
    /// <typeparam name="T">The type of object to convert the JSON data to.</typeparam>
    /// <param name="jsonData">The JSON data to be converted.</param>
    /// <returns>An object of type T if successful; otherwise, null.</returns>
    public static T ConvertJsonToType<T>(string jsonData) where T : class
    {
        try
        {
            // Use Newtonsoft.Json to deserialize the JSON data.
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
        catch (JsonException ex)
        {
            // Handle JSON parsing errors.
            Debug.LogError($"Error parsing JSON: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Handle any other unexpected exceptions.
            Debug.LogError($"An unexpected error occurred: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Converts an object to JSON string.
    /// </summary>
    /// <param name="data">The object to be converted to JSON string.</param>
    /// <returns>A JSON string if successful; otherwise, null.</returns>
    public static string ConvertObjectToJson(object data)
    {
        try
        {
            // Use Newtonsoft.Json to serialize the object to JSON.
            return JsonConvert.SerializeObject(data);
        }
        catch (Exception ex)
        {
            // Handle serialization errors.
            Debug.LogError($"Error serializing object to JSON: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Validates if the provided string is a valid JSON.
    /// </summary>
    /// <param name="jsonData">The JSON data to be validated.</param>
    /// <returns>True if the JSON data is valid, false otherwise.</returns>
    public static bool ValidateJson(string jsonData)
    {
        try
        {
            // Parse the JSON data to check for validity.
            JToken.Parse(jsonData);
            return true;
        }
        catch (JsonReaderException)
        {
            // If parsing fails, the JSON data is invalid.
            return false;
        }
        catch (Exception ex)
        {
            // Handle any other unexpected exceptions.
            Debug.LogError($"An unexpected error occurred while validating JSON: {ex.Message}");
            return false;
        }
    }
}
