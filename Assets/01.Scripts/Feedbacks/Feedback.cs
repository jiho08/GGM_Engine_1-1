using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feedback : MonoBehaviour // abstract : �߻� Ŭ����
{
    public abstract void PlayFeedback(); // �ڽ��� ������ ��
    public abstract void StopFeedback(); // �ڽ��� ������ ��

    private void OnDisable() // ������
    {
        StopFeedback(); // ���߱�
    }
}
