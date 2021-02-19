using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LogDisplay : MonoBehaviour
{
    const float DISPLAYTIME = 5.0f;
    // Maximun number of logs saved
    [SerializeField] private int _MaxLogCount = 20;
    // This variable represents the elapsed time for the log display.
    [SerializeField] private float _logElapsedTime;
    // Area to display logs
    [SerializeField] private Rect _area = new Rect(50, 10, 1000, 400);
    // Variable to put the log string
    private Queue<string> _logMessages = new Queue<string>();
    // This is used to combine the strings in the log
    private StringBuilder _stringBuilder = new StringBuilder();

    // Start is called before the first frame update
    void Start()
    {
        // Register the function to be called when outputting the log in Application.logMessageReceived
        Application.logMessageReceived += LogReceived;
    }

    void Update()
    {
        //_logElapsedTime >= DISPLAYTIME ? _logMessages.Clear() : _logElapsedTime ++;
    }

    // LogReceived is called when the log is output
    void LogReceived(string text, string stackTrace, LogType type)
    {
        // Add logs to Queue
        _logMessages.Enqueue(text);
        // If the number of logs exceeds the upper limit, delete the oldest one
        while(_logMessages.Count > _MaxLogCount)
        {
            _logMessages.Dequeue();
        }
    }

    void OnGUI()
    {
        // Reset the contents of StringBuilder
        _stringBuilder.Length = 0;

        // Combine log strings
        foreach (string s in _logMessages)
        {
            _stringBuilder.Append(s).Append(System.Environment.NewLine);
        }

        // Display on screen
        GUI.Label(_area, _stringBuilder.ToString());
    }
}
