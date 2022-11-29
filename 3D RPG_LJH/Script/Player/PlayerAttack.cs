using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void Update()
    {
        if(!GameManager.isPlayerDie)
        Attack();
    }

    private void Attack()
    {
        if (PlayerMovement.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Attack_Normal();

            else if (Input.GetKeyDown(KeyCode.Mouse1))
                Attack_Upslash();

            else if (Input.GetKeyDown(KeyCode.Alpha1))
                Attack_Tornado();

            else if (Input.GetKeyDown(KeyCode.Alpha2))
                Attack_Fly();
        }
    }

    private void Attack_Normal()
    {
        PlayerMovement.playerAnimator.Play("ATK_Normal");
    }

    private void Attack_Upslash()
    {
        PlayerMovement.playerAnimator.Play("ATK_Upslash");
    }

    private void Attack_Tornado()
    {
        PlayerMovement.playerAnimator.Play("ATK_Tornado");
    }

    private void Attack_Fly()
    {
        PlayerMovement.playerAnimator.Play("ATK_Fly");
    }
}








