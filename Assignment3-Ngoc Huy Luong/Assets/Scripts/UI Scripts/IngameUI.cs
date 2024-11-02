using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
   public static IngameUI instance;
    private int score;
    public TextMeshProUGUI scoreText;
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
}
