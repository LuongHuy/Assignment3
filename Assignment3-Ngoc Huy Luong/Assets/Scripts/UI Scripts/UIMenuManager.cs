using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI Timer;
    
    void Start()
    {
       highScore.text = "Best Score: " + PlayerPrefs.GetInt("highscore", 0);
        Timer.text = GetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string GetTimer()
    {
        float timeElapsed = PlayerPrefs.GetFloat("Timer", 0);
        int hours = (int)(timeElapsed / 3600);
        int minutes = (int)((timeElapsed % 3600) / 60);
        int seconds = (int)(timeElapsed % 60);
        return "Timer: " + (hours < 10 ? "0" + hours : hours.ToString()) + ":" +
                         (minutes < 10 ? "0" + minutes : minutes.ToString()) + ":" +
                         (seconds < 10 ? "0" + seconds : seconds.ToString());
    }
}
