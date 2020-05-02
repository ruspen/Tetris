using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule
{
    public class GroupController : MonoBehaviour
    {
        public Transform currentGroupTransform;

        // Time since last gravity tick
        float lastFall = 0;
        // Start is called before the first frame update

        public void MoveLeft()
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

        public void MoveRight()
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

        public void Rotate()
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

        public void MoveDown()
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
                FindObjectOfType<Spawner>().SpawnNext();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
        }

        public void GetGroupTransform(Transform currentGroupTransform)
        {
            this.currentGroupTransform = currentGroupTransform;
            // Default position not valid? Then it's game over
            if (!IsValidGridPos())
            {
                Debug.Log("GAME OVER");
                Destroy(currentGroupTransform.gameObject);
            }
        }
        void Start()
        {
            GetGroupTransform(transform);
        }

        // Update is called once per frame
        void Update()
        {
            // Move Left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }

            // Move Right
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }

            // Rotate
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Rotate();
            }

            // Move Downwards and Fall
            else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                     Time.time - lastFall >= 1)
            {
                MoveDown();
            }
        }

        bool IsValidGridPos()
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

        void UpdateGrid()
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

