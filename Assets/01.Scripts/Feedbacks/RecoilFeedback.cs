using DG.Tweening; // DOTween 쓸 때 사용
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilFeedback : Feedback // Feedback 상속
{
    [SerializeField] private Transform _targetTrm;
    [SerializeField] private float _recoilAmount = 0.15f, _recoilTime = 0.05f;

    private Vector3 _initPos;
    private Tween _recoilTween; // 반동 트윈

    private void Awake()
    {
        _initPos = _targetTrm.localPosition; // 처음 시작 시 로컬 위치 저장
    }

    public override void PlayFeedback()
    {
        float targetX = _initPos.x - _recoilAmount;
        _recoilTween = _targetTrm.DOLocalMoveX(targetX, _recoilTime).SetEase(Ease.OutQuint).SetLoops(2, LoopType.Yoyo);
        // targetX 지점까지 _recoilTime 동안 진행. Yoyo로 루프. SetEase : Easing 함수를 이용하는 것
    }

    public override void StopFeedback()
    {
        if (_recoilTween != null && _recoilTween.IsActive())
        {
            _recoilTween.Kill(); // 죽이고
            _targetTrm.position = _initPos; // 로컬 위치로 초기화
        }
    }
}
