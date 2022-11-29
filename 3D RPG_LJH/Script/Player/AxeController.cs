using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public static Collider collider;
    public static bool isNormalAttacking = false;
    public static bool isUpslashAttacking = false;
    public static bool isTornadoAttacking = false;
    public static bool isFlyAttacking = false;

    private void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (PlayerMovement.isGrounded) // 플레이어가 Jump중이 아닐 때만 공격
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
        collider.enabled = true;
        isNormalAttacking = true;
        Debug.Log("activated");
        PlayerMovement.playerAnimator.Play("ATK_Normal");
    }

    private void Attack_Upslash()
    {
        collider.enabled = true;
        isUpslashAttacking = true;
        Debug.Log("activated");
        PlayerMovement.playerAnimator.Play("ATK_Upslash");
    }

    private void Attack_Tornado()
    {
        collider.enabled = true;
        isTornadoAttacking = true;
        Debug.Log("activated");
        PlayerMovement.playerAnimator.Play("ATK_Tornado");
    }

    private void Attack_Fly()
    {
        collider.enabled = true;
        isFlyAttacking = true;
        Debug.Log("activated");
        PlayerMovement.playerAnimator.Play("ATK_Fly");
    }
}
