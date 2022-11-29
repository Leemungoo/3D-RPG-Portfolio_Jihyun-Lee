using System;
using System.Collections;
using UnityEngine;

public class CoroutineHost : MonoBehaviour
{
    private static MonoBehaviour monoInstance;

    [RuntimeInitializeOnLoadMethod]
    private static void Initializer()
    {
        monoInstance = new GameObject($"[{nameof(CoroutineHost)}]").AddComponent<CoroutineHost>();
        DontDestroyOnLoad(monoInstance.gameObject);
    }

    public new static Coroutine StartCoroutine(IEnumerator coroutine)
    {
        return monoInstance.StartCoroutine(coroutine);
    }

    public new static void StopCoroutine(IEnumerator coroutine)
    {
        monoInstance.StopCoroutine(coroutine);
    }
}
