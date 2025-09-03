// 代码生成时间: 2025-09-03 16:41:58
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// A utility class for batch renaming files in Unity.
/// </summary>
public class BatchRenameTool
{
    /// <summary>
    /// The directory path where the files are located.
    /// </summary>
    private string directoryPath;

    /// <summary>
    /// Initializes a new instance of the BatchRenameTool class.
    /// </summary>
    /// <param name="directoryPath">The directory path where the files are located.</param>
    public BatchRenameTool(string directoryPath)
    {
        this.directoryPath = directoryPath;
    }

    /// <summary>
    /// Renames files in the directory based on a specified pattern.
    /// </summary>
    /// <param name="oldPattern">The old file name pattern to match.</param>
    /// <param name="newPattern">The new file name pattern to replace with.</param>
    /// <param name="startIndex">The starting index for renaming.</param>
    public void RenameFiles(string oldPattern, string newPattern, int startIndex = 1)
    {
        // Get all files in the directory that match the old pattern
        IEnumerable<string> filesToRename = Directory.GetFiles(directoryPath, oldPattern)
            .Where(file => Path.GetFileName(file).StartsWith(oldPattern));

        try
        {
            foreach (string file in filesToRename)
            {
                // Generate the new file name based on the new pattern
                string newFileName = string.Format(newPattern, startIndex);
                string newFilePath = Path.Combine(directoryPath, newFileName);

                // Rename the file
                File.Move(file, newFilePath);

                // Increment the start index for the next file
                startIndex++;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error occurred while renaming files: " + ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Gets or sets the directory path where the files are located.
    /// </summary>
    public string DirectoryPath
    {
        get { return directoryPath; }
        set { directoryPath = value; }
    }
}
