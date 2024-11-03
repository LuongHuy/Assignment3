using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour
{
    public Image[] liveSprite;
    public Sprite enableLive;
    public Sprite disableLive;

    public void UpdateLiveUI(int lives)
    {
        for (int i = 0; i < liveSprite.Length; i++) 
        { 
            if (i <= lives-1)
            {
                liveSprite[i].sprite = enableLive;
            }
            else
            {
                liveSprite[i].sprite = disableLive;
            }
        }
    }
}
