using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public string state;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PacStudentManager>();
        player.CharacterDead();
        
    }
}
