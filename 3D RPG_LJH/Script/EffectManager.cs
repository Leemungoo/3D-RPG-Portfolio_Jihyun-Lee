using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    #region Player Effect
    private GameObject slashEffect1;
    private GameObject slashEffect2;
    private GameObject tornadoEffect;
    private GameObject flyEffect1_0;
    private GameObject flyEffect1_1;
    private GameObject bloodEffect;

    List<GameObject> slashEffect1Pool = new List<GameObject>();
    List<GameObject> slashEffect2Pool = new List<GameObject>();
    List<GameObject> tornadoEffectPool = new List<GameObject>();
    List<GameObject> flyEffect1_0Pool = new List<GameObject>();
    List<GameObject> flyEffect1_1Pool = new List<GameObject>();
    List<GameObject> atkBuffEffectPool = new List<GameObject>();
    List<GameObject> defBuffEffectPool = new List<GameObject>();
    List<GameObject> bloodEffectPool = new List<GameObject>();
    #endregion

    #region Boss Effect
    private GameObject atkBuffEffect;
    private GameObject defBuffEffect;
    private GameObject clawEffect;
    private GameObject wingSmashEffect;
    private GameObject bSATK1_0Effect;
    private GameObject bSATK1_1Effect;
    private GameObject bSATK1_2Effect;
    private GameObject bSATK2_0Effect;
    private GameObject bSATK2_1Effect;
    private GameObject bSATK3_0Effect;
    private GameObject bSATK3_1Effect;

    List<GameObject> clawEffectPool = new List<GameObject>();
    List<GameObject> wingSmashEffectPool = new List<GameObject>();
    List<GameObject> bSATK1_0EffectPool = new List<GameObject>();
    List<GameObject> bSATK1_1EffectPool = new List<GameObject>();
    List<GameObject> bSATK1_2EffectPool = new List<GameObject>();
    List<GameObject> bSATK2_0EffectPool = new List<GameObject>();
    List<GameObject> bSATK2_1EffectPool = new List<GameObject>();
    List<GameObject> bSATK3_0EffectPool = new List<GameObject>();
    List<GameObject> bSATK3_1EffectPool = new List<GameObject>();
    #endregion

    private int maxEffect = 5; // 오브젝트 풀에 생성할 이펙트의 최대 개수

    public static EffectManager instance = null;

    private void Awake()
    {
        #region Player Effect Road
        slashEffect1 = Resources.Load<GameObject>("PShordSlash1");
        slashEffect2 = Resources.Load<GameObject>("PShordSlash2");
        tornadoEffect = Resources.Load<GameObject>("PTornado");
        flyEffect1_0 = Resources.Load<GameObject>("PFly1-0");
        flyEffect1_1 = Resources.Load<GameObject>("PFly1-1");
        atkBuffEffect = Resources.Load<GameObject>("PAtkBuff");
        defBuffEffect = Resources.Load<GameObject>("PDefBuff");
        bloodEffect = Resources.Load<GameObject>("PBlood");
        #endregion

        #region Boss Effect Road
        clawEffect = Resources.Load<GameObject>("BClawattack");
        wingSmashEffect = Resources.Load<GameObject>("BWingSmash");
        bSATK1_0Effect = Resources.Load<GameObject>("BSkillAttack1-0");
        bSATK1_1Effect = Resources.Load<GameObject>("BSkillAttack1-1");
        bSATK1_2Effect = Resources.Load<GameObject>("BSkillAttack1-2");
        bSATK2_0Effect = Resources.Load<GameObject>("BSkillAttack2-0");
        bSATK2_1Effect = Resources.Load<GameObject>("BSkillAttack2-1");
        bSATK3_0Effect = Resources.Load<GameObject>("BSkillAttack3-0");
        bSATK3_1Effect = Resources.Load<GameObject>("BSkillAttack3-1");
        #endregion

        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
    }

    private void Start()
    {
        #region PlayerEffectPool
        CreateSlashEffect1Pool();
        CreateSlashEffect2Pool();
        CreateTornadoEffectPool();
        CreateFlyEffect1_0Pool();
        CreateFlyEffect1_1Pool();
        CreateAtkBuffEffectPool();
        CreateDefBuffEffectPool();
        CreateBloodEffectPool();
        #endregion

        #region BossEffectPool
        CreateClawEffectPool();
        CreateWingSmashEffectPool();
        CreateBSATK1_0EffectPool();
        CreateBSATK1_1EffectPool();
        CreateBSATK1_2EffectPool();
        CreateBSATK2_0EffectPool();
        CreateBSATK2_1EffectPool();
        CreateBSATK3_0EffectPool();
        CreateBSATK3_1EffectPool();
        #endregion
    }

    #region Player ObjectPool
    void CreateSlashEffect1Pool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(slashEffect1, effectSpawnPoint);
            effect.SetActive(false);
            slashEffect1Pool.Add(effect);
        }
    }

    void CreateSlashEffect2Pool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(slashEffect2, effectSpawnPoint);
            effect.SetActive(false);
            slashEffect2Pool.Add(effect);
        }
    }

    void CreateTornadoEffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect * 5; i++)
        {
            GameObject effect = Instantiate<GameObject>(tornadoEffect, effectSpawnPoint);
            effect.SetActive(false);
            tornadoEffectPool.Add(effect);
        }
    }

    void CreateFlyEffect1_0Pool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(flyEffect1_0, effectSpawnPoint);
            effect.SetActive(false);
            flyEffect1_0Pool.Add(effect);
        }
    }

    void CreateFlyEffect1_1Pool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(flyEffect1_1, effectSpawnPoint);
            effect.SetActive(false);
            flyEffect1_1Pool.Add(effect);
        }
    }

    void CreateAtkBuffEffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(atkBuffEffect, effectSpawnPoint);
            effect.SetActive(false);
            atkBuffEffectPool.Add(effect);
        }
    }

    void CreateDefBuffEffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(defBuffEffect, effectSpawnPoint);
            effect.SetActive(false);
            defBuffEffectPool.Add(effect);
        }
    }

    void CreateBloodEffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("P_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bloodEffect, effectSpawnPoint);
            effect.SetActive(false);
            bloodEffectPool.Add(effect);
        }
    }

    public GameObject GetSlashEffect1InPool()
    {
        foreach (GameObject effect in slashEffect1Pool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect; 
            }
        }
        return null;
    }

    public GameObject GetSlashEffect2InPool()
    {
        foreach (GameObject effect in slashEffect2Pool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect; 
            }
        }
        return null;
    }

    public GameObject GetTornadoEffectInPool()
    {
        foreach (GameObject effect in tornadoEffectPool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetFly1_0EffectInPool()
    {
        foreach (GameObject effect in flyEffect1_0Pool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetFly1_1EffectInPool()
    {
        foreach (GameObject effect in flyEffect1_1Pool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect; 
            }
        }
        return null;
    }

    public GameObject GetAtkBuffEffectInPool()
    {
        foreach (GameObject effect in atkBuffEffectPool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect; 
            }
        }
        return null;
    }

    public GameObject GetDefBuffEffectInPool()
    {
        foreach (GameObject effect in defBuffEffectPool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect; 
            }
        }
        return null;
    }

    public GameObject GetBloodEffectInPool()
    {
        foreach (GameObject effect in bloodEffectPool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect; 
            }
        }
        return null;
    }
    #endregion

    #region Boss ObjectPool
    void CreateClawEffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(clawEffect, effectSpawnPoint);
            effect.SetActive(false);
            clawEffectPool.Add(effect);
        }
    }

    void CreateWingSmashEffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(wingSmashEffect, effectSpawnPoint);
            effect.SetActive(false);
            wingSmashEffectPool.Add(effect);
        }
    }

    void CreateBSATK1_0EffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bSATK1_0Effect, effectSpawnPoint);
            effect.SetActive(false);
            bSATK1_0EffectPool.Add(effect);
        }
    }

    void CreateBSATK1_1EffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bSATK1_1Effect, effectSpawnPoint);
            effect.SetActive(false);
            bSATK1_1EffectPool.Add(effect);
        }
    }

    void CreateBSATK1_2EffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bSATK1_2Effect, effectSpawnPoint);
            effect.SetActive(false);
            bSATK1_2EffectPool.Add(effect);
        }
    }

    void CreateBSATK2_0EffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bSATK2_0Effect, effectSpawnPoint);
            effect.SetActive(false);
            bSATK2_0EffectPool.Add(effect);
        }
    }

    void CreateBSATK2_1EffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bSATK2_1Effect, effectSpawnPoint);
            effect.SetActive(false);
            bSATK2_1EffectPool.Add(effect);
        }
    }

    void CreateBSATK3_0EffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bSATK3_0Effect, effectSpawnPoint);
            effect.SetActive(false);
            bSATK3_0EffectPool.Add(effect);
        }
    }

    void CreateBSATK3_1EffectPool()
    {
        Transform effectSpawnPoint = GameObject.Find("B_EffectSpawnPoint").transform;

        for (int i = 0; i < maxEffect; i++)
        {
            GameObject effect = Instantiate<GameObject>(bSATK3_1Effect, effectSpawnPoint);
            effect.SetActive(false);
            bSATK3_1EffectPool.Add(effect);
        }
    }

    public GameObject GetClawEffectInPool()
    {
        foreach (GameObject effect in clawEffectPool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect; 
            }
        }
        return null; 
    }

    public GameObject GetWingSmashEffectInPool()
    {
        foreach (GameObject effect in wingSmashEffectPool)
        {
            if (effect.activeSelf == false) 
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetBSATKEffect1_0InPool()
    {
        foreach (GameObject effect in bSATK1_0EffectPool)
        {
            if (effect.activeSelf == false)
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetBSATKEffect1_1InPool()
    {
        foreach (GameObject effect in bSATK1_1EffectPool)
        {
            if (effect.activeSelf == false)
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetBSATKEffect1_2InPool()
    {
        foreach (GameObject effect in bSATK1_2EffectPool)
        {
            if (effect.activeSelf == false)
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetBSATKEffect2_0InPool()
    {
        foreach (GameObject effect in bSATK2_0EffectPool)
        {
            if (effect.activeSelf == false)
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetBSATKEffect2_1InPool()
    {
        foreach (GameObject effect in bSATK2_1EffectPool)
        {
            if (effect.activeSelf == false)
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetBSATKEffect3_0InPool()
    {
        foreach (GameObject effect in bSATK3_0EffectPool)
        {
            if (effect.activeSelf == false)
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }

    public GameObject GetBSATKEffect3_1InPool()
    {
        foreach (GameObject effect in bSATK3_1EffectPool)
        {
            if (effect.activeSelf == false)
            {
                effect.SetActive(true);
                return effect;
            }
        }
        return null;
    }
    #endregion
}

