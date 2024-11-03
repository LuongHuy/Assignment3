using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostDirectionControl : MonoBehaviour
{
    public Animator animControl;
    private float directionInterval = 2f;
    private float stateInterval = 3f;
    private string[] directions = { "Down", "Right", "Up", "Left" };
    private int curDirection = 0;
    private int curState = 0;

    public int GhostNumber;

    private string[] states = { "IsWalk", "IsScare", "IsDead", "IsRevive" };

    void Start()
    {
        animControl.SetTrigger(directions[curDirection]);
        SetState("IsWalk");
        SetParameter(GhostNumber);
    }
    public void SetState(string state)
    {
        foreach (string s in states)
        {
            animControl.SetBool(s,false);
        }
        animControl.SetBool(state,true);
        if (state == "IsScare")
        {
            StartCoroutine(RevertStateToNormal());
        }
        
    }
    public IEnumerator RevertStateToNormal()
    {
        yield return new WaitForSeconds(10f);
        SetState("IsWalk");
    }

    private void SetParameter(int value)
    {
        animControl.SetInteger("GhostNo", value);
    }
}
