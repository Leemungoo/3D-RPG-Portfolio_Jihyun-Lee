using UnityEngine;

public class BossSoundReceiver : SoundReceiver
{
    public static bool isPerceived;

    public override void Receive(float intensity, Vector3 position)
    {
        isPerceived = true;
    }

    private void Start()
    {
        soundThreshold = 60;
        isPerceived = false;
    }
}
