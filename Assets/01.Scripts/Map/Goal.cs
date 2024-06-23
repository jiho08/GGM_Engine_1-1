using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Goal : MonoBehaviour
{
    [SerializeField] private RectTransform _topGoalUI;
    [SerializeField] private RectTransform _bottomGoalUI;
    [SerializeField] private float _moveTime = 1f;

    private float _moveX = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Jumping"))
        {
            // UI 띄우기, 화면 연출 등
            _topGoalUI.DOAnchorPosX(_moveX, _moveTime).SetEase(Ease.OutBack);
            _bottomGoalUI.DOAnchorPosX(_moveX, _moveTime).SetEase(Ease.OutBack);
            PlayerMovement.Instance.canMove = false;
            PlayerMovement.Instance.canJump = false;
            PlayerMovement.Instance.RbCompo.velocity = Vector3.zero;

            StartCoroutine(TimeStopDelayCoroutine());
        }
    }

    private IEnumerator TimeStopDelayCoroutine()
    {
        yield return new WaitForSeconds(_moveTime);
        Time.timeScale = 0f;
    }
}
