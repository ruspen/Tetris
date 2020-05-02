﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tetris.SceneModules.Game
{
    public class GameSceneUIController : MonoBehaviour
    {
        public event Action OnPauseClick;
        public event Action OnPlayClick;
        public event Action OnBackClick;

        [SerializeField]
        private Image pausePlayButtonImage;
        [SerializeField]
        private Sprite pauseSprite;
        [SerializeField]
        private Sprite playSprite;
        [Header("Inform Panel")]
        [SerializeField]
        private GameObject informPanel;
        [SerializeField]
        private TextMeshProUGUI scoreText;

        private bool isPause = false;


        public void OnPausePlayButtonClick()
        {
            if (isPause)
            {
                isPause = false;
                OnPlayClick?.Invoke();
                pausePlayButtonImage.sprite = pauseSprite;
            }
            else
            {
                isPause = true;
                OnPauseClick?.Invoke();
                pausePlayButtonImage.sprite = playSprite;
            }

        }

        public void OnBackButtonClick()
        {
            OnBackClick?.Invoke();
        }

        public void ShowEndGamePanel(int score)
        {
            scoreText.text = score.ToString();
            informPanel.SetActive(true);
        }


        void Start()
        {
            pausePlayButtonImage.sprite = pauseSprite;
        }

    }
}

