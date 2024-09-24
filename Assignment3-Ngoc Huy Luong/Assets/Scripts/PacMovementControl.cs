using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacMovementControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector3[] targetPoints;
    private Animator animator;
    //public AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
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

            animator.SetBool("IsWalk", true);
            //audioSource.Play();

            while (journeyProgress < journeyLength)
            {
                journeyProgress += moveSpeed * Time.deltaTime;
                float fractionOfJourney = journeyProgress / journeyLength;
                transform.position = Vector3.Lerp(start, end, fractionOfJourney);
                yield return null;
            }
            targetIndex = (targetIndex + 1) % targetPoints.Length;

            animator.SetBool("IsWalk", false);
           // audioSource.Stop();
            yield return new WaitForSeconds(0.1f);

        }

        void Update()
        {

        }
    }
}

