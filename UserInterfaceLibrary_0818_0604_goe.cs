// 代码生成时间: 2025-08-18 06:04:42
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A simple UI component library for Unity.
/// </summary>
# 扩展功能模块
public static class UserInterfaceLibrary
{
# 改进用户体验
    /// <summary>
    /// A dictionary to hold reusable UI components.
    /// </summary>
    private static Dictionary<string, GameObject> reusableComponents = new Dictionary<string, GameObject>();

    /// <summary>
# 改进用户体验
    /// Gets or creates a UI component from the library.
    /// </summary>
    /// <param name="componentName">Name of the UI component.</param>
    /// <param name="prefab">Prefab of the UI component.</param>
# 改进用户体验
    /// <returns>The UI component GameObject.</returns>
    public static GameObject GetOrCreateComponent(string componentName, GameObject prefab)
    {
        if (string.IsNullOrEmpty(componentName))
        {
            Debug.LogError("Component name cannot be null or empty.");
# 增强安全性
            return null;
# 添加错误处理
        }

        if (prefab == null)
        {
            Debug.LogError("Prefab cannot be null.");
            return null;
        }

        if (reusableComponents.ContainsKey(componentName) && reusableComponents[componentName] != null)
        {
            // If the component already exists, get it from the dictionary.
            return reusableComponents[componentName];
        }
        else
# NOTE: 重要实现细节
        {
            // If not, instantiate the prefab and add it to the dictionary.
            GameObject component = Instantiate(prefab);
            reusableComponents.Add(componentName, component);
            return component;
        }
# 扩展功能模块
    }
# NOTE: 重要实现细节

    /// <summary>
    /// Removes a UI component from the library and destroys it.
    /// </summary>
# 添加错误处理
    /// <param name="componentName">Name of the UI component.</param>
    public static void RemoveComponent(string componentName)
    {
        if (string.IsNullOrEmpty(componentName))
        {
            Debug.LogError("Component name cannot be null or empty.");
            return;
        }

        if (reusableComponents.ContainsKey(componentName) && reusableComponents[componentName] != null)
        {
            // Destroy the component and remove it from the dictionary.
            Destroy(reusableComponents[componentName]);
            reusableComponents.Remove(componentName);
        }
        else
        {
            Debug.LogWarning("Component not found in the library.");
        }
    }
}
