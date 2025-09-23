// 代码生成时间: 2025-09-23 20:23:34
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPerformanceMonitor : MonoBehaviour
{
    private float updateInterval = 0.5f;
    private float accum = 0;
    private int frames = 0;
    private float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        timeleft = updateInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.renderedFrameCount;
        frames++;

        if (timeleft <= 0)
        {
            float fps = accum / frames;
            float usedMemory = (float)System.GC.GetTotalMemory(false) / 1024f / 1024f;
            float cpuUsage = GetCpuUsage();

            string report = "FPS: " + fps + "
Used Memory: " + usedMemory + " MB
CPU Usage: " + cpuUsage + "%";
            Debug.Log(report);

            timeleft = updateInterval;
            accum = 0;
            frames = 0;
        }
    }

    // Estimates the current CPU usage
    private float GetCpuUsage()
    {
        try
        {
            // This is a simple estimation and may not be accurate for all systems
            float cpuUsage = System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds /
                            (System.Diagnostics.Stopwatch.GetTimestamp() -
                             System.Diagnostics.Process.GetCurrentProcess().StartTime.ToFileTime()) * 100;
            return cpuUsage;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error calculating CPU usage: " + ex.Message);
            return 0f;
        }
    }

    // You can add more methods to monitor other system performance metrics if needed
}
