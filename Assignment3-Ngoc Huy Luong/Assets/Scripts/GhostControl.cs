using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public GhostDirectionControl[] ghostDirectionControls;
    public static GhostControl instance;

    private void Awake()
    {
         instance = this;
    }

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
        ghostDirectionControls[0].transform.position = GetTileAtMapPosition(10, 17).transform.position;
        ghostDirectionControls[1].transform.position = GetTileAtMapPosition(12, 17).transform.position;
        ghostDirectionControls[2].transform.position = GetTileAtMapPosition(14, 17).transform.position;
        ghostDirectionControls[3].transform.position = GetTileAtMapPosition(16, 17).transform.position;
    }

    public void SetState(string state)
    {
        for (int i = 0; i < ghostDirectionControls.Length; i++)
        {
            ghostDirectionControls[i].SetState(state);
        }
    }
}
