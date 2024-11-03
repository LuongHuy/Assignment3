using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentManager : MonoBehaviour
{
    public PacStudentController controller;

    public void CharacterDead()
    {
        GameManager.instance.ReduceLive();
        controller.RestartPosition();
    }
}
