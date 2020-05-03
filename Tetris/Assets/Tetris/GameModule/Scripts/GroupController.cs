using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule
{
    public class GroupController : MonoBehaviour
    {
        public event Action CantCreateNewGroup;

        public Transform currentGroupTransform;

        // Time since last gravity tick
        private float lastFall = 0;
        private bool isPlaing = false;


        public void MoveLeft()
        {
            if (isPlaing)
            {
                // Modify position
                currentGroupTransform.position += new Vector3(-1, 0, 0);

                // See if valid
                if (IsValidGridPos())
                    // It's valid. Update grid.
                    UpdateGrid();
                else
                    // It's not valid. revert.
                    currentGroupTransform.position += new Vector3(1, 0, 0);
            }
            
        }

        public void MoveRight()
        {
            if (isPlaing)
            {
                // Modify position
                currentGroupTransform.position += new Vector3(1, 0, 0);

                // See if valid
                if (IsValidGridPos())
                    // It's valid. Update grid.
                    UpdateGrid();
                else
                    // It's not valid. revert.
                    currentGroupTransform.position += new Vector3(-1, 0, 0);
            }
            
        }

        public void Rotate()
        {
            if (isPlaing)
            {
                currentGroupTransform.Rotate(0, 0, -90);

                // See if valid
                if (IsValidGridPos())
                    // It's valid. Update grid.
                    UpdateGrid();
                else
                    // It's not valid. revert.
                    currentGroupTransform.Rotate(0, 0, 90);
            }
        }

        public void MoveDown()
        {
            if (isPlaing)
            {
                // Modify position
                currentGroupTransform.position += new Vector3(0, -1, 0);

                // See if valid
                if (IsValidGridPos())
                {
                    // It's valid. Update grid.
                    UpdateGrid();
                }
                else
                {
                    // It's not valid. revert.
                    currentGroupTransform.position += new Vector3(0, 1, 0);

                    // Clear filled horizontal lines
                    Playfield.DeleteFullRows();

                    // Spawn next Group
                    isPlaing = false;
                    Transform newTransform = FindObjectOfType<Spawner>().SpawnNext();
                    SetGroupTransform(newTransform);
                }

                lastFall = Time.time;
            }
            
        }

        public void SetGroupTransform(Transform currentGroupTransform)
        {
            this.currentGroupTransform = currentGroupTransform;
            // Default position not valid? Then it's game over
            if (!IsValidGridPos())
            {
                //Debug.Log("GAME OVER");
                CantCreateNewGroup?.Invoke();
                Destroy(currentGroupTransform.gameObject);
            }
            else
            {
                isPlaing = true;
            }
        }

        public void ChangePlaing(bool isPlaing)
        {
            this.isPlaing = isPlaing;
        }


        // Update is called once per frame
        void Update()
        {
            if (isPlaing)
            {
                //Fall
                if (Time.time - lastFall >= 1)
                {
                    MoveDown();
                }
            }
            
        }


        private bool IsValidGridPos()
        {
            foreach (Transform child in currentGroupTransform)
            {
                Vector2 v = Playfield.RoundVec2(child.position);

                // Not inside Border?
                if (!Playfield.InsideBorder(v))
                    return false;

                // Block in grid cell (and not part of same group)?
                if (Playfield.grid[(int)v.x, (int)v.y] != null &&
                    Playfield.grid[(int)v.x, (int)v.y].parent != currentGroupTransform)
                    return false;
            }
            return true;
        }

        private void UpdateGrid()
        {
            // Remove old children from grid
            for (int y = 0; y < GameData.GRID_HEIGHT; ++y)
                for (int x = 0; x < GameData.GRID_WIDTH; ++x)
                    if (Playfield.grid[x, y] != null)
                        if (Playfield.grid[x, y].parent == currentGroupTransform)
                            Playfield.grid[x, y] = null;

            // Add new children to grid
            foreach (Transform child in currentGroupTransform)
            {
                Vector2 v = Playfield.RoundVec2(child.position);
                Playfield.grid[(int)v.x, (int)v.y] = child;
            }
        }
    }
}

