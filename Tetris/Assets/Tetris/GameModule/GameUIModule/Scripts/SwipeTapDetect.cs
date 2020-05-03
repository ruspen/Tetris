using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule.GameUIModule
{
    public class SwipeTapDetect : MonoBehaviour
    {
        public event Action OnRightSwipe;
        public event Action OnLeftSwipe;
        public event Action OnUpSwipe;
        public event Action OnDownSwipe;

        private Vector2 startTouchPosition;
        private Vector2 endTouchPosition;
        private float minDistanceForSwipe = 20f;


        void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Left");
                SendSwipe(SwipeDirection.Left);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Tap");
                SendSwipe(SwipeDirection.Up);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Right");
                SendSwipe(SwipeDirection.Right);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Down");
                SendSwipe(SwipeDirection.Down);
            }
#endif
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log($"EndTouchPosition = {endTouchPosition} StartTouchPosition = {startTouchPosition}");
                endTouchPosition = Input.GetTouch(0).position;
                DetectSwipe();
            }
            
        }

        private float VerticalMovementDistance()
        {
            return Mathf.Abs(startTouchPosition.y - endTouchPosition.y);
        }

        private float HorizontalMovementDistance()
        {
            return Mathf.Abs(startTouchPosition.x - endTouchPosition.x);
        }

        private bool SwipeDistanceCheckMet()
        {
            return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
        }

        private bool IsHorizontalSwipe()
        {
            return HorizontalMovementDistance() > VerticalMovementDistance();
        }

        private void DetectSwipe()
        {
            if (SwipeDistanceCheckMet())
            {
                if (IsHorizontalSwipe())
                {
                    SwipeDirection direction = startTouchPosition.x - endTouchPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                    SendSwipe(direction);
                }
                else
                {
                    SwipeDirection direction = startTouchPosition.y - endTouchPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                }
            }
        }

        private void SendSwipe(SwipeDirection direction)
        {
            switch (direction)
            {
                case SwipeDirection.Up:
                    OnUpSwipe?.Invoke();
                    break;
                case SwipeDirection.Down:
                    OnDownSwipe?.Invoke();
                    break;
                case SwipeDirection.Left:
                    OnLeftSwipe?.Invoke();
                    break;
                case SwipeDirection.Right:
                    OnRightSwipe?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}

