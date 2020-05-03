using System;
using System.Collections;
using System.Collections.Generic;
using Tetris.GameModule.GameUIModule;
using UnityEngine;

namespace Tetris.GameModule
{
    public class GameController : IGameController
    {
        public event Action<int> EndGame;

        //UI controller can take player act and show some additional informations about game
        private IGameUIController gameUIController = new GameUIController();
        // Spawn groups
        private Spawner spawner;
        // Controll move and rotate active group
        private GroupController groupController;

        // Have to be invoked
        public void Init()
        {
            gameUIController.Init();
            spawner = GameObject.Instantiate(Resources.Load<Spawner>(GameData.SPAWNER_PREFAB_PATH));
            groupController = GameObject.Instantiate(Resources.Load<GroupController>(GameData.GROUP_CONTROLLER_PREFAB_PATH));
        }

        public void PauseGame()
        {
            // Stop move and rotate current group
            groupController?.ChangePlaing(false);
        }

        public void PlayGame()
        {
            // Continue move and rotate current group
            groupController?.ChangePlaing(true);
        }

        public void StartGame()
        {
            //Spawn and get first group
            Transform currentGroup = spawner.SpawnNext();

            // Subscribe actions with rows
            Playfield.DeletedRow += ScoreIncrease;
            Playfield.DeletedFullRows += OnDeleteFullRows;

            // Connect UIController with Group controller
            gameUIController.OnDownClick += groupController.MoveDown;
            gameUIController.OnLeftClick += groupController.MoveLeft;
            gameUIController.OnRightClick += groupController.MoveRight;
            gameUIController.OnUpClick += groupController.Rotate;
            groupController.CantCreateNewGroup += OnFinishGroupsMove;
            groupController.SetGroupTransform(currentGroup);
        }

        private void ScoreIncrease()
        {
            //Count score
            GameData.CurrentScore += GameData.SCORE_INCREASE;
        }

        private void OnDeleteFullRows()
        {
            // Show new score on screen
            gameUIController?.ShowNewScore();
        }

        private void OnFinishGroupsMove()
        {
            // Finish the game
            EndGame?.Invoke(GameData.CurrentScore);
        }
    }
}

