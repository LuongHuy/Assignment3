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

    public enum TileType { OutWall, InnerWall, StandardSpace, OutCorner, InnerCorner, SpecialSpace, TWall}   
    public GameObject[] tilePrefab;
    private GameObject[,] tileBase;
    public GameObject mainCamera;



    void Start()
    {
        Destroy(GameObject.Find("Level1"));
        GenerateLevel();
    }

    void GenerateLevel()
    {
        var fullMap = CreateFullMap(levelMap);
        int row = fullMap.GetLength(0);
        int collumn = fullMap.GetLength(1);
        tileBase = new GameObject[row, collumn];
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < collumn; y++)
            {
                int tileType = fullMap[x, y];
                Debug.Log("x: " + x + ", " + "y: " + y + "Tile: " + tileType);
                if (tileType == 0)
                {
                    continue;
                }
                Vector3 position = new Vector3(y * 0.3f, x * -0.3f, 0);
                Quaternion rotation = Quaternion.identity;
             
                GameObject tilePrefab = GetPrefabFromType(tileType);
                GameObject tile = Instantiate(tilePrefab, position, rotation);
                tile.transform.SetParent(transform);
                
                if (tileType == 2)
                {
                    if (y == 0 || y == collumn - 1)
                    {
                        if (y == 0)
                        {
                            int nextTile = fullMap[x, y + 1];
                            if (tileType != nextTile)
                            {
                                tile.transform.Rotate(0, 0, 90);
                            }
                        }
                        else if (y == collumn - 1 )
                        {
                            int nextTile = fullMap[x, y - 1];
                            if (tileType != nextTile)
                            {
                                tile.transform.Rotate(0, 0, 90);
                            }
                        }
                        else
                        {
                            tile.transform.Rotate(0, 0, 90);
                        }
                                           
                    }
                    else
                    {
                        int nextTile = fullMap[x, y + 1];
                        int reverseTile = fullMap[x, y - 1];
                        if (tileType != nextTile && tileType != reverseTile)
                        {
                            tile.transform.Rotate(0, 0, 90);
                        }
                    }
                }


                tileBase[x, y] = tile;
            }
        }
        mainCamera.transform.position = new Vector3(row / 2 * 0.3f, collumn / 2 * -0.3f, -10);
    }

    GameObject GetPrefabFromType(int type)
    {
        return tilePrefab[type];
       
    }

    private int[,] CreateFullMap(int[,] quarterMap)
    {
        int width = quarterMap.GetLength(1);
        int height = quarterMap.GetLength(0);
        int[,] fullMap = new int[height * 2 - 1, width * 2]; 

  
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                fullMap[y, x] = quarterMap[y, x];
            }
        }
 
        for (int y = 0; y < height - 1; y++) 
        {
            for (int x = 0; x < width; x++)
            {
                fullMap[height + y, x] = quarterMap[height - y - 2, x];
            }
        }
  
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                fullMap[y, width + x] = quarterMap[y, width - x - 1];
            }
        }    
        for (int y = 0; y < height - 1; y++) 
        {
            for (int x = 0; x < width; x++)
            {
                fullMap[height + y, width + x] = quarterMap[height - y - 2, width - x - 1];
            }
        }

        return fullMap;
    }

    void Update()
    {
        
    }
}
