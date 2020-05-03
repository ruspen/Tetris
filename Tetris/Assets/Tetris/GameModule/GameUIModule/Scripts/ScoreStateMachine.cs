using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tetris.GameModule.GameUIModule
{
    public class ScoreStateMachine : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //Get score text and change to the current
            TextMeshProUGUI text = animator.gameObject.GetComponentInChildren<TextMeshProUGUI>();
            text.text = GameModule.GameData.CurrentScore.ToString();
        }
    }

}
