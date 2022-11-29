using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : IState
{
    private Boss parent;

    public void Enter(Boss parent)
    {
        this.parent = parent;

        parent.navMeshAgent.isStopped = true; // 내비메쉬에이전트 추적정지
        parent.collider.enabled = false; // Boss 콜라이더 비활성화
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
