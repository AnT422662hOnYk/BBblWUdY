// 代码生成时间: 2025-08-27 19:04:44
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// A log file parser tool to process and extract information from log files.
/// </summary>
public class LogParserTool
{
    private readonly string logFilePath;

    /// <summary>
    /// Initializes a new instance of the <see cref="LogParserTool" /> class.
    /// </summary>
    /// <param name="logFilePath">The path to the log file to parse.</param>
    public LogParserTool(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }

    /// <summary>
    /// Parses the log file and returns a list of parsed log entries.
    /// </summary>
    /// <returns>A list of log entries.</returns>
    /// <exception cref="FileNotFoundException">Thrown if the log file is not found.</exception>
    public List<string> ParseLogFile()
    {
        if (!File.Exists(logFilePath))
        {
            throw new FileNotFoundException("Log file not found.", logFilePath);
        }

        List<string> parsedEntries = new List<string>();
        string pattern = @"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\s-\s(\w+)\s-\s(.*)";

        try
        {
            using (StreamReader reader = new StreamReader(logFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Match match = Regex.Match(line, pattern);
                    if (match.Success)
                    {
                        // Extract the date, log level, and message
                        string dateTime = match.Groups[1].Value;
                        string level = match.Groups[2].Value;
                        string message = match.Groups[3].Value;

                        // Format the parsed entry
                        parsedEntries.Add($"[{dateTime}] [{level.PadRight(5)}] {message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while parsing the log file: {ex.Message}");
        }

        return parsedEntries;
    }
}
