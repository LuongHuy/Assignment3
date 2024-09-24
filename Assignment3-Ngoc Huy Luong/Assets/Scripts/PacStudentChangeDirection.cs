using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;

public class PacStudentChangeDirection : MonoBehaviour
{
    public Animator animatorController;
    public bool IsDead;
    private float changeDirectionInterval = 1.38f;
    private PacMovementControl pacMovementControl;

    void Start()
    {
        pacMovementControl = GetComponent<PacMovementControl>(); 
        animatorController.SetBool("isDead?", IsDead);
        StartCoroutine(ChangeDirectionCoroutine());
    }

    void Update()
    {

    }

    private IEnumerator ChangeDirectionCoroutine()
    {
        while (true)
        {
            if (!IsDead)
            {
                Vector3 currentDirection = pacMovementControl.CurrentDirection;

              
                if (Mathf.Abs(currentDirection.x) > Mathf.Abs(currentDirection.y))
                {
                    animatorController.SetBool("IsWalkLeft", currentDirection.x < 0);
                    animatorController.SetBool("IsWalkRight", currentDirection.x > 0);
                }
                else // Vertical movement
                {
                    animatorController.SetBool("IsWalkUp", currentDirection.y > 0);
                    animatorController.SetBool("IsWalkDown", currentDirection.y < 0);
                }
            }
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }
}
