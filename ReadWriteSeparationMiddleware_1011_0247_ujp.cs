// 代码生成时间: 2025-10-11 02:47:25
using System;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// A Unity middleware for read-write separation.
/// </summary>
public class ReadWriteSeparationMiddleware
{
    private UnityWebRequest _readRequest;
    private UnityWebRequest _writeRequest;
    private string _readUrl;
    private string _writeUrl;

    /// <summary>
    /// Initializes a new instance of the middleware with read and write URLs.
    /// </summary>
    /// <param name="readUrl">The URL for read operations.</param>
    /// <param name="writeUrl">The URL for write operations.</param>
    public ReadWriteSeparationMiddleware(string readUrl, string writeUrl)
    {
        _readUrl = readUrl;
        _writeUrl = writeUrl;
    }

    /// <summary>
    /// Performs a read operation.
    /// </summary>
    /// <param name="data">The data associated with the read operation.</param>
    /// <returns>The result of the read operation.</returns>
    public IEnumerator Read(string data)
    {
        try
        {
            _readRequest = UnityWebRequest.Get(_readUrl + data);
            yield return _readRequest.SendWebRequest();

            if (_readRequest.result == UnityWebRequest.Result.ConnectionError || _readRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Read operation failed: " + _readRequest.error);
                yield break;
            }

            // Process the read result here.
            string result = _readRequest.downloadHandler.text;
            Debug.Log("Read result: " + result);
        }
        catch (Exception e)
        {
            Debug.LogError("Exception in Read: " + e.Message);
        }
    }

    /// <summary>
    /// Performs a write operation.
    /// </summary>
    /// <param name="data">The data associated with the write operation.</param>
    /// <returns>The result of the write operation.</returns>
    public IEnumerator Write(string data)
    {
        try
        {
            _writeRequest = UnityWebRequest.Post(_writeUrl, data);
            yield return _writeRequest.SendWebRequest();

            if (_writeRequest.result == UnityWebRequest.Result.ConnectionError || _writeRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Write operation failed: " + _writeRequest.error);
                yield break;
            }

            // Process the write result here.
            string result = _writeRequest.downloadHandler.text;
            Debug.Log("Write result: " + result);
        }
        catch (Exception e)
        {
            Debug.LogError("Exception in Write: " + e.Message);
        }
    }

    /// <summary>
    /// Cleans up the middleware by disposing of the UnityWebRequest instances.
    /// </summary>
    public void Cleanup()
    {
        if (_readRequest != null)
        {
            _readRequest.Dispose();
        }

        if (_writeRequest != null)
        {
            _writeRequest.Dispose();
        }
    }
}
