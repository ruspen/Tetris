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
            gameController.Init();
            Subscribe();
            StartGame();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            //Subscribe main ui buttons
            uiController.OnPauseClick += PauseGame;
            uiController.OnPlayClick += PlayGame;
            uiController.OnBackClick += BackGame;
            //Subscribe game informations
            gameController.EndGame += EndGame;
        }

        private void Unsubscribe()
        {
            //Unsubscribe main ui buttons
            uiController.OnPauseClick -= PauseGame;
            uiController.OnPlayClick -= PlayGame;
            uiController.OnBackClick -= BackGame;
            //Unsubscribe game informations
            gameController.EndGame -= EndGame;
        }

        private void StartGame()
        {
            gameController.StartGame();
        }

        private void PauseGame()
        {
            gameController.PauseGame();
        }

        private void PlayGame()
        {
            gameController.PlayGame();
        }

        private void BackGame()
        {
            SceneManager.LoadScene(GlobalModule.GameData.MAINMENU_SCENE_NAME);
        }

        private void EndGame(int score)
        {
            uiController.ShowEndGamePanel(score);
        }
    }
}

