// 代码生成时间: 2025-09-24 01:07:36
 * It includes error handling and is designed with maintainability and
 * extensibility in mind.
 */
using System;
using System.IO;
using UnityEngine;
# 改进用户体验
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageResizer : MonoBehaviour
{
# 增强安全性
    /*
    * The directory path where the images are located.
    */
    public string sourceDirectory = "path/to/source/images";

    /*
    * The target directory path where resized images will be saved.
# 增强安全性
    */
# 改进用户体验
    public string targetDirectory = "path/to/target/images";
# FIXME: 处理边界情况

    /*
    * The desired width after resizing.
    */
    public int targetWidth;

    /*
    * The desired height after resizing.
# TODO: 优化性能
    */
    public int targetHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the directories exist
        if (!Directory.Exists(sourceDirectory))
# 优化算法效率
        {
            Debug.LogError("Source directory does not exist.");
            return;
        }
        
        if (!Directory.Exists(targetDirectory))
        {
            Directory.CreateDirectory(targetDirectory);
        }
        
        // Get all image files from the source directory
        string[] imageFiles = Directory.GetFiles(sourceDirectory, "*.png");
        foreach (string file in imageFiles)
        {
            ResizeImage(file);
# NOTE: 重要实现细节
        }
    }

    /*
    * Resizes an individual image file.
    *
    * @param filePath The path to the image file to be resized.
    */
    private void ResizeImage(string filePath)
    {
        try
# 优化算法效率
        {
            Texture2D texture = new Texture2D(1, 1);
# 增强安全性
            texture.LoadImage(File.ReadAllBytes(filePath));
# 优化算法效率
            Texture2D resizedTexture = new Texture2D(targetWidth, targetHeight);
            
            // Resize the texture
# NOTE: 重要实现细节
            for (int x = 0; x < resizedTexture.width; x++)
            {
# NOTE: 重要实现细节
                for (int y = 0; y < resizedTexture.height; y++)
                {
# TODO: 优化性能
                    Color color = texture.GetPixelBilinear(((float)x / resizedTexture.width) * texture.width,
                                                        ((float)y / resizedTexture.height) * texture.height);
                    resizedTexture.SetPixel(x, y, color);
                }
            }
            
            // Apply changes to the resized texture
            resizedTexture.Apply();
            
            // Save the resized texture to the target directory
            string fileName = Path.GetFileName(filePath);
            string targetPath = Path.Combine(targetDirectory, fileName);
            File.WriteAllBytes(targetPath, resizedTexture.EncodeToPNG());
        }
        catch (Exception e)
        {
            Debug.LogError($"Error resizing image at path {filePath}: {e.Message}");
        }
    }
}
