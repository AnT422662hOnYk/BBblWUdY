// 代码生成时间: 2025-08-01 23:20:33
using System;
using System.Net.NetworkInformation;
using UnityEngine;

/// <summary>
/// NetworkConnectionChecker is a Unity script to monitor
/// the network connection status.
/// </summary>
public class NetworkConnectionChecker : MonoBehaviour
{
    private PingReply pingReply;
    private bool isChecking = false;

    private void Start()
    {
        // Check network status on start
        CheckNetworkStatus();
    }

    /// <summary>
    /// Initiates a network status check by sending a ping to a reliable server.
    /// </summary>
    private void CheckNetworkStatus()
    {
        if (isChecking)
        {
            Debug.LogWarning("Network status check is already in progress.");
            return;
        }

        isChecking = true;

        // Use Google's DNS server as a reliable endpoint for the ping
        string host = "8.8.8.8";
        Ping pingSender = new Ping(host);

        try
        {
            pingReply = pingSender.SendPing();
        }
        catch (PingException e)
        {
            Debug.LogError($"Ping failed: {e.Message}");
            isChecking = false;
            return;
        }
    }

    private void Update()
    {
        // Check if the ping has completed and update the network status
        if (isChecking && pingReply != null && pingReply.Status == IPStatus.Success)
        {
            Debug.Log($"Ping successful: {pingReply.RoundtripTime}ms");
            isChecking = false;
        }
        else if (isChecking && pingReply != null && pingReply.Status != IPStatus.Success)
        {
            Debug.LogError($"Ping failed: {pingReply.Status}");
            isChecking = false;
        }
    }

    /// <summary>
    /// Public method to start a network check, can be called from other scripts or UI events.
    /// </summary>
    public void StartNetworkCheck()
    {
        CheckNetworkStatus();
    }
}
