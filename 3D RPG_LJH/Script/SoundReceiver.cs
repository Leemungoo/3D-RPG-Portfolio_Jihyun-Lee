using UnityEngine;

public class SoundReceiver : MonoBehaviour
{
    public float soundThreshold;

    public virtual void Receive(float intensity, Vector3 position)
    {
    }
}
