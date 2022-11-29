using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParameters : MonoBehaviour
{
    public float maxHP;
    public float initATK;
    public float initDEF;

    void Start()
    {
        InitParams();
    }

    public virtual void InitParams()
    {
    }
}
