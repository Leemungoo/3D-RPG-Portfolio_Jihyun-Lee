using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
    private GameObject bSATK1_3Effect;
    private GameObject bSATK2_2Effect;
    private GameObject bSATK3_2Effect;
    private GameObject bSATK3_3Effect;

    private void Start()
    {
        bSATK1_3Effect = Resources.Load<GameObject>("BSkillAttack1-3");
        bSATK2_2Effect = Resources.Load<GameObject>("BSkillAttack2-2");
        bSATK3_2Effect = Resources.Load<GameObject>("BSkillAttack3-2");
        bSATK3_3Effect = Resources.Load<GameObject>("BSkillAttack3-3");
    }

    public void ClawAttackEffect()
    {
        Debug.Log("ClawEffect");
        EffectManager.instance.GetClawEffectInPool();
    }

    public void WingSmashEffect()
    {
        Debug.Log("WingSmashEffect");
        EffectManager.instance.GetWingSmashEffectInPool();
    }

    public void BSkillAttack1_0()
    {
        Debug.Log("BSKillAttack1_0 Effect");
        EffectManager.instance.GetBSATKEffect1_0InPool();
    }

    public void BSkillAttack1_1()
    {
        Debug.Log("BSKillAttack1_1 Effect");
        EffectManager.instance.GetBSATKEffect1_1InPool();
    }

    public void BSkillAttack1_2()
    {
        Debug.Log("BSKillAttack1_2 Effect");
        EffectManager.instance.GetBSATKEffect1_2InPool();
    }

    public void BSkillAttack1_3()
    {
        Debug.Log("BSKillAttack1_3 Effect");

        Vector3 effectSpawnPoint;
        effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform.position;
        GameObject effect = Instantiate<GameObject>(bSATK1_3Effect, effectSpawnPoint, Quaternion.identity);
        Destroy(effect, 8.0f);
    }

    public void BSkillAttack2_0()
    {
        Debug.Log("BSKillAttack2_0 Effect");
        EffectManager.instance.GetBSATKEffect2_0InPool();
    }

    public void BSkillAttack2_1()
    {
        Debug.Log("BSKillAttack2_1 Effect");
        EffectManager.instance.GetBSATKEffect2_1InPool();
    }

    public void BSkillAttack2_2()
    {
        Debug.Log("BSKillAttack2_2 Effect");

        Vector3 effectSpawnPoint;
        effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform.position;
        GameObject effect = Instantiate<GameObject>(bSATK2_2Effect, effectSpawnPoint, Quaternion.identity);
        Destroy(effect, 8.0f);
    }

    public void BSkillAttack3_0()
    {
        Debug.Log("BSKillAttack3_0 Effect");
        EffectManager.instance.GetBSATKEffect3_0InPool();
    }

    public void BSkillAttack3_1()
    {
        Debug.Log("BSKillAttack3_1 Effect");
        EffectManager.instance.GetBSATKEffect3_1InPool();
    }

    public void BSkillAttack3_2()
    {
        Debug.Log("BSKillAttack3_2 Effect");

        Vector3 effectSpawnPoint;
        effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform.position;
        GameObject effect = Instantiate<GameObject>(bSATK3_2Effect, effectSpawnPoint + transform.forward * -4, transform.localRotation);
        Destroy(effect, 8.0f);
    }

    public void BSkillAttack3_3()
    {
        Debug.Log("BSKillAttack3_3 Effect");

        Vector3 effectSpawnPoint;
        effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform.position;
        GameObject effect = Instantiate<GameObject>(bSATK3_3Effect, effectSpawnPoint, Quaternion.identity);
        Destroy(effect, 8.0f);
    }
}


