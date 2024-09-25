using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int[,] levelMap = new int[,]
{ 
{1,2,2,2,2,2,2,2,2,2,2,2,2,7},
{2,5,5,5,5,5,5,5,5,5,5,5,5,4},
{2,5,3,4,4,3,5,3,4,4,4,3,5,4},
{2,6,4,0,0,4,5,4,0,0,0,4,5,4},
{2,5,3,4,4,3,5,3,4,4,4,3,5,3},
{2,5,5,5,5,5,5,5,5,5,5,5,5,5},
{2,5,3,4,4,3,5,3,3,5,3,4,4,4},
{2,5,3,4,4,3,5,4,4,5,3,4,4,3},
{2,5,5,5,5,5,5,4,4,5,5,5,5,4},
{1,2,2,2,2,1,5,4,3,4,4,3,0,4},
{0,0,0,0,0,2,5,4,3,4,4,3,0,3},
{0,0,0,0,0,2,5,4,4,0,0,0,0,0},
{0,0,0,0,0,2,5,4,4,0,3,4,4,0},
{2,2,2,2,2,1,5,3,3,0,4,0,0,0},
{0,0,0,0,0,0,5,0,0,0,4,0,0,0},
};
 
    void Start()
    {
        Destroy(GameObject.Find("Level1"));
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < levelMap.GetLength(0); x++)
        {
            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                int tileType = levelMap[x, y];
                Vector3 position = new Vector3(x, y, 0);
                Quaternion rotation = Quaternion.identity;
                GameObject tilePrefab = GetPrefabFromType(tileType);
                GameObject tile = Instantiate(tilePrefab, position, rotation);
                tile.transform.SetParent(transform);
            }
        }
    }

    GameObject GetPrefabFromType(int type)
    {
        switch (type)
        {
           /* case 0: return null; 
            case 1: return outCornerPrefab; 
            case 2: return outWallPrefab; 
            case 3: return innerCornerPrefab; 
            case 4: return innerWallPrefab; 
            case 5: return standardSpacePrefab; 
            case 6: return specialSpacePrefab;
            case 7: return tWallPrefab; */
            default: return null;
        }
    }



    void Update()
    {
        
    }
}
