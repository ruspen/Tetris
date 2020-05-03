using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule
{
    public class Playfield : MonoBehaviour
    {
        #region Events about manipulated with rows
        public static event Action DeletedRow;
        public static event Action DeletedFullRows;
        #endregion

        public static Transform[,] grid = new Transform[GameData.GRID_WIDTH, GameData.GRID_HEIGHT];


        public static Vector2 RoundVec2(Vector2 v)
        { 
            return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
        }

        public static bool InsideBorder(Vector2 pos)
        {
            return ((int)pos.x >= 0 && (int)pos.x < GameData.GRID_WIDTH && (int)pos.y >= 0);
        }

        public static void DeleteRow(int y)
        {
            DeletedRow?.Invoke();
            for (int x = 0; x < GameData.GRID_WIDTH; ++x)
            {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }

        public static void DecreaseRow(int y)
        {
            for (int x = 0; x < GameData.GRID_WIDTH; ++x)
            {
                if (grid[x, y] != null)
                {
                    // Move one towards bottom
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;

                    // Update Block position
                    grid[x, y - 1].position += new Vector3(0, -1, 0);
                }
            }
        }

        public static bool IsRowFull(int y)
        {
            for (int x = 0; x < GameData.GRID_WIDTH; ++x)
                if (grid[x, y] == null)
                    return false;
            return true;
        }

        public static void DecreaseRowsAbove(int y)
        {
            for (int i = y; i < GameData.GRID_HEIGHT; ++i)
                DecreaseRow(i);
        }

        public static void DeleteFullRows()
        {
            bool deletedRow = false;
            for (int y = 0; y < GameData.GRID_HEIGHT; ++y)
            {
                if (IsRowFull(y))
                {
                    DeleteRow(y);
                    DecreaseRowsAbove(y + 1);
                    --y;
                    deletedRow = true;
                }
            }
            if (deletedRow)
            {
                DeletedFullRows?.Invoke();
            }
            
        }

    }
}

