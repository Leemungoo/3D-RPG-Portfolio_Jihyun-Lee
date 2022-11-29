using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public const int numSkillSlots = 4;

    Image[] skillImages = new Image[numSkillSlots];
    GameObject[] slots = new GameObject[numSkillSlots];

    public void Start()
    {
        CreateSloats();
    }

    public void CreateSloats()
    {
        if (slotPrefab != null)
        {
            for (int i = 0; i < numSkillSlots; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "SkillSlot_" + i; 

                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);

                slots[i] = newSlot;

                skillImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }
}
