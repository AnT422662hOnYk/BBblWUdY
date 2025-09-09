// 代码生成时间: 2025-09-09 19:17:30
using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

/// <summary>
/// 哈希值计算工具，提供多种哈希算法用于计算字符串的哈希值。
# TODO: 优化性能
/// </summary>
public class HashCalculator
{
    /// <summary>
    /// 计算字符串的MD5哈希值。
    /// </summary>
# FIXME: 处理边界情况
    /// <param name="input">需要计算哈希值的字符串。</param>
# NOTE: 重要实现细节
    /// <returns>字符串的MD5哈希值。</returns>
    public static string CalculateMD5Hash(string input)
    {
        using (var md5 = MD5.Create())
# 增强安全性
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
# 增强安全性
        }
    }

    /// <summary>
    /// 计算字符串的SHA1哈希值。
    /// </summary>
    /// <param name="input">需要计算哈希值的字符串。</param>
    /// <returns>字符串的SHA1哈希值。</returns>
    public static string CalculateSHA1Hash(string input)
# NOTE: 重要实现细节
    {
        using (var sha1 = SHA1.Create())
# TODO: 优化性能
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha1.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
# TODO: 优化性能

    /// <summary>
    /// 计算字符串的SHA256哈希值。
    /// </summary>
    /// <param name="input">需要计算哈希值的字符串。</param>
    /// <returns>字符串的SHA256哈希值。</returns>
    public static string CalculateSHA256Hash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
# 改进用户体验
        }
# 优化算法效率
    }

    /// <summary>
    /// 计算字符串的SHA512哈希值。
    /// </summary>
# 增强安全性
    /// <param name="input">需要计算哈希值的字符串。</param>
    /// <returns>字符串的SHA512哈希值。</returns>
    public static string CalculateSHA512Hash(string input)
    {
# FIXME: 处理边界情况
        using (var sha512 = SHA512.Create())
# 添加错误处理
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha512.ComputeHash(inputBytes);
# 增强安全性
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
# 改进用户体验
        }
    }

    /// <summary>
    /// 演示如何使用哈希值计算工具。
    /// </summary>
    private void Start()
    {
        string input = "Hello, Unity!";
        string md5Hash = CalculateMD5Hash(input);
# 增强安全性
        string sha1Hash = CalculateSHA1Hash(input);
        string sha256Hash = CalculateSHA256Hash(input);
        string sha512Hash = CalculateSHA512Hash(input);

        Debug.Log("MD5 Hash: " + md5Hash);
# TODO: 优化性能
        Debug.Log("SHA1 Hash: " + sha1Hash);
        Debug.Log("SHA256 Hash: " + sha256Hash);
        Debug.Log("SHA512 Hash: " + sha512Hash);
    }
}
