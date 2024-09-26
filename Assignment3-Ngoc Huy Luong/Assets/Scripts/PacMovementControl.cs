using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMovementControl : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3[] targets;
    private Animator animator;
    private AudioSource audioSource;

    public Vector3 CurDirections { get;private set; }

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
            Vector3 end = targets[targetIndex];
            float jourLength = Vector3.Distance(start, end);
            float jourProgress = 0f;

            CurDirections = (end - start);
            if (Mathf.Abs(CurDirections.x) > Mathf.Abs(CurDirections.y))
            {
                animator.SetBool("IsWalkLeft", CurDirections.x < 0);
                animator.SetBool("IsWalkRight", CurDirections.x > 0);
            }
            else
            {
                animator.SetBool("IsWalkUp", CurDirections.y >0);
                animator.SetBool("IsWalkDown", CurDirections.y < 0);
            }
            animator.SetBool("IsWalk", true);
            PlayWalkAudio();

            while(jourProgress < jourLength) 
            {
                jourProgress += moveSpeed * Time.deltaTime;
                float fraction = jourProgress / jourLength;
                transform.position = Vector3.Lerp(start, end, fraction);
                yield return null;
            }
            targetIndex = (targetIndex + 1) % targets.Length;

            animator.SetBool("IsWalk", false);
            StopWalkAudio();
            animator.SetBool("IsWalkLeft", false);
            animator.SetBool("IsWalkRight", false);
            animator.SetBool("IsWalkUp", false);
            animator.SetBool("IsWalkDown", false);

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void PlayWalkAudio()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(RepeatAudio());
        }
    }    
   
    private void StopWalkAudio()
    {
        audioSource.Stop();
    }

    private IEnumerator RepeatAudio()
    {
        while(audioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
            if(audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(GetComponent<AudioSource>().clip);
            }
        }
    }
}
