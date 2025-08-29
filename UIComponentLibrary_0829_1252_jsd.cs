// 代码生成时间: 2025-08-29 12:52:49
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// A library of user interface components for Unity.
/// </summary>
public class UIComponentLibrary
{
    /// <summary>
    /// A dictionary to hold reference to UI components.
    /// </summary>
    private Dictionary<string, GameObject> components = new Dictionary<string, GameObject>();

    /// <summary>
    /// Adds a UI component to the library.
    /// </summary>
    /// <param name="name">The name of the component.</param>
    /// <param name="component">The game object representing the UI component.</param>
    public void AddComponent(string name, GameObject component)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("Component name cannot be null or empty.");
            return;
        }

        if (component == null)
        {
            Debug.LogError("UI component cannot be null.");
            return;
        }

        if (components.ContainsKey(name))
        {
            Debug.LogWarning("A component with the same name already exists. Overwriting...");
        }

        components[name] = component;
    }

    /// <summary>
    /// Retrieves a UI component from the library.
    /// </summary>
    /// <param name="name">The name of the component to retrieve.</param>
    /// <returns>The game object representing the UI component or null if not found.</returns>
    public GameObject GetComponent(string name)
    {
        if (components.TryGetValue(name, out GameObject component))
        {
            return component;
        }
        else
        {
            Debug.LogError("Component with name ' " + name + "' not found in the library.");
            return null;
        }
    }

    /// <summary>
    /// Removes a UI component from the library.
    /// </summary>
    /// <param name="name">The name of the component to remove.</param>
    public void RemoveComponent(string name)
    {
        if (components.ContainsKey(name) && components.Remove(name))
        {
            Debug.Log("Component removed successfully.");
        }
        else
        {
            Debug.LogError("Component with name ' " + name + "' not found in the library.");
        }
    }

    /// <summary>
    /// Clears all UI components from the library.
    /// </summary>
    public void ClearComponents()
    {
        components.Clear();
        Debug.Log("All components have been cleared from the library.");
    }
}
