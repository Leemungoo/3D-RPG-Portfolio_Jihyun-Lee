using UnityEngine;

public class FlyPatrolState : IState
{
    private Boss parent;

    private float waitTime;
    private float StartWaitTime;
    private Transform moveSpot;
    private float minX = -10;
    private float maxX = 2;
    private float minY = 0;
    private float maxY = 0;
    private float minZ = 180;
    private float maxZ = 220;



    public void Enter(Boss parent)
    {
        Debug.Log("FlyPatrolState ¡¯¿‘");
            
        this.parent = parent;

        Boss.isFlying = true;

        moveSpot = GameObject.FindWithTag("MoveSpot").GetComponent<Transform>();
        waitTime = StartWaitTime;
        moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    public void Exit()
    {
    }

    public void Update()
    {
        parent.animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

        Patrol();

        if (BossSoundReceiver.isPerceived)
            parent.ChangeState(new FlyIdleState());

        if (BossStatus.isBossDead)
            parent.ChangeState(new BossDeadState());
    }

    private void Patrol()
    {
        Vector3 relativePos = moveSpot.position - parent.transform.position;

        if (relativePos != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, rotation, parent.speed * Time.deltaTime);
        }

        parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveSpot.position, parent.speed * Time.deltaTime);

        if (Vector3.Distance(parent.transform.position, moveSpot.position) < 2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }


}
