using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitNearCheck : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
    public float opendist = 3;
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool flag = false;
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject unit in units)
        {
            if ((animator.gameObject.transform.position - unit.transform.position).magnitude <= opendist)
            {
                animator.SetBool("character_nearby", true);
                flag = true;
            }
        }
        foreach (GameObject unit in enemies)
        {
            if ((animator.gameObject.transform.position - unit.transform.position).magnitude <= opendist)
            {
                animator.SetBool("character_nearby", true);
                flag = true;
            }
        }
        if (!flag) animator.SetBool("character_nearby", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
