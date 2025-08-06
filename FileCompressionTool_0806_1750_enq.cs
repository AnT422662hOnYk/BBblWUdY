// 代码生成时间: 2025-08-06 17:50:14
// <copyright file="FileCompressionTool.cs" company="YourCompany">
 // Copyright (c) YourCompany. All rights reserved.
 // </copyright>

using System;
using System.IO;
using System.IO.Compression;

namespace YourNamespace
{
    /// <summary>
    /// A utility class to handle file compression and decompression.
    /// </summary>
    public class FileCompressionTool
    {
        /// <summary>
        /// Compresses a specified directory into a zip file.
        /// </summary>
        /// <param name="sourceDirectory">The directory to compress.</param>
        /// <param name="destinationArchive">The path of the resulting zip file.</param>
        public static void CompressDirectory(string sourceDirectory, string destinationArchive)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException($"Source directory not found: {sourceDirectory}");
            }

            try
            {
                ZipFile.CreateFromDirectory(sourceDirectory, destinationArchive);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error occurred while compressing: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Decompresses a zip file into a specified directory.
        /// </summary>
        /// <param name="sourceArchive">The zip file to decompress.</param>
        /// <param name="destinationDirectory">The directory where the contents will be extracted.</param>
        public static void DecompressArchive(string sourceArchive, string destinationDirectory)
        {
            if (!File.Exists(sourceArchive))
            {
                throw new FileNotFoundException($"Source archive not found: {sourceArchive}");
            }

            try
            {
                ZipFile.ExtractToDirectory(sourceArchive, destinationDirectory);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error occurred while decompressing: {ex.Message}", ex);
            }
        }
    }
}
