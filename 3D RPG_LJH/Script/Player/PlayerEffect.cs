using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public void SlashEffect1()
    {
        EffectManager.instance.GetSlashEffect1InPool();
    }

    public void SlashEffect2()
    {
        EffectManager.instance.GetSlashEffect2InPool();
    }

    public void TornadoEffect()
    {
        EffectManager.instance.GetTornadoEffectInPool();
    }

    public void Fly1_0Effect()
    {
        EffectManager.instance.GetFly1_0EffectInPool();
    }

    public void Fly1_1Effect()
    {
        EffectManager.instance.GetFly1_1EffectInPool();
    }

    public void ATKBuffEffect()
    {
        EffectManager.instance.GetAtkBuffEffectInPool();
    }

    public void DEFBuffEffect()
    {
        EffectManager.instance.GetDefBuffEffectInPool();
    }
}
