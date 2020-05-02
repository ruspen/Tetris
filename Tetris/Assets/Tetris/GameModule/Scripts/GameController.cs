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


        public void Init()
        {
            gameUIController.Init();
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
            throw new NotImplementedException();
        }
    }
}

