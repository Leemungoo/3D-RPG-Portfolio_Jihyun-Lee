using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    void Start()
    {
        //PlayerMovement.playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //LayerImdexManager();

        TriggerInactivation();
    }
    
    /*
    private void LayerImdexManager()
    {
        if (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1)
        {
            PlayerMovement.playerAnimator.SetLayerWeight(PlayerMovement.playerAnimator.GetLayerIndex("Attack Layer 1"), 1);
            PlayerMovement.playerAnimator.SetLayerWeight(PlayerMovement.playerAnimator.GetLayerIndex("Attack Layer 2"), 0);
        }

        if (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(2).normalizedTime < 1)
        {
            PlayerMovement.playerAnimator.SetLayerWeight(PlayerMovement.playerAnimator.GetLayerIndex("Attack Layer 2"), 1);
            PlayerMovement.playerAnimator.SetLayerWeight(PlayerMovement.playerAnimator.GetLayerIndex("Attack Layer 1"), 0);
        }
    }
    */

    private void TriggerInactivation()
    {
        //Attack Layer(1, 2)의 Animation이 진행중일 때 특정 Trigger 불활성화 
        if (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1 
            || PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(2).normalizedTime < 1)
        {
            // Attack Trigger 중복 발동 불활성화
            PlayerMovement.playerAnimator.ResetTrigger("AttackN");
            PlayerMovement.playerAnimator.ResetTrigger("AttackU");
            PlayerMovement.playerAnimator.ResetTrigger("AttackV");
            PlayerMovement.playerAnimator.ResetTrigger("AttackT"); 
            PlayerMovement.playerAnimator.ResetTrigger("AttackF");

            // Buff Trigger 불활성화
            PlayerMovement.playerAnimator.ResetTrigger("ATKbuff");
            PlayerMovement.playerAnimator.ResetTrigger("DEFbuff");

            // Jump Trigger 불활성화
            PlayerMovement.playerAnimator.ResetTrigger("Jump");
        }

        // buff 애니매이션 진행중일때 특정 Trigger 불활성화
        if (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ATK Buff")
            && PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1
            || (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("DEF Buff")
            && PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1))
        {
            // Attack Trigger 불활성화
            PlayerMovement.playerAnimator.ResetTrigger("AttackN");
            PlayerMovement.playerAnimator.ResetTrigger("AttackU");
            PlayerMovement.playerAnimator.ResetTrigger("AttackV");
            PlayerMovement.playerAnimator.ResetTrigger("AttackT");
            PlayerMovement.playerAnimator.ResetTrigger("AttackF");

            // Buff Trigger 중복 발동 불활성화 
            PlayerMovement.playerAnimator.ResetTrigger("ATKbuff");
            PlayerMovement.playerAnimator.ResetTrigger("DEFbuff");

            //Jump Trigger 불활성화
            PlayerMovement.playerAnimator.ResetTrigger("Jump");
        }
    }
}
