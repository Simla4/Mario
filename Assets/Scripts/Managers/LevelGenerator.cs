using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    #region Variables

    [SerializeField] private LevelData levelData;

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
        var levelWidth = levelData.levelWidth;
        var levelHeight = levelData.levelHeight;
        var tileDistance = levelData.tileDistance;
        
        levelMap = new int[levelWidth, levelHeight];
        
        var minHeightVal = levelHeight - tileDistance;

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
        
        for (int x = 0; x < levelData.levelWidth; x++)
        {
            for (int y = 0; y < levelData.levelHeight; y++)
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
