using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public GameObject palletObj;
    private bool isClaim;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClaim)
        {
            return;
        }
        isClaim = true;
        IngameUI.instance.ScoreUpdate(10);
        palletObj.SetActive(false);
    }

    

}
