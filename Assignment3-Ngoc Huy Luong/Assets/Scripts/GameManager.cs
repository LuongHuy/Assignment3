using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        IngameUI.instance.Timer.StartTimer();
    }

    public void GameOver()
    {
        IngameUI.instance.GameOverUI(true);
        StartCoroutine(DelayToMainMenu());
    }

    public IEnumerator DelayToMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(0);
    }
}
