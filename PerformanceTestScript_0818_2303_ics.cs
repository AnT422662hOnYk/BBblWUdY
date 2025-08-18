// 代码生成时间: 2025-08-18 23:03:46
 * Purpose:
 * This script is designed to perform performance testing within a Unity environment.
 * It allows for the execution of various test scenarios and measures their performance.
 *
 * Usage:
 * Attach this script to a GameObject in your Unity scene and call the StartTest method to begin testing.
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerformanceTestScript : MonoBehaviour
{
    private enum TestState
    {
        NotStarted,
        Running,
        Completed
    }

    [SerializeField] private List<GameObject> testObjects; // A list of game objects to instantiate for testing
    [SerializeField] private int numberOfTests = 100; // The number of tests to perform
    private TestState currentState = TestState.NotStarted;
    private int testsCompleted = 0;
    private float testStartTime;
    private float totalElapsedTime = 0f;
    private bool testRunning = false;

    // Starts the performance test
    public void StartTest()
    {
        if (currentState != TestState.NotStarted)
        {
            Debug.LogError("Test can only be started when not already running or completed.");
            return;
        }

        currentState = TestState.Running;
        testRunning = true;
        testsCompleted = 0;
        totalElapsedTime = 0f;
        Debug.Log("Performance test started.");

        // Start the first test iteration
        StartTestIteration();
    }

    private void StartTestIteration()
    {
        if (testRunning && testsCompleted < numberOfTests)
        {
            testStartTime = Time.realtimeSinceStartup;
            foreach (var testObject in testObjects)
            {
                Instantiate(testObject);
            }
            testsCompleted++;
        }
        else
        {
            EndTest();
        }
    }

    private void EndTest()
    {
        currentState = TestState.Completed;
        testRunning = false;
        float averageTime = totalElapsedTime / numberOfTests;
        Debug.Log($"Performance test completed. Average time per test: {averageTime} seconds.");
    }

    // Call this method to update the elapsed time for the current test iteration
    private void Update()
    {
        if (testRunning)
        {
            float elapsedTime = Time.realtimeSinceStartup - testStartTime;
            totalElapsedTime += elapsedTime;
            DestroyAllTestObjects();
            StartTestIteration();
        }
    }

    // Destroys all instantiated test objects to prepare for the next test iteration
    private void DestroyAllTestObjects()
    {
        foreach (var testObject in testObjects)
        {
            Destroy(testObject);
        }
    }
}
