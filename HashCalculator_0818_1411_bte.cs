// 代码生成时间: 2025-08-18 14:11:13
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// A tool to calculate hash values for given data.
/// </summary>
public class HashCalculator
{
    /// <summary>
    /// Calculates the hash value for the provided data using the specified hash algorithm.
    /// </summary>
    /// <param name="data">The data to be hashed.</param>
    /// <param name="hashAlgorithm">The hash algorithm to use (e.g., SHA256).</param>
    /// <returns>The hash value as a hexadecimal string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when data or hashAlgorithm is null.</exception>
    public string CalculateHash(string data, HashAlgorithm hashAlgorithm)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data), "Data cannot be null.");
        }

        if (hashAlgorithm == null)
        {
            throw new ArgumentNullException(nameof(hashAlgorithm), "Hash algorithm cannot be null.");
        }

        using (hashAlgorithm)
        {
            // Compute the hash value
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = hashAlgorithm.ComputeHash(dataBytes);
            // Convert the hash bytes to a hexadecimal string
            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashBuilder.Append(b.ToString("x2"));
            }
            return hashBuilder.ToString();
        }
    }

    /// <summary>
    /// Calculates the SHA256 hash value for the provided data.
    /// </summary>
    /// <param name="data">The data to be hashed.</param>
    /// <returns>The SHA256 hash value as a hexadecimal string.</returns>
    public string CalculateSHA256Hash(string data)
    {
        return CalculateHash(data, SHA256.Create());
    }
}
