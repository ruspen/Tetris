using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule
{
    public interface IGameController
    {
        event Action<int> EndGame;
        void Init(); // Have to be invoked
        void StartGame();
        void PauseGame();
        void PlayGame();
    }
}

