using System.Collections.Generic;
using UnityEngine;

public class BuffUIManager : MonoBehaviour
{
    public static BuffUIManager instance;

    public List<BuffPrefab> onBuff = new List<BuffPrefab>();

    public GameObject buffPrefabs;
    private Sprite ATKBuffIcon;
    private Sprite DEFBuffIcon;

    private void Awake()
    {
        instance = this;

        ATKBuffIcon = Resources.Load<Sprite>("UI/ATKBuff");
        DEFBuffIcon = Resources.Load<Sprite>("UI/DEFBuff");
    }

    public void CreateBuff(string type, float du, Sprite icon)
    {
        GameObject gameObject = Instantiate(buffPrefabs, transform);
        gameObject.GetComponent<BuffPrefab>().Init(type, du);

        switch (type)
        {
            case "ATKBuff":
                icon = ATKBuffIcon;
                break;

            case ("DEFBuff"):
                icon = DEFBuffIcon;
                break;
        }        

        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = icon;
    }
}
