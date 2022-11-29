using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTimerUI : MonoBehaviour
{
    public Text timeText;

    float time = 10f;
    int sec;

    private void Start()
    {
        timeText.text = "10";
    }

    private void Update()
    {
        time -= Time.deltaTime; 
        sec = (int)time; 

        if (sec <= 0)
            timeText.text = 0.ToString();

        else
            timeText.text = sec.ToString();
    }
}
