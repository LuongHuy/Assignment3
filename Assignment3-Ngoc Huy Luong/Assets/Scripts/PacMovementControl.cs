using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacMovementControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector3[] targetPoints;
    private Animator animator;
    private AudioSource audioSource;

    public Vector3 CurrentDirection { get; private set; }   
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoveAround());
    }

    private IEnumerator MoveAround()
    {
        int targetIndex = 0;

        while (true)
        {
            Vector3 start = transform.position;
            Vector3 end = targetPoints[targetIndex];
            float journeyLength = Vector3.Distance(start, end);
            float journeyProgress = 0f;

            CurrentDirection = (end - start).normalized;

            if (Mathf.Abs(CurrentDirection.x) > Mathf.Abs(CurrentDirection.y))
            {
                animator.SetBool("IsWalkLeft", CurrentDirection.x < 0);
                animator.SetBool("IsWalkRight", CurrentDirection.x > 0);
            }
            else
            {
                animator.SetBool("IsWalkUp", CurrentDirection.y > 0);
                animator.SetBool("IsWalkDown", CurrentDirection.y < 0);
            }

            animator.SetBool("IsWalk", true);
            PlayWalkingAudio();


            while (journeyProgress < journeyLength)
            {
                journeyProgress += moveSpeed * Time.deltaTime;
                float fraction = journeyProgress / journeyLength;
                transform.position = Vector3.Lerp(start, end, fraction);
                yield return null;
            }
            targetIndex = (targetIndex + 1) % targetPoints.Length;

            animator.SetBool("IsWalk", false);
            StopWalkingAudio();

            animator.SetBool("IsWalk", false);
            animator.SetBool("IsWalkLeft", false);
            animator.SetBool("IsWalkRight", false);
            animator.SetBool("IsWalkUp", false);
            animator.SetBool("IsWalkDown", false);

            yield return new WaitForSeconds(0.1f);

        }
    }

    private void PlayWalkingAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(RepeatAudio()); 
        }
    }
    private void StopWalkingAudio()
    {
        audioSource.Stop(); 
    }

    private IEnumerator RepeatAudio()
    {
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
            if (audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }
}

