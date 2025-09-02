// 代码生成时间: 2025-09-02 18:50:34
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// ConfigManager handles loading, saving, and managing configuration files.
/// </summary>
public class ConfigManager
{
    private const string configFileName = "config.txt"; // The file name for the configuration file.
    private Dictionary<string, string> configData; // Stores the configuration data.

    /// <summary>
    /// Initializes a new instance of the ConfigManager class.
    /// </summary>
    public ConfigManager()
    {
        configData = new Dictionary<string, string>();
        LoadConfig();
    }

    /// <summary>
    /// Loads the configuration from the specified file.
    /// </summary>
    private void LoadConfig()
    {
        try
        {
            if (File.Exists(configFileName))
            {
                string[] lines = File.ReadAllLines(configFileName);
                foreach (string line in lines)
                {
                    string[] keyValue = line.Split('=');
                    if (keyValue.Length == 2)
                    {
                        configData[keyValue[0].Trim()] = keyValue[1].Trim();
                    }
                }
            }
            else
            {
                Debug.LogError("Config file not found.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading config: " + e.Message);
        }
    }

    /// <summary>
    /// Saves the current configuration to the file.
    /// </summary>
    public void SaveConfig()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(configFileName))
            {
                foreach (KeyValuePair<string, string> pair in configData)
                {
                    writer.WriteLine(pair.Key + "=" + pair.Value);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving config: " + e.Message);
        }
    }

    /// <summary>
    /// Gets the value from the configuration for the given key.
    /// </summary>
    /// <param name="key">The key to look up.</param>
    /// <returns>The value associated with the key, or null if not found.</returns>
    public string GetValue(string key)
    {
        if (configData.TryGetValue(key, out string value))
        {
            return value;
        }
        return null;
    }

    /// <summary>
    /// Sets the value in the configuration for the given key.
    /// </summary>
    /// <param name="key">The key to set.</param>
    /// <param name="value">The value to set for the key.</param>
    public void SetValue(string key, string value)
    {
        configData[key] = value;
    }
}
