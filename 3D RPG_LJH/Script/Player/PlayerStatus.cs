using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : CharacterParameters
{ 
  public float currHP; //���� HP
  public static float currATK; // ���� ���ݷ�
  public float currDEF; // ���� ����

    private float atkBuffCooltime = 10.0f;
    private float defBuffCooltime = 10.0f;
    private float atkCurrTime = 0f;
    private float defCurrTime = 0f;

    private bool isTakingDamage = false;
    public static bool isControllable = true;

    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;

    private GameObject atkBuffEffect;
    private GameObject defBuffEffect;
    private Image hpBar;
    private Sprite icon;

    public override void InitParams()
    {
        XMLManager.instance.LoadPlayerParamsFromXML(this);
    }

    void Start()
    {
        atkBuffEffect = Resources.Load<GameObject>("PAtkBuff");
        defBuffEffect = Resources.Load<GameObject>("PDefBuff");
        hpBar = GameObject.FindGameObjectWithTag("HP bar_player")?.GetComponent<Image>();

        currHP = maxHP; // HP �ʱ�ȭ
        currATK = initATK; // ���ݷ� �ʱ�ȭ
        currDEF = initDEF; // ���� �ʱ�ȭ

        DisplayHealth();
    }

    void Update()
    {
        if (PlayerMovement.isGrounded)
            SpellBuff();

        if (currHP <= 0.0f)
            PlayerDie();
    }

    private void PlayerDie()
    {
        Debug.Log("Player Die!");

        OnPlayerDie();
        PlayerMovement.playerAnimator.Play("Death");

        GameManager.instance.IsGameOver = true;
    }

    void DisplayHealth()
    {
        hpBar.fillAmount = currHP / maxHP;
    }

    #region Buff/Debuff
    private void SpellBuff()
    {
        if (atkCurrTime <= 0)
            SpellATKBuff(ref currATK);

        if (defCurrTime <= 0)
            SpellDEFBuff(ref currDEF);
    }

    private float SpellATKBuff(ref float currATK) // 10�ʰ� ���ݷ� 0.5 ����
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("ATK buff");

            atkCurrTime = atkBuffCooltime;
            PlayerMovement.playerAnimator.Play("ATK Buff");
            BuffUIManager.instance.CreateBuff("ATKBuff", 10f, icon);

            StartCoroutine(ATKbuff());
            StartCoroutine(ATKbuffTimer());
        }
        return currATK;
    }

    private float SpellDEFBuff(ref float currDEF) // 10�ʰ� ���� 0.5 ����
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("DEF buff");

            defCurrTime = defBuffCooltime;
            PlayerMovement.playerAnimator.Play("DEF Buff");
            BuffUIManager.instance.CreateBuff("DEFBuff", 10f, icon);

            StartCoroutine(DEFbuff());
            StartCoroutine(DEFbuffTimer());
        }
        return currDEF;
    }

    IEnumerator ATKbuff()
    {
        CurrATK(ref currATK, 0.5f); // ���ݷ� 0.5 ����
        Debug.Log($"currATK ={currATK}");
        yield return new WaitForSeconds(10.0f);

        CurrATK(ref currATK, -0.5f); // 10�� �� ���ݷ� 0.5 ����
        Debug.Log($"currATK ={currATK}");
    }

    IEnumerator DEFbuff()
    {
        CurrDEF(ref currDEF, 0.5f); // ���� 0.5 ����
        Debug.Log($"currDEF ={currDEF}");
        yield return new WaitForSeconds(10.0f);

        CurrDEF(ref currDEF, -0.5f); // 10�� �� ���� 0.5 ����
        Debug.Log($"currDEF ={currDEF}");
    }

    IEnumerator ATKbuffTimer()
    {
        while (atkCurrTime > 0)
        {
            atkCurrTime -= 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        atkCurrTime = 0;
    }

    IEnumerator DEFbuffTimer()
    {
        while (defCurrTime > 0)
        {
            defCurrTime -= 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        defCurrTime = 0;
    }

    // ���ݷ� ����
    float CurrATK(ref float currATK, float calATK)
    {
        if (currATK == initATK)
            currATK = initATK + calATK;
        else
            currATK += calATK;

        Debug.Log($"Calculated currATK = {currATK}");

        return currATK;
    }

    // ���� ����
    float CurrDEF(ref float currDEF, float calDEF)
    {
        if (currDEF == initDEF)
            currDEF = initDEF - calDEF;
        else
            currDEF -= calDEF;

        Debug.Log($"Calculated currDEF = {currDEF}");

        return currDEF;
    }
    #endregion

    #region �÷��̾� �ǰ�
    void OnParticleCollision(GameObject particle)
    {
        switch (particle.tag)
        {
            case "BClawATK" when currHP >= 0.0f:

                PlayerMovement.playerAnimator.Play("Damaged");
                //EffectManager.instance.GetBloodEffectInPool();

                currHP -= 5.0f * currDEF;
                Debug.Log($"Player hp = {currHP}");

                // 5�ʰ� -1hp/��(����������) 
                isTakingDamage = true;
                StartCoroutine(ContinuousDamage(5.0f));
                break;


            case "BWingSmashATK" when currHP >= 0.0f:

                PlayerMovement.playerAnimator.Play("Damaged");

                currHP -= 5.0f * currDEF;

                DisplayHealth();
                Debug.Log($"Player hp = {currHP}");
                break;


            case "BSkillATK1" when currHP >= 0.0f:

                PlayerMovement.playerAnimator.Play("Damaged");

                currHP -= 10.0f * currDEF;

                DisplayHealth();
                Debug.Log($"Player hp = {currHP}");
                break;


            case "BSkillATK2" when currHP >= 0.0f:

                Debug.Log("SkillATK2 Particle Collision");

                PlayerMovement.playerAnimator.Play("Damaged");

                // 5�ʰ� �̵��Ұ�
                isControllable = false;
                StartCoroutine(FreezPosition(5.0f));

                // 5�ʰ� -1hp/��
                isTakingDamage = true;
                StartCoroutine(ContinuousDamage(5.0f));
                break;


            case "BSkillATK3" when currHP >= 0.0f:

                Debug.Log("SkillATK3 Particle Collision");

                PlayerMovement.playerAnimator.Play("Damaged");

                currHP -= 10.0f * currDEF;

                Debug.Log($"Player hp = {currHP}");
                DisplayHealth();
                break;
        }
    }

    private IEnumerator ContinuousDamage(float damagingTimeLimit)
    {
        Debug.Log("���ӵ����� ����");
        float damagingTime = 0.0f;
        while (isTakingDamage == true && damagingTime < damagingTimeLimit)
        {
            currHP -= 1.0f * currDEF;
            DisplayHealth();
            Debug.Log($"Player hp = {currHP}");
            damagingTime += 1.0f;
            yield return new WaitForSeconds(1.0f);
        }

        isTakingDamage = false;
        Debug.Log("���ӵ����� ����");
        yield return null;
    }

    private IEnumerator FreezPosition(float freezingTimeLimit)
    {
        Debug.Log("�̵��Ұ� ����");
        float freezingTime = 0.0f;
        while (isControllable == false && freezingTime < freezingTimeLimit)
        {
            freezingTime += 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        isControllable = true;
        Debug.Log("�̵��Ұ� ����");
    }
    #endregion
}


