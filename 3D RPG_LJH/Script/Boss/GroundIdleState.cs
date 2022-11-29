using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundIdleState : IState
{
    private Boss parent;

    public void Enter(Boss parent)
    {
        this.parent = parent;
        parent.animator.SetBool("ToGround", true);
        Boss.isFlying = false;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        float distance = Vector3.Distance(parent.target.position, parent.transform.position);

        parent.animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);


        if (distance <= parent.landingDistance && distance > parent.attackDistance)
        {
            parent.ChangeState(new GroundTraceState());
        }

        if (distance <= parent.attackDistance)
        {
            parent.ChangeState(new BossAttackState());
        }

        // 거리가 landingDistance보다 멀면 FlyTraceState로 전환
        if (distance > parent.landingDistance)
        {
            parent.ChangeState(new FlyTraceState());
        }

        if (BossStatus.isBossDead)
            parent.ChangeState(new BossDeadState());
    }

}

