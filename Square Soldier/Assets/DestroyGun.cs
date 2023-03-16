using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGun : StateMachineBehaviour
{
    GameObject helicopter;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        helicopter = animator.gameObject;
        // Get the first child GameObject using the parent's transform property
        Transform childTransform = helicopter.transform.GetChild(0);
        if (childTransform != null)
        {
            GameObject childGameObject = childTransform.gameObject;
            Destroy(childGameObject);
        }

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
    }
}
