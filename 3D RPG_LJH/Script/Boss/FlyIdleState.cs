using UnityEngine;

public class FlyIdleState : IState
{
    private Boss parent;

    public void Enter(Boss parent)
    {
        Debug.Log("Boss: FlyIdleState ¡¯¿‘");

        this.parent = parent;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        parent.animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

        if (!BossSoundReceiver.isPerceived)
            parent.ChangeState(new FlyPatrolState());

        if (BossSoundReceiver.isPerceived)
            parent.ChangeState(new FlyTraceState());

        if (BossStatus.isBossDead)
            parent.ChangeState(new BossDeadState());
    }
}
