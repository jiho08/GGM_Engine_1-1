using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Feedback : MonoBehaviour // abstract : 추상 클래스
{
    public abstract void PlayFeedback(); // 자식이 구현할 것
    public abstract void StopFeedback(); // 자식이 구현할 것

    private void OnDisable() // 꺼지면
    {
        StopFeedback(); // 멈추기
    }
}
