using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacChangeDirection : MonoBehaviour
{
    public Animator animControl;
    public float directionInterval = 1.37f;
    public bool IsDead;
    private PacMovementControl pacControl;
    
    void Start()
    {
        pacControl = GetComponent<PacMovementControl>();
        animControl.SetBool("isDead?", IsDead);
        StartCoroutine(DirectionChange());
    }
    private IEnumerator DirectionChange()
    {
        while (true) 
        {
            if (!IsDead)
            {
                Vector3 currentDirection = pacControl.CurDirections;

                if (currentDirection.x > currentDirection.y)
                {
                    animControl.SetBool("IsWalkLeft", currentDirection.x < 0);
                    animControl.SetBool("IsWalkRight", currentDirection.x > 0);
                }
                else
                {
                    animControl.SetBool("IsWalkUp", currentDirection.y > 0);
                    animControl.SetBool("IsWalkDown", currentDirection.y < 0);
                }
            }
            yield return new WaitForSeconds(directionInterval);
        }      
    }

    
    void Update()
    {
        
    }
}
