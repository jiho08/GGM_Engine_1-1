using DG.Tweening; // DOTween �� �� ���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilFeedback : Feedback // Feedback ���
{
    [SerializeField] private Transform _targetTrm;
    [SerializeField] private float _recoilAmount = 0.15f, _recoilTime = 0.05f;

    private Vector3 _initPos;
    private Tween _recoilTween; // �ݵ� Ʈ��

    private void Awake()
    {
        _initPos = _targetTrm.localPosition; // ó�� ���� �� ���� ��ġ ����
    }

    public override void PlayFeedback()
    {
        float targetX = _initPos.x - _recoilAmount;
        _recoilTween = _targetTrm.DOLocalMoveX(targetX, _recoilTime).SetEase(Ease.OutQuint).SetLoops(2, LoopType.Yoyo);
        // targetX �������� _recoilTime ���� ����. Yoyo�� ����. SetEase : Easing �Լ��� �̿��ϴ� ��
    }

    public override void StopFeedback()
    {
        if (_recoilTween != null && _recoilTween.IsActive())
        {
            _recoilTween.Kill(); // ���̰�
            _targetTrm.position = _initPos; // ���� ��ġ�� �ʱ�ȭ
        }
    }
}
