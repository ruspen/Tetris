using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTapDetect : MonoBehaviour
{
    public event Action OnRightSwipe;
    public event Action OnLeftSwipe;
    public event Action OnTap;
    public event Action OnDownSwipe;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;


    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left");
            OnLeftSwipe?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Tap");
            OnTap?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right");
            OnRightSwipe?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Down");
            OnDownSwipe?.Invoke();
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
            if (endTouchPosition.x < startTouchPosition.x)
            {
                Debug.Log("Left");
                OnLeftSwipe?.Invoke();
            }
            else if (endTouchPosition.x > startTouchPosition.x)
            {
                Debug.Log("Right");
                OnRightSwipe?.Invoke();
            }
            else
            {
                Debug.Log("Tap");
                OnTap?.Invoke();
            }
        }
    }
}
