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
    private string[] directions = { "right", "down", "left", "up" };
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
                Debug.Log($"Changing direction to: {directions[currentDirectionIndex]}");
                animatorController.SetTrigger(directions[currentDirectionIndex]);
                currentDirectionIndex = (currentDirectionIndex + 1) % directions.Length;
            }
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }
}
