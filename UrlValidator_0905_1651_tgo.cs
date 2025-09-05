// 代码生成时间: 2025-09-05 16:51:03
using System;
using System.Net;
using UnityEngine;

/// <summary>
/// A class used to validate the validity of a URL.
/// </summary>
public class UrlValidator
{
    /// <summary>
    /// Checks if the given URL is valid.
    /// </summary>
    /// <param name="url">The URL to validate.</param>
    /// <returns>True if the URL is valid, otherwise false.</returns>
    public bool IsValidUrl(string url)
    {
        try
        {
            Uri uriResult;
            // Attempt to create a Uri object from the url string.
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                         (uriResult.Scheme == Uri.UriSchemeHttp ||
                          uriResult.Scheme == Uri.UriSchemeHttps);

            if (result)
            {
                // Check if the host is not a loopback address.
                IPAddress ip = IPAddress.Parse(uriResult.Host);
                if (ip.IsLoopback)
                {
                    Debug.LogError("Loopback addresses are not valid for URL validation.");
                    return false;
                }
            }

            return result;
        }
        catch (UriFormatException)
        {
            Debug.LogError("The URL is not in a correct format.");
            return false;
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred while validating the URL: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// A method to test the URL validation functionality.
    /// </summary>
    public void TestUrlValidation()
    {
        // Example URL for testing.
        string testUrl = "https://www.example.com";
        if (IsValidUrl(testUrl))
        {
            Debug.Log("The URL is valid.");
        }
        else
        {
            Debug.Log("The URL is invalid.");
        }
    }
}
