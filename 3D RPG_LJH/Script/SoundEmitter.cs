using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    private float soundIntensity = 100.0f; //���� ����
    private float soundAttenuation = 1.0f; //���� ����
    public GameObject emitterObject;
    public GameObject receiverObject;

    private Dictionary<int, SoundReceiver> receiverDic;

    private void Start()
    {
        receiverDic = new Dictionary<int, SoundReceiver>(); //���ù� ����Ʈ �ʱ�ȭ
        if (emitterObject == null)
            emitterObject = gameObject;

        AddReceiver(receiverObject);
    }

    public void Update()
    {
        Emit();

        if (GameManager.isPlayerDie || BossStatus.isBossDead)
        {
            DeleteReceiver(receiverObject); // ���� ��� �� �ش� ���ù� item ��ųʸ����� ����
        }
    }

    public void AddReceiver(GameObject rs)
    {
        SoundReceiver receiver;
        receiver = rs.gameObject.GetComponent<SoundReceiver>();
        if (receiver == null)
            return;

        int objID = gameObject.GetInstanceID();
        receiverDic.Add(objID, receiver);

        Debug.Log($"SoundThreshold = {receiver.soundThreshold}");
    }

    public void DeleteReceiver(GameObject rs)
    {
        SoundReceiver receiver;
        receiver = rs.gameObject.GetComponent<SoundReceiver>();
        if (receiver == null)
            return;

        int objID = rs.gameObject.GetInstanceID();
        receiverDic.Remove(objID);
    }

    public void Emit()
    {
        GameObject receiver;
        Vector3 receiverPos;
        float intensity;
        float distance;
        Vector3 emitterPos = emitterObject.transform.position;

        foreach (SoundReceiver soundreceiver in receiverDic.Values)
        {
            receiver = soundreceiver.gameObject;
            receiverPos = receiver.transform.position;
            distance = Vector3.Distance(receiverPos, emitterPos);
            intensity = soundIntensity;
            intensity -= soundAttenuation * distance;
            Debug.Log($"intensity ={intensity}");

            if (intensity < soundreceiver.soundThreshold)
                continue;
            soundreceiver.Receive(intensity, emitterPos);
        }
    }
}
