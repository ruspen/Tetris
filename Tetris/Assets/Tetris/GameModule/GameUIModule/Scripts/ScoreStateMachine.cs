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
            TextMeshProUGUI text = animator.gameObject.GetComponentInChildren<TextMeshProUGUI>();
            text.text = GameModule.GameData.CurrentScore.ToString();
        }
    }

}
