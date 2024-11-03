using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlaying;
    public int lives;

    void Awake()
    {
        instance = this;     
    }


    public void ReduceLive()
    {        
            lives--;
        IngameUI.instance.LiveUI.UpdateLiveUI(lives);
        if (lives <= 0) 
        {
            GameOver();
        }
    }

     void Start()
    {
        IngameUI.instance.LiveUI.UpdateLiveUI(lives);
        IngameUI.instance.gameOver.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        IngameUI.instance.GameOverUI(true);
    }
}
