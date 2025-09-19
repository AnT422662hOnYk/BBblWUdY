// 代码生成时间: 2025-09-19 13:51:03
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// A utility class for encrypting and decrypting passwords using AES encryption.
/// </summary>
public class PasswordEncryptionTool
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    /// <summary>
    /// Initializes a new instance of the PasswordEncryptionTool class.
    /// </summary>
    /// <param name="key">A 32-byte key for AES encryption.</param>
    /// <param name="iv">A 16-byte initialization vector (IV) for AES encryption.</param>
    public PasswordEncryptionTool(byte[] key, byte[] iv)
    {
        if (key == null || key.Length != 32)
            throw new ArgumentException("Key must be 32 bytes long.", nameof(key));

        if (iv == null || iv.Length != 16)
            throw new ArgumentException("IV must be 16 bytes long.", nameof(iv));

        _key = key;
        _iv = iv;
    }

    /// <summary>
    /// Encrypts the provided password using AES encryption.
    /// </summary>
    /// <param name="password">The password to encrypt.</param>
    /// <returns>The encrypted password as a base64-encoded string.</returns>
    public string Encrypt(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(password);
                    }
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    /// <summary>
    /// Decrypts the provided encrypted password using AES encryption.
    /// </summary>
    /// <param name="encryptedPassword">The encrypted password to decrypt.</param>
    /// <returns>The decrypted password.</returns>
    public string Decrypt(string encryptedPassword)
    {
        if (string.IsNullOrEmpty(encryptedPassword))
            throw new ArgumentException("Encrypted password cannot be null or empty.", nameof(encryptedPassword));

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
