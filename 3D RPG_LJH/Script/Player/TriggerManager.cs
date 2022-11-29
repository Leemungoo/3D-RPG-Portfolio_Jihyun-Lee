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
        //Attack Layer(1, 2)�� Animation�� �������� �� Ư�� Trigger ��Ȱ��ȭ 
        if (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1 
            || PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(2).normalizedTime < 1)
        {
            // Attack Trigger �ߺ� �ߵ� ��Ȱ��ȭ
            PlayerMovement.playerAnimator.ResetTrigger("AttackN");
            PlayerMovement.playerAnimator.ResetTrigger("AttackU");
            PlayerMovement.playerAnimator.ResetTrigger("AttackV");
            PlayerMovement.playerAnimator.ResetTrigger("AttackT"); 
            PlayerMovement.playerAnimator.ResetTrigger("AttackF");

            // Buff Trigger ��Ȱ��ȭ
            PlayerMovement.playerAnimator.ResetTrigger("ATKbuff");
            PlayerMovement.playerAnimator.ResetTrigger("DEFbuff");

            // Jump Trigger ��Ȱ��ȭ
            PlayerMovement.playerAnimator.ResetTrigger("Jump");
        }

        // buff �ִϸ��̼� �������϶� Ư�� Trigger ��Ȱ��ȭ
        if (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ATK Buff")
            && PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1
            || (PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("DEF Buff")
            && PlayerMovement.playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1))
        {
            // Attack Trigger ��Ȱ��ȭ
            PlayerMovement.playerAnimator.ResetTrigger("AttackN");
            PlayerMovement.playerAnimator.ResetTrigger("AttackU");
            PlayerMovement.playerAnimator.ResetTrigger("AttackV");
            PlayerMovement.playerAnimator.ResetTrigger("AttackT");
            PlayerMovement.playerAnimator.ResetTrigger("AttackF");

            // Buff Trigger �ߺ� �ߵ� ��Ȱ��ȭ 
            PlayerMovement.playerAnimator.ResetTrigger("ATKbuff");
            PlayerMovement.playerAnimator.ResetTrigger("DEFbuff");

            //Jump Trigger ��Ȱ��ȭ
            PlayerMovement.playerAnimator.ResetTrigger("Jump");
        }
    }
}
