using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private int selectedWeapon = 0;
    private float delayTime = 2.0f;
    private bool isSwitching = false;

    private Dictionary<string, GameObject> Axes = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> Bomb = new Dictionary<string, GameObject>();

    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject FireBomb;

    private void Start()
    {
        Axes.Add("Axe", axe);
        Bomb.Add("MagicBomb", FireBomb);

        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (!isSwitching)
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Mouse ScrollWheel") > 0f) 
            {
                Debug.Log("무기 교체(scroll up)");

                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;

                StartCoroutine(SwitchDelay());
            }

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Debug.Log("무기 교체(scroll down)");

                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;

                StartCoroutine(SwitchDelay());
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                PlayerMovement.playerAnimator.Play("EquipWeapon");
                SelectWeapon();
            }
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    private IEnumerator SwitchDelay()
    {
        Debug.Log("Switch Delay");

        isSwitching = true;
        yield return new WaitForSeconds(delayTime);
        isSwitching = false;
    }
}
