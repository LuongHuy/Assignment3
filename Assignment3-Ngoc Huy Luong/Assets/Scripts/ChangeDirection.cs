using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public Animator animatorController;
    public bool IsDead;

    private float changeDirectionInterval = 3f;
    private string[] directions = { "left", "up", "down", "right" };
    private int currentDirectionIndex = 0;

    void Start()
    {
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
                animatorController.SetTrigger(directions[currentDirectionIndex]);
                currentDirectionIndex = (currentDirectionIndex + 1) % directions.Length;
            }
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }
}
