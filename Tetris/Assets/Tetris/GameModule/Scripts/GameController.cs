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
        }

        public void PauseGame()
        {
            throw new NotImplementedException();
        }

        public void PlayGame()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            spawner.SpawnNext();
        }
    }
}

