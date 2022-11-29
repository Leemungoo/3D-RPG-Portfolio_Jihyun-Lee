using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    private float playerATK;

    private readonly float maxHP = 100.0f; //초기 HP
    private float currHP; //현재 HP
    private Image hpBar;

    public static bool isBossDead = false;

    void Start()
    {
        hpBar = GameObject.FindGameObjectWithTag("HP bar_boss")?.GetComponent<Image>();

        currHP = maxHP; // HP 초기화
        DisplayHealth();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            isBossDead = true;

        if (currHP <= 0.0f)
            isBossDead = true;

       playerATK = PlayerStatus.currATK;
    }

    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log("Collider Collision");

        if (currHP >= 0.0f && coll.collider.CompareTag("Axe"))
        {
            if(AxeController.isNormalAttacking == true)
            {
                Debug.Log("Normal Attacked");
                AxeController.isNormalAttacking = false;
                AxeController.collider.enabled = false;
                currHP -= 5.0f * playerATK;
                Debug.Log($"Enemy hp = {currHP}");
                DisplayHealth();
            }
        
            if (AxeController.isUpslashAttacking == true)
            {
                Debug.Log("Upslash Attacked");
                AxeController.isUpslashAttacking = false;
                AxeController.collider.enabled = false;
                currHP -= 10.0f * playerATK;
                Debug.Log($"Enemy hp = {currHP}");
                DisplayHealth();
            }

            if (AxeController.isTornadoAttacking == true)
            {
                Debug.Log("Tornado Attacked");
                AxeController.isTornadoAttacking = false;
                AxeController.collider.enabled = false;
                currHP -= 5.0f * playerATK;
                Debug.Log($"Enemy hp = {currHP}");
                DisplayHealth();
            }

            if (AxeController.isFlyAttacking == true)
            {
                Debug.Log("Fly Attacked");
                AxeController.isFlyAttacking = false;
                AxeController.collider.enabled = false;
                currHP -= 10.0f * playerATK;
                Debug.Log($"Enemy hp = {currHP}");
                DisplayHealth();
            }
        }

        if (currHP >= 0.0f && coll.collider.CompareTag("PBomb"))
        {
            BombAttack();
        }
    }


    void BombAttack()
    {
        Debug.Log("Bomb Collision");
        currHP -= 10.0f;
        DisplayHealth();
        Debug.Log($"Enemy hp = {currHP}");
    }

    void DisplayHealth()
    {
        hpBar.fillAmount = currHP / maxHP;
    }
}
