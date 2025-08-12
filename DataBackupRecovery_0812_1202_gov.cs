// 代码生成时间: 2025-08-12 12:02:57
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Provides functionality to backup and restore data.
/// </summary>
public class DataBackupRecovery : MonoBehaviour
{
    private const string BackupFolder = "./Backups/";
    private const string CurrentDataFile = "./Data/currentData.json";
    private const string BackupFileFormat = "dataBackup_{0}.json";
    private const string LogTag = "DataBackupRecovery";

    /// <summary>
    /// Performs a backup of the current data.
    /// </summary>
    public void BackupData()
    {
        try
        {
            // Check if backup folder exists, if not, create it.
            if (!Directory.Exists(BackupFolder))
            {
                Directory.CreateDirectory(BackupFolder);
            }

            // Generate a unique filename for the backup.
            string backupFilename = string.Format(BackupFileFormat, DateTime.Now.ToString("yyyyMMddHHmmss"));
            string backupFilePath = Path.Combine(BackupFolder, backupFilename);

            // Copy the current data to the backup location.
            File.Copy(CurrentDataFile, backupFilePath);

            Debug.Log(LogTag + ": Data backup created at " + backupFilePath);
        }
        catch (Exception ex)
        {
            Debug.LogError(LogTag + ": An error occurred during backup - " + ex.Message);
        }
    }

    /// <summary>
    /// Restores data from the latest backup.
    /// </summary>
    public void RestoreData()
    {
        try
        {
            // Get the latest backup file.
            string[] backupFiles = Directory.GetFiles(BackupFolder, "*.json");
            if (backupFiles.Length == 0)
            {
                Debug.LogError(LogTag + ": No backups found to restore from.");
                return;
            }

            // Sort by creation time, get the last one.
            Array.Sort(backupFiles, (a, b) => File.GetCreationTime(b).CompareTo(File.GetCreationTime(a)));
            string latestBackupFile = backupFiles[0];

            // Copy the latest backup to the current data file.
            File.Copy(latestBackupFile, CurrentDataFile, true);

            Debug.Log(LogTag + ": Data restored from the latest backup.");
        }
        catch (Exception ex)
        {
            Debug.LogError(LogTag + ": An error occurred during restore - " + ex.Message);
        }
    }
}
