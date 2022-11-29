using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffPrefab : MonoBehaviour
{
    public string buffType;
    public float duration;
    public float currentTime;
    public Image icon;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void Init(string type, float du)
    {
        this.buffType = type;
        duration = du;
        currentTime = duration;

        Execute();
    }

    public void Execute()
    {
        BuffUIManager.instance.onBuff.Add(this);
        StartCoroutine(Activation());
    }

    IEnumerator Activation()
    {
        while (currentTime > 0)
        {
            currentTime -= 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        currentTime = 0;
        DeActivation();
    }

    public void DeActivation()
    {
        BuffUIManager.instance.onBuff.Remove(this);
        
        Destroy(gameObject);
    }
}
