// 代码生成时间: 2025-08-25 16:30:12
// <copyright file="SecurityAuditLogger.cs" company="YourCompany">
//    Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Represents a security audit logger in the Unity framework.
/// </summary>
public class SecurityAuditLogger : MonoBehaviour
{
    private const string LogFilePath = "SecurityAuditLog.txt";
    private static readonly object LogLock = new object();

    /// <summary>
    /// Logs a security audit message to the log file.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogSecurityAudit(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            Debug.LogError("SecurityAuditLogger: Log message cannot be null or empty.");
            return;
        }

        lock (LogLock)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] {message}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"SecurityAuditLogger: Failed to write to log file. {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Logs a security audit message to the log file with an error level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="level">The error level of the message.</param>
    public void LogSecurityAudit(string message, LogLevel level)
    {
        string logMessage = $"[{DateTime.Now}] [Level: {level}] {message}";
        LogSecurityAudit(logMessage);
    }

    /// <summary>
    /// Represents the log levels for security audit messages.
    /// </summary>
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}
