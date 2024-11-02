using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public GameObject ghost1, ghost2, ghost3, ghost4;


    public GameObject GetTileAtMapPosition(int mapX, int mapY)
    {

        if (mapX >= 0 && mapX < LevelGenerator.instance.fullMap.GetLength(1) && mapY >= 0 && mapY < LevelGenerator.instance.fullMap.GetLength(0))
        {

            return LevelGenerator.instance.tileBase[mapY, mapX];
        }

        return null;
    }

    private void Start()
    {
        ghost1.transform.position = GetTileAtMapPosition(10, 17).transform.position;
        ghost2.transform.position = GetTileAtMapPosition(12, 17).transform.position;
        ghost3.transform.position = GetTileAtMapPosition(14, 17).transform.position;
        ghost4.transform.position = GetTileAtMapPosition(16, 17).transform.position;
    }
}
