using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMovementControl1 : MonoBehaviour
{
    public Vector3[] targetPoints;
    private Animator animator;
    private AudioSource audioSource;

    public  Vector3 CurDirections { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoveAround());
    }

    private IEnumerator MoveAround()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
