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

        private IGameUIController gameUIController = new GameUIController();
        private Spawner spawner;
        private GroupController groupController;

        public void Init()
        {
            gameUIController.Init();
            spawner = GameObject.Instantiate(Resources.Load<Spawner>(GameData.SPAWNER_PREFAB_PATH));
            groupController = GameObject.Instantiate(Resources.Load<GroupController>(GameData.GROUP_CONTROLLER_PREFAB_PATH));
        }

        public void PauseGame()
        {
            groupController?.ChangePlaing(false);
        }

        public void PlayGame()
        {
            groupController?.ChangePlaing(true);
        }

        public void StartGame()
        {
            Transform currentGroup = spawner.SpawnNext();

            Playfield.DeletedRow += ScoreIncrease;

            gameUIController.OnDownClick += groupController.MoveDown;
            gameUIController.OnLeftClick += groupController.MoveLeft;
            gameUIController.OnRightClick += groupController.MoveRight;
            gameUIController.OnUpClick += groupController.Rotate;
            groupController.CantCreateNewGroup += FinishGroupsMove;
            groupController.SetGroupTransform(currentGroup);
        }

        private void ScoreIncrease()
        {
            GameData.CurrentScore += GameData.SCORE_INCREASE;

        }

        private void FinishGroupsMove()
        {
            EndGame?.Invoke(GameData.CurrentScore);
        }
    }
}

