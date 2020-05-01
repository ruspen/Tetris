using System.Collections;
using System.Collections.Generic;
using Tetris.GlobalModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tetris.SceneModules.MainMenu
{
    public class MainMenuSceneController : MonoBehaviour
    {
        public MainMenuUIController mainMenuUIController;


        void Start()
        {
            Subscribe();
        }


        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            mainMenuUIController.OnStartGameButtonClick += StartGame;
        }

        private void Unsubscribe()
        {
            mainMenuUIController.OnStartGameButtonClick -= StartGame;
        }

        private void StartGame()
        {
            SceneManager.LoadScene(GameData.GAME_SCENE_NAME);
        }

    }
}

