using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private float timeElapsed;
    private bool isRunning;

    void Start()
    {
        timeElapsed = 0f;
        isRunning = true; 
        UpdateTimerText(); 
    }

    void Update()
    {
        if (!GameManager.instance.isPlaying)
        {
            return;
        }
        if (isRunning)
        {
            timeElapsed += Time.deltaTime; 
            UpdateTimerText(); 
        }
    }

    void UpdateTimerText()
    {
        int hours = (int)(timeElapsed / 3600);
        int minutes = (int)((timeElapsed % 3600) / 60);
        int seconds = (int)(timeElapsed % 60);
        timerText.text = "Timer: " + (hours < 10 ? "0" + hours : hours.ToString()) + ":" +
                         (minutes < 10 ? "0" + minutes : minutes.ToString()) + ":" +
                         (seconds < 10 ? "0" + seconds : seconds.ToString());
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timeElapsed = 0f;
        UpdateTimerText();
    }
}

