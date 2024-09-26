using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
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
    public GameObject[] tileMapPrefab;
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
        int col = fullMap.GetLength(1);
        tileBase= new GameObject[row, col];
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {
                int tileType = fullMap[x, y];
                if (tileType == 0)
                {
                    continue;
                }
                Vector3 intiatePos = new Vector3(y * 0.3f, x * -0.3f, 0);
                Quaternion rotation = Quaternion.identity;

                GameObject tilePrefab = GetPrefab(tileType);
                GameObject tile = Instantiate(tilePrefab, intiatePos, rotation);
                tile.transform.SetParent(transform);
                if (tileType == 1)
                {
                    continue;
                }

                if (tileType == 2)
                {
                    if (y == 0 || y == col - 1)
                    {
                        if (y == 0)
                        {
                            int nextTile = fullMap[x, y + 1];
                            if (tileType != nextTile)
                            {
                                tile.transform.Rotate(0, 0, 90);
                            }
                        }
                        else if (y == col - 1)
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

                if (tileType == 4)
                {
                    int nextTile = fullMap[x, y + 1];
                    int reverseTile = fullMap[x, y - 1];
                    if (tileType != nextTile && tileType != reverseTile)
                    {
                        tile.transform.Rotate(0, 0, 90);
                    }
                    else if (nextTile == 5 || reverseTile == 5 || nextTile == 0 || reverseTile == 0)
                    {
                        if (tileType != nextTile || tileType != reverseTile)
                        {
                            tile.transform.Rotate(0, 0, 90);
                        }
                    }

                }

                if (tileType == 3)
                {
                    int nextTile = fullMap[x, y + 1];
                    int reverseTile = fullMap[x, y - 1];
                    int upTile = fullMap[x - 1, y];
                    int downTile = fullMap[x + 1, y];
                    if (nextTile == 4 && upTile == 4)
                    {
                        tile.transform.Rotate(0, 0, 90);
                    }
                    if (reverseTile == 4 && downTile == 4)
                    {
                        tile.transform.Rotate(0, 0, -90);
                    }
                    if (reverseTile == 4 && upTile == 4)
                    {
                        tile.transform.Rotate(0, 0, 180);
                    }

                    if (nextTile == 4 && upTile == 3)
                    {
                        tile.transform.Rotate(0, 0, 90);
                    }
                    if (reverseTile == 4 && upTile == 3)
                    {
                        tile.transform.Rotate(0, 0, 180);
                    }
                    if (reverseTile == 4 && downTile == 3)
                    {
                        tile.transform.Rotate(0, 0, -90);
                    }
                    if (nextTile == 3 && upTile == 4)
                    {
                        tile.transform.Rotate(0, 0, 90);
                    }
                    if (reverseTile == 3 && upTile == 4)
                    {
                        tile.transform.Rotate(0, 0, 180);
                    }
                    if (reverseTile == 3 && downTile == 4)
                    {
                        tile.transform.Rotate(0, 0, -90);
                    }
                    if (nextTile == 4 && downTile == 3 && upTile == 4)
                    {
                        tile.transform.Rotate(0, 0, -90);
                    }
                    if (nextTile == 4 && downTile == 4 && reverseTile == 4)
                    {
                        tile.transform.Rotate(0, 0, 360);
                    }
                }

                if (tileType == 7)
                {
                    int nextTile = fullMap[x, y + 1];
                    int reverseTile = fullMap[x, y - 1];
                    if (reverseTile == 7 && nextTile == 2)
                    {
                        tile.transform.Rotate(0, 180, 0);
                    }

                }
                tileBase[x, y] = tile;
            }
        }
        mainCamera.transform.position = new Vector3(row / 2 * 0.3f, col / 2 * -0.3f, -10);
    }

        GameObject GetPrefab (int type)
        {
            return tileMapPrefab[type];
        }
    
    private int[,] CreateFullMap(int[,] quarterMap)
    {      
        int h = quarterMap.GetLength(0);
        int w = quarterMap.GetLength(1);

        int[,] fullMap =new int[h*2 -1, w*2];

        for (int y = 0; y < h; y++)
        {
            for(int x = 0; x < w; x++)
            {
                fullMap[y, x] = quarterMap[y, x];
            }
        }

        for (int y = 0; y < h - 1; y++)
        {
            for (int x = 0; x < w; x++)
            {
                fullMap[h + y, x] = quarterMap[h - y - 2, x];
            }
        }

        for (int y = 0; y < h; y++)
        {
            for (int x= 0; x < w;x++) 
            {
                fullMap[y, w + x] = quarterMap[y, w - x - 1];
            }
        }

        for (int y = 0;y < h - 1; y++)
        {
            for (int x = 0; x < w;x++)
            {
                fullMap[ h + y, w + x] = quarterMap[h - y - 2, w - x - 1];
            }
        }

        return fullMap;
    }
       
   
}
