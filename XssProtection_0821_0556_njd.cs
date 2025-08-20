// 代码生成时间: 2025-08-21 05:56:48
using System;
using System.Text.RegularExpressions;

/// <summary>
/// This class is responsible for providing XSS (Cross-Site Scripting) protection.
/// It uses regular expressions to sanitize user input and prevent XSS attacks.
/// </summary>
public static class XssProtection
{
    /// <summary>
    /// Sanitizes the input to prevent XSS attacks.
    /// </summary>
    /// <param name="input">The user input to be sanitized.</param>
    /// <returns>The sanitized input.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
    public static string SanitizeInput(string input)
# TODO: 优化性能
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Input cannot be null.");
        }

        // Remove script tags and event handlers
        input = Regex.Replace(input, "<[^>]*>", "", RegexOptions.IgnoreCase);
        input = Regex.Replace(input, @