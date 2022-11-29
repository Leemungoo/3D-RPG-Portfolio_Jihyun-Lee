using System.Collections;
using UnityEngine;

public class BossAttackState : IState
{
    private Boss parent;
    private int prob; // ���� ��ų Ȯ��
    private float attackCooltime = 5.0f;

    public void Enter(Boss parent)
    {
        Debug.Log("BossAttackState ����");

        this.parent = parent;
        parent.navMeshAgent.isStopped = true;
        parent.hpBarPos.SetActive(true); // ���ݻ��� ���Խ� Boss hpBar Ȱ��ȭ
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

            //���� �����Ÿ� ������ �÷��̾ ���� ȸ��
            if (distance < parent.attackDistance)
            {
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                parent.transform.localRotation = Quaternion.Lerp(parent.transform.localRotation, rotation, parent.rotationSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator BossAttack(float attackCooltime)
    {
        Debug.Log("�ڷ�ƾ ����");

        prob = Random.Range(0, 100); // 0~99 ������ ���� int �� ����

        if (prob < 50) // 50% Ȯ���� ��������
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


