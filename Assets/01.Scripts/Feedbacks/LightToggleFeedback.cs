using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightToggleFeedback : Feedback // Feedback 상속
{
    [SerializeField] private float _blinkTime = 0.05f; // _ws 시간
    [SerializeField] private Light2D _targetLight;

    private WaitForSeconds _ws; // 라이트 지속 시간

    private void Awake()
    {
        _ws = new WaitForSeconds(_blinkTime);
    }

    public override void PlayFeedback() // 구현
    {
        StartCoroutine(ToggleCoroutine()); // 코루틴 시작
    }

    private IEnumerator ToggleCoroutine() // 라이트 토글 코루틴
    {
        _targetLight.enabled = true;
        yield return _ws;
        _targetLight.enabled = false;
    }

    public override void StopFeedback() // 구현
    {
        StopAllCoroutines(); // 코루틴 전부 정지
    }
}
