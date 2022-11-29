using UnityEngine;

public class FlyTraceState : IState
{
    private Boss parent;

    public void Enter(Boss parent)
    {
        this.parent = parent;

        parent.animator.SetBool("ToGround", false);
        Boss.isFlying = true;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        parent.animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

        Trace();

        float distance = Vector3.Distance(parent.target.position, parent.transform.position);

        if (!BossSoundReceiver.isPerceived)
            parent.ChangeState(new FlyIdleState());

        if (distance <= parent.landingDistance)
        {
            parent.ChangeState(new GroundIdleState());
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