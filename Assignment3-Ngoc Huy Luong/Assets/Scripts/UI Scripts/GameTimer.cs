using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public float timeElapsed;
    private bool isRunning;
    private bool isCountdown;

    void Start()
    {
        timeElapsed = 0f;       
        UpdateTimerText();
        timerText.gameObject.SetActive(false);
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
        else if (isCountdown)
        {
            timeElapsed -= Time.deltaTime;
            UpdateTimerText();
            if(timeElapsed < 0f)
            {
                isCountdown = false;
                timerText.gameObject.SetActive(false);
            }
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

    public void Startcountdown(float countdowntime)
    {
        timeElapsed = countdowntime;
        isCountdown = true;
        timerText.gameObject.SetActive(true);
    }

    public void StartTimer()
    {
        isRunning = true;
        timerText.gameObject.SetActive(true);
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

