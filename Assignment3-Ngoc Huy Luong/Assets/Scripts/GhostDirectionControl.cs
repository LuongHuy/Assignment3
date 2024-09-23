using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class GhostDirectionControl : MonoBehaviour
{
    public Animator animatorController;   
    private float changeDirectionInterval = 2f;
    private float changeStateInterval = 3f;
    private string[] directions = { "Down", "Right", "Up", "Left" };
    private int currentDirectionIndex = 0;
    private int currentStateIndex = 0;

    public int GhostNumber;

    private readonly string[] states = { "IsWalk", "IsScare", "IsDead", "IsRevive" };


    void Start()
    {
        animatorController.SetTrigger(directions[currentDirectionIndex]);
        SetState("IsWalk");
        SetParameter(GhostNumber);
        StartCoroutine(ChangeDirectionCoroutine());
        StartCoroutine(ChangeStateCoroutine());
    }

    void Update()
    {

    }

    private IEnumerator ChangeDirectionCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionInterval);
            currentDirectionIndex = (currentDirectionIndex + 1) % directions.Length;
            animatorController.SetTrigger(directions[currentDirectionIndex]);
        }
    }
    private IEnumerator ChangeStateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeStateInterval);
            currentStateIndex = (currentStateIndex + 1) % states.Length;
            SetState(states[currentStateIndex]);
        }
    }
    private void SetState(string state)
    {
        foreach (string s in states)
        {
            animatorController.SetBool(s, false);
        }
        animatorController.SetBool(state, true);
    }
    private void SetParameter(int value)
    {
        animatorController.SetInteger("GhostNo", value); 
    }
}
