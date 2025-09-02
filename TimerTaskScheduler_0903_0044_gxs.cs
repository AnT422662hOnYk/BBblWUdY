// 代码生成时间: 2025-09-03 00:44:57
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// A timer task scheduler for Unity, allowing you to schedule tasks to run at specific times.
/// </summary>
public class TimerTaskScheduler
{
    private List<TimerTask> tasks = new List<TimerTask>();

    /// <summary>
    /// Schedules a task to be executed after a certain delay.
    /// </summary>
    /// <param name="action">The action to be executed.</param>
    /// <param name="delay">The delay before the action is executed.</param>
    public void Schedule(Action action, float delay)
    {
        var timerTask = new TimerTask(action, Time.time + delay);
        tasks.Add(timerTask);
    }

    /// <summary>
    /// Updates the scheduler, checking for tasks that need to be executed.
    /// </summary>
    public void Update()
    {
        float currentTime = Time.time;
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].ShouldExecute(currentTime))
            {
                tasks[i].Execute();
                tasks.RemoveAt(i);
                i--; // Adjust index because the list was modified
            }
        }
    }
}

/// <summary>
/// Represents a single task to be executed at a scheduled time.
/// </summary>
private class TimerTask
{
    private Action action;
    private float executionTime;

    public TimerTask(Action action, float executionTime)
    {
        this.action = action;
        this.executionTime = executionTime;
    }

    public bool ShouldExecute(float currentTime)
    {
        return currentTime >= executionTime;
    }

    public void Execute()
    {
        action?.Invoke();
    }
}
