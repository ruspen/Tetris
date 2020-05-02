using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule.GameUIModule
{
    public interface IGameUIController
    {
        event Action OnRightClick;
        event Action OnLeftClick;
        event Action OnTapClick;

        void Init();
        
    }
}

