using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule.GameUIModule
{
    public class GameUIController : IGameUIController
    {
        #region Swipe events
        public event Action OnRightClick;
        public event Action OnLeftClick;
        public event Action OnUpClick;
        public event Action OnDownClick;
        #endregion

        private SwipeTapDetect swipeTapDetect;
        //Animation to show new score
        private Animator scoreInfo;

        //Have to be invoked
        public void Init()
        {
            StartSwipeTapDetect();
            scoreInfo = GameObject.Instantiate(Resources.Load<Animator>(GameUIData.SCORE_INFO_PREFAB_PATH));
        }
        public void ShowNewScore()
        {
            scoreInfo.SetTrigger(GameUIData.SCORE_INFO_ACTIVE_TRIGGER);
        }


        private void StartSwipeTapDetect()
        {
            // create object to detect swipe
            swipeTapDetect = GameObject.Instantiate(Resources.Load<SwipeTapDetect>(GameUIData.SWIPE_TAP_DETECT_PREFAB_PATH));
            // subscripe finger detection
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

    }
}

