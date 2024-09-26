using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AudioManager1 : MonoBehaviour
{
    public AudioClip[] Musics;

    private int curSong = 0;
    private AudioSource bgm;
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        NextSong();
    }

    public void NextSong()
    {
        bgm.clip = Musics[curSong];
        bgm.Play();
        curSong++;
        StartCoroutine(WaitSongEnd());
    }
    private IEnumerator WaitSongEnd()
    {
        yield return new WaitForSeconds(bgm.clip.length);
        NextSong();
    }   
}
