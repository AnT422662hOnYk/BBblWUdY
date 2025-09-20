// 代码生成时间: 2025-09-21 06:58:05
using System;
using System.IO;
using System.IO.Compression;

/// <summary>
/// Provides a simple file decompression tool for Unity projects.
/// </summary>
public class FileDecompressor
{
    /// <summary>
    /// Decompresses a zip file to a specified directory.
    /// </summary>
    /// <param name="sourceFilePath">The path to the zip file to decompress.</param>
    /// <param name="destinationDirectory">The directory to decompress the files into.</param>
    /// <returns>True if the decompression is successful, false otherwise.</returns>
    public static bool DecompressZipFile(string sourceFilePath, string destinationDirectory)
    {
        try
        {
            // Check if the source file exists
            if (!File.Exists(sourceFilePath))
            {
                Debug.LogError("Source file does not exist: " + sourceFilePath);
                return false;
            }

            // Ensure the destination directory exists
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Decompress the zip file
            ZipFile.ExtractToDirectory(sourceFilePath, destinationDirectory);
            Debug.Log("Decompression successful: " + sourceFilePath);
            return true;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during the decompression process
            Debug.LogError("Decompression failed: " + ex.Message);
            return false;
        }
    }
}
