using System.Collections;
using System.Collections.Generic;
using Tetris.GameModule;
using Tetris.GlobalModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tetris.SceneModules.Game
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField]
        private GameSceneUIController uiController;

        private IGameController gameController = new GameController();


        void Start()
        {
            Subscribe();
            StartGame();
        }

        void Update()
        {
            
        }

        private void OnDisable()
        {
            Unsubscribe();
        }


        private void Subscribe()
        {
            uiController.OnPauseClick += PauseGame;
            uiController.OnPlayClick += PlayGame;
            uiController.OnBackClick += BackGame;
        }

        private void Unsubscribe()
        {
            uiController.OnPauseClick -= PauseGame;
            uiController.OnPlayClick -= PlayGame;
            uiController.OnBackClick -= BackGame;
        }

        private void StartGame()
        {
            gameController.Init();
            gameController.StartGame();
        }

        private void PauseGame()
        {

        }

        private void PlayGame()
        {

        }

        private void BackGame()
        {
            SceneManager.LoadScene(GlobalModule.GameData.MAINMENU_SCENE_NAME);
        }
    }
}

