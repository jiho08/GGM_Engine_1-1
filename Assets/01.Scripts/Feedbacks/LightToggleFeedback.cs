using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightToggleFeedback : Feedback // Feedback ���
{
    [SerializeField] private float _blinkTime = 0.05f; // _ws �ð�
    [SerializeField] private Light2D _targetLight;

    private WaitForSeconds _ws; // ����Ʈ ���� �ð�

    private void Awake()
    {
        _ws = new WaitForSeconds(_blinkTime);
    }

    public override void PlayFeedback() // ����
    {
        StartCoroutine(ToggleCoroutine()); // �ڷ�ƾ ����
    }

    private IEnumerator ToggleCoroutine() // ����Ʈ ��� �ڷ�ƾ
    {
        _targetLight.enabled = true;
        yield return _ws;
        _targetLight.enabled = false;
    }

    public override void StopFeedback() // ����
    {
        StopAllCoroutines(); // �ڷ�ƾ ���� ����
    }
}
