using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkFeedback : Feedback
{
    [SerializeField] private SpriteRenderer _targetRenderer;
    [SerializeField] private float _flashTime = 0.1f;

    private Material _targetMat;

    private readonly int _isHitHash = Shader.PropertyToID("_IsHit"); // StringToHash�� ����� ����. Shader�� �⺻������ ����ٰ� ����

    private void Awake()
    {
        _targetMat = _targetRenderer.material; // ��������Ʈ �������� �ִ� ��Ƽ������ �����´�.
    }

    public override void PlayFeedback()
    {
        _targetMat.SetInt(_isHitHash, 1); // C ��� ����̶� bool�� ������ ����. 1 = true, 0 = false
        StartCoroutine(DelayBlink());
    }

    private IEnumerator DelayBlink()
    {
        yield return new WaitForSeconds(_flashTime);
        _targetMat.SetInt(_isHitHash, 0);
    }

    public override void StopFeedback()
    {
        StopAllCoroutines(); // �� �����غ� �۵��ϴ� ��� �ڷ�ƾ ����
        _targetMat.SetInt(_isHitHash, 0);
    }
}
