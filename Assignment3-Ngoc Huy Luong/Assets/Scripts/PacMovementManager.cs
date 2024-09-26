using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacMovementManager : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3[] targetPoints;
    private Animator animator;
    private AudioSource audioSource;

    public Vector3 distanceVec { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MovingPac());
    }

    private IEnumerator MovingPac()
    {
        int targetNo = 0;
        while (true)
        {
            Vector3 startPoint = transform.position;
            Vector3 endPoint = targetPoints[targetNo];
            float curPos = 0f;
            float distance = Vector3.Distance(startPoint, endPoint);
            distanceVec = (endPoint - startPoint);

            if(Mathf.Abs(distanceVec.x) > Mathf.Abs(distanceVec.y))
            {
                animator.SetBool("IsWalkLeft", distanceVec.x < 0);
                animator.SetBool("IsWalkRight", distanceVec.x > 0);

            }
            else
            {
                
                animator.SetBool("IsWalkUp", distanceVec.y > 0);
                animator.SetBool("IsWalkDown", distanceVec.y < 0);
            }

            animator.SetBool("IsWalk", true);
            PlayAudio();

            while(curPos < distance) 
            {
                curPos += moveSpeed * Time.deltaTime;
                float fraction = curPos / distance;
                transform.position = Vector3.Lerp(startPoint, endPoint, fraction);
                yield return null;
            }
            targetNo = (targetNo +1) % targetPoints.Length;
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("IsWalkLeft", false);
            animator.SetBool("IsWalkRight", false);
            animator.SetBool("IsWalkUp", false);
            animator.SetBool("IsWalkDown", false);
        }
    }

    private void PlayAudio()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(RepeatAudio());
        }
    }

    private IEnumerator RepeatAudio()
    {
        while(audioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
            if(audioSource.isPlaying )
            {
                audioSource.PlayOneShot(GetComponent<AudioSource>().clip);
            }
        }
    }
    void Update()
    {
        
    }
}
