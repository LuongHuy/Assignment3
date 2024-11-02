using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacChangeDirection : MonoBehaviour
{
    public Animator animControl;
    public bool IsDead;

    
    void Start()
    {
        animControl.SetBool("isDead?", IsDead);
        StartCoroutine(DirectionChange());
    }
    private IEnumerator DirectionChange()
    {
        while (true) 
        {
            if (!IsDead)
            {
                animControl.SetBool("IsWalkLeft", false);
                animControl.SetBool("IsWalkRight", false);
                animControl.SetBool("IsWalkUp", false);
                animControl.SetBool("IsWalkDown", false);

                if (Input.GetKeyDown(KeyCode.A))
                {
                    animControl.SetBool("IsWalkLeft", true);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    animControl.SetBool("IsWalkRight", true);
                }                         
                else if (Input.GetKeyDown(KeyCode.W))
                {
                animControl.SetBool("IsWalkUp", true);
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    animControl.SetBool("IsWalkDown", true);
                }                              
            }
            yield return null;
        }      
    }

    
    void Update()
    {
        
    }
}
