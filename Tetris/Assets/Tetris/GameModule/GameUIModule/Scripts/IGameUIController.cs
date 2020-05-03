using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule.GameUIModule
{
    public interface IGameUIController
    {
        #region Events to controll character
        event Action OnRightClick;
        event Action OnLeftClick;
        event Action OnUpClick;
        event Action OnDownClick;
        #endregion

        //Have to be invoked
        void Init();
        // Shove score on screen
        void ShowNewScore();
        
    }
}

