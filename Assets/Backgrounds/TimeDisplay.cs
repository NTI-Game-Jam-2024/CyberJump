using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeDisplay : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Text timeText; // Reference to the UI text element to display time

    private DateTime startTime; // Start time of the game

    void Start()
    {
        // Record the start time when the game starts
        startTime = DateTime.Now;
    }

    void Update()
    {
        // Ensure mainCamera is assigned
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not assigned to TimeDisplay script!");
            return;
        }

        // Follow the main camera
        transform.position = mainCamera.transform.position;

        // Display elapsed time since start of the game
        DisplayElapsedTime();
    }

    void DisplayElapsedTime()
    {
        // Calculate the elapsed time since the start of the game
        TimeSpan elapsedTime = DateTime.Now - startTime;

        // Format the elapsed time as HH:MM:SS
        string timeString = string.Format("{0:00}:{1:00}:{2:00}",
                                           elapsedTime.Hours,
                                           elapsedTime.Minutes,
                                           elapsedTime.Seconds);

        // Update the text element with the elapsed time
        if (timeText != null)
        {
            timeText.text = "Time Elapsed: " + timeString;
        }
        else
        {
            Debug.LogError("Text element for time display is not assigned!");
        }
    }
}
