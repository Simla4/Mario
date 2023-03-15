using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    #region Variables

    [SerializeField] private int levelWidth;
    [SerializeField] private int levelHeight;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile groundTile;
    [SerializeField] private Tile grassTile;

    private int[,] levelMap;

    #endregion

    #region MyRegion

    private void Start()
    {
        GenerateArrayList();
        RenderMap();
    }

    #endregion

    #region OtherMethods

    private void GenerateArrayList()
    {
        levelMap = new int[levelWidth, levelHeight];
        
        var minHeightVal = levelHeight - 2;

        for (int i = 0; i < levelWidth; i++)
        {
            var height = Random.Range(minHeightVal, (levelHeight + 1));
            
            for (int j = 0; j < levelHeight; j++)
            {

                if (j == height - 1)
                {
                    levelMap[i, j] = 2;
                }
                else if (j < height)
                {
                    levelMap[i, j] = 1;
                }
                else
                {
                    levelMap[i, j] = 0;
                }
            }
        }
    }

    private void RenderMap()
    {
        tilemap.ClearAllTiles();
        
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                if (levelMap[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), groundTile);
                }
                else if (levelMap[x, y] == 2)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), grassTile);

                }
                
            }
        }
    }

    #endregion
}
