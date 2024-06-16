using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkFeedback : Feedback
{
    [SerializeField] private SpriteRenderer _targetRenderer;
    [SerializeField] private float _flashTime = 0.1f;

    private Material _targetMat;

    private readonly int _isHitHash = Shader.PropertyToID("_IsHit"); // StringToHash와 비슷한 느낌. Shader는 기본적으로 언더바가 있음

    private void Awake()
    {
        _targetMat = _targetRenderer.material; // 스프라이트 렌더러에 있는 메티리얼을 가져온다.
    }

    public override void PlayFeedback()
    {
        _targetMat.SetInt(_isHitHash, 1); // C 언어 기반이라 bool형 변수가 없음. 1 = true, 0 = false
        StartCoroutine(DelayBlink());
    }

    private IEnumerator DelayBlink()
    {
        yield return new WaitForSeconds(_flashTime);
        _targetMat.SetInt(_isHitHash, 0);
    }

    public override void StopFeedback()
    {
        StopAllCoroutines(); // 내 모노비해비어에 작동하는 모든 코루틴 종료
        _targetMat.SetInt(_isHitHash, 0);
    }
}
