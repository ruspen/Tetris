using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.SceneModules.MainMenu
{
    public class MainMenuUIController : MonoBehaviour
    {
        public event Action OnStartGameButtonClick;


        public void StartGameButtonClick()
        {
            OnStartGameButtonClick?.Invoke();
        }
    }
}

