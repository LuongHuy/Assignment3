using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPillManager : MonoBehaviour
{
    public GameObject powerPill;
    private bool isClaim;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClaim)
        {
            return;
        }
        isClaim = true;

        powerPill.SetActive(false);
        GhostControl.instance.SetState("IsScare");
        IngameUI.instance.scare.Startcountdown(10f);
    }
   



}
