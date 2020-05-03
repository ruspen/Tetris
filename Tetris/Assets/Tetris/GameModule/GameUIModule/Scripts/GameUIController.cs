using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule.GameUIModule
{
    public class GameUIController : IGameUIController
    {
        public event Action OnRightClick;
        public event Action OnLeftClick;
        public event Action OnUpClick;
        public event Action OnDownClick;

        private SwipeTapDetect swipeTapDetect;
        private Animator scoreInfo;
        public void Init()
        {
            StartSwipeTapDetect();
            scoreInfo = GameObject.Instantiate(Resources.Load<Animator>(GameUIData.SCORE_INFO_PREFAB_PATH));
        }


        private void StartSwipeTapDetect()
        {
            swipeTapDetect = GameObject.Instantiate(Resources.Load<SwipeTapDetect>(GameUIData.SWIPE_TAP_DETECT_PREFAB_PATH));
            swipeTapDetect.OnLeftSwipe += () =>
            {
                OnLeftClick?.Invoke();
            };
            swipeTapDetect.OnRightSwipe += () =>
            {
                OnRightClick?.Invoke();
            };
            swipeTapDetect.OnUpSwipe += () =>
            {
                OnUpClick?.Invoke();
            };
            swipeTapDetect.OnDownSwipe += () =>
            {
                OnDownClick?.Invoke();
            };
        }

        public void ShowNewScore()
        {
            scoreInfo.SetTrigger(GameUIData.SCORE_INFO_ACTIVE_TRIGGER);
        }
    }
}

