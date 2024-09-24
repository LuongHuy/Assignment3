using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip[] backgroundMusic;
    private AudioSource audioSource;
    private int currentSong = 0;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNext();
    }

    public void PlayNext()
    {
        if (currentSong < backgroundMusic.Length)
        {
            audioSource.clip = backgroundMusic[currentSong];
            audioSource.Play();
            currentSong++;
            StartCoroutine(WaitForMusicEnd());
        }
    }

    private System.Collections.IEnumerator WaitForMusicEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        PlayNext();
    }

}
