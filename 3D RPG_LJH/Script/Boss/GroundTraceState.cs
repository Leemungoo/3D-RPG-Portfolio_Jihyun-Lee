using UnityEngine;

public class GroundTraceState : IState
{
    private Boss parent;

    public void Enter(Boss parent)
    {
        this.parent = parent;
        Boss.isFlying = false;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        parent.animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

        float distance = Vector3.Distance(parent.target.position, parent.transform.position);


        if (distance > parent.attackDistance && BossSoundReceiver.isPerceived)
        {
            Trace();
        }

        if (distance <= parent.attackDistance)
        {
            parent.ChangeState(new GroundIdleState());
        }

        if (!BossSoundReceiver.isPerceived)
        {
            parent.ChangeState(new FlyTraceState());
        }

        if (BossStatus.isBossDead)
            parent.ChangeState(new BossDeadState());
    }

    private void Trace()
    {
        SetDestination();
        parent.navMeshAgent.destination = parent.target.position;
    }

    public void SetDestination()
    {
        if (parent.target != null)
        {
            Vector3 targetVector = parent.target.transform.position;
            parent.navMeshAgent.SetDestination(targetVector);
        }
    }
}
