using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeactivator : MonoBehaviour
{
    private float resetCooltime;

    private void Update()
    {
        resetCooltime -= Time.deltaTime;

        if (resetCooltime < 0)
        {
            resetCooltime = 10f;
            this.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        resetCooltime = 10f;
    }
}
