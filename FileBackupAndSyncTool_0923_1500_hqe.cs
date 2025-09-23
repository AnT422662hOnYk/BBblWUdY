// 代码生成时间: 2025-09-23 15:00:11
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

// 文件备份和同步工具类
public class FileBackupAndSyncTool
{
    // 源文件夹路径
    private string sourceFolderPath;
    // 目标文件夹路径
    private string destinationFolderPath;

    // 构造函数
    public FileBackupAndSyncTool(string sourcePath, string destinationPath)
    {
        this.sourceFolderPath = sourcePath;
        this.destinationFolderPath = destinationPath;
    }

    // 同步文件和文件夹
    public void SynchronizeFolders()
    {
        try
        {
            // 获取源文件夹和目标文件夹中的所有文件
            var sourceFiles = Directory.GetFiles(sourceFolderPath);
            var destinationFiles = Directory.GetFiles(destinationFolderPath);

            // 将目标文件夹中的文件名存储到字典中以便于查找
            var destinationFilesDict = new Dictionary<string, string>();
            foreach (var file in destinationFiles)
            {
                destinationFilesDict[Path.GetFileName(file)] = file;
            }

            // 遍历源文件夹中的文件
            foreach (var file in sourceFiles)
            {
                var fileName = Path.GetFileName(file);
                if (!destinationFilesDict.ContainsKey(fileName))
                {
                    // 如果目标文件夹中不存在该文件，则复制文件
                    File.Copy(file, Path.Combine(destinationFolderPath, fileName), true);
                }
                else
                {
                    // 如果文件存在，比较文件大小
                    var sourceFileInfo = new FileInfo(file);
                    var destinationFileInfo = new FileInfo(destinationFilesDict[fileName]);
                    if (sourceFileInfo.Length != destinationFileInfo.Length)
                    {
                        // 如果文件大小不同，则覆盖目标文件夹中的文件
                        File.Copy(file, destinationFilesDict[fileName], true);
                    }
                }
            }

            // 获取源文件夹和目标文件夹中的所有文件夹
            var sourceFolders = Directory.GetDirectories(sourceFolderPath);
            var destinationFolders = Directory.GetDirectories(destinationFolderPath);

            // 同步文件夹
            foreach (var folder in sourceFolders)
            {
                var folderName = Path.GetFileName(folder);
                if (!destinationFolders.Contains(Path.Combine(destinationFolderPath, folderName)))
                {
                    // 如果目标文件夹中不存在该文件夹，则创建文件夹
                    Directory.CreateDirectory(Path.Combine(destinationFolderPath, folderName));
                }
            }

            Debug.Log(" 文件同步完成");
        }
        catch (Exception ex)
        {
            Debug.LogError(" 同步过程中出现错误: " + ex.Message);
        }
    }

    // 获取源文件夹路径
    public string GetSourceFolderPath()
    {
        return sourceFolderPath;
    }

    // 设置源文件夹路径
    public void SetSourceFolderPath(string path)
    {
        sourceFolderPath = path;
    }

    // 获取目标文件夹路径
    public string GetDestinationFolderPath()
    {
        return destinationFolderPath;
    }

    // 设置目标文件夹路径
    public void SetDestinationFolderPath(string path)
    {
        destinationFolderPath = path;
    }
}
