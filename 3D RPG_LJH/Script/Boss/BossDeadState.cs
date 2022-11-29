using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : IState
{
    private Boss parent;

    public void Enter(Boss parent)
    {
        this.parent = parent;

        parent.navMeshAgent.isStopped = true; // ����޽�������Ʈ ��������
        parent.collider.enabled = false; // Boss �ݶ��̴� ��Ȱ��ȭ
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if (!Boss.isFlying)
        {
            parent.animator.SetTrigger("DieFlying");
        }
        else
        {
            parent.animator.SetTrigger("DieStanding");
        }
    }
}
