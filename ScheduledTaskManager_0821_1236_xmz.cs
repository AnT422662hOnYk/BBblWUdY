// 代码生成时间: 2025-08-21 12:36:14
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaskScheduler
{
    public class ScheduledTask
    {
        public Action Task { get; private set; }
        public DateTime ExecutionTime { get; private set; }

        public ScheduledTask(Action task, DateTime executionTime)
        {
            Task = task;
            ExecutionTime = executionTime;
        }
    }

    public class ScheduledTaskManager : MonoBehaviour
    {
        private List<ScheduledTask> tasks = new List<ScheduledTask>();

        private void Update()
        {
            CheckAndExecuteTasks();
        }

        /// <summary>
        /// Schedules a new task to be executed at the specified time.
        /// </summary>
        /// <param name="task">The task to be executed.</param>
        /// <param name="time">The time at which the task should be executed.</param>
        public void ScheduleTask(Action task, DateTime time)
        {
            if (task == null)
            {
                Debug.LogError("Task cannot be null.");
                return;
            }

            if (time < DateTime.Now)
            {
                Debug.LogError("Scheduled time cannot be in the past.");
                return;
            }

            tasks.Add(new ScheduledTask(task, time));
        }

        /// <summary>
        /// Checks the list of scheduled tasks and executes any that are due.
        /// </summary>
        private void CheckAndExecuteTasks()
        {
            foreach (ScheduledTask task in tasks.ToArray())
            {
                if (task.ExecutionTime <= DateTime.Now)
                {
                    task.Task();
                    tasks.Remove(task);
                }
            }
        }
    }
}
