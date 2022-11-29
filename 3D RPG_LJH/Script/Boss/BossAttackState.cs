using System.Collections;
using UnityEngine;

public class BossAttackState : IState
{
    private Boss parent;
    private int prob; // 랜덤 스킬 확률
    private float attackCooltime = 5.0f;

    public void Enter(Boss parent)
    {
        Debug.Log("BossAttackState 진입");

        this.parent = parent;
        parent.navMeshAgent.isStopped = true;
        parent.hpBarPos.SetActive(true); // 공격상태 진입시 Boss hpBar 활성화
        CoroutineHost.StartCoroutine(BossAttack(attackCooltime));
    }

    public void Exit()
    {
        parent.navMeshAgent.isStopped = false;
        CoroutineHost.StopCoroutine(BossAttack(attackCooltime));
    }

    public void Update()
    {
        parent.animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

        float distance = Vector3.Distance(parent.target.position, parent.transform.position);

        RotateToTarget();
  
            if (distance > parent.attackDistance)
            {
                parent.ChangeState(new GroundIdleState());
            }
    }

    private void RotateToTarget()
    {
        if (parent.target != null)
        {
            float distance = Vector3.Distance(parent.target.position, parent.transform.position);
            Vector3 relativePos = parent.target.position - parent.transform.position;

            //공격 사정거리 내에서 플레이어를 향해 회전
            if (distance < parent.attackDistance)
            {
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                parent.transform.localRotation = Quaternion.Lerp(parent.transform.localRotation, rotation, parent.rotationSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator BossAttack(float attackCooltime)
    {
        Debug.Log("코루틴 시작");

        prob = Random.Range(0, 100); // 0~99 사이의 랜덤 int 값 생성

        if (prob < 50) // 50% 확률로 물리공격
        {
            prob = Random.Range(0, 100);

            if (prob < 50)
            {
                if (!parent.animator.GetCurrentAnimatorStateInfo(0).IsName("ClawAttack"))
                {
                    parent.animator.SetTrigger("ClawAttack");
                    Debug.Log("ClawAttack");
                }
            }
            else
            {
                if (!parent.animator.GetCurrentAnimatorStateInfo(0).IsName("WingSmash"))
                {
                    parent.animator.SetTrigger("WingSmash");
                    Debug.Log("WingSmash");
                }
            }
        }

        else 
        {
            prob = Random.Range(0, 100);

            if (prob < 33)
            {
                if (!parent.animator.GetCurrentAnimatorStateInfo(0).IsName("SkillAttack1-3"))
                {
                    parent.animator.SetTrigger("SkillAttack1");
                    Debug.Log("SkillAttack1");
                }
            }
            else if (prob < 67)
            {
                if (!parent.animator.GetCurrentAnimatorStateInfo(0).IsName("SkillAttack2-3"))
                {
                    parent.animator.SetTrigger("SkillAttack2");
                    Debug.Log("SkillAttack2");
                }
            }
            else
            {
                if (!parent.animator.GetCurrentAnimatorStateInfo(0).IsName("SkillAttack3-3"))
                {
                    parent.animator.SetTrigger("SkillAttack3");
                    Debug.Log("SkillAttack3");
                }
            }
        }

        yield return new WaitForSeconds(attackCooltime);

        CoroutineHost.StartCoroutine(BossAttack(attackCooltime));
    }
}


