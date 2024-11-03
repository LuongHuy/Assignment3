using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
   public static IngameUI instance;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameTimer scare;
    public GameTimer Timer;
    public LiveUI LiveUI;
    public Image Exit;
    public GameObject gameOver;
    
    
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = "Score: " + score;
    }
   public void ScoreUpdate(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
    public void ToggleUI (bool isShow)
    {
        scoreText.gameObject.SetActive(isShow);
        scare.gameObject.SetActive(isShow);
        LiveUI.gameObject.SetActive(isShow);
        Timer.gameObject.SetActive(isShow);
    }
    public void GameOverUI(bool isShow)
    {
        UpdateHighScore();
        GameManager.instance.isPlaying = false;
        ToggleUI(false);
        gameOver.SetActive(true);
        Exit.gameObject.SetActive(false);       
    }
   
    public void UpdateHighScore()
    {
        int latestHighScore = PlayerPrefs.GetInt("highscore", 0);
        if (score > latestHighScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.SetFloat("Timer", Timer.timeElapsed);
        }
    }
}
