using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))] // ImpulseFeedback을 붙이면 얘도 자동으로 같이 붙어짐
public class ImpulseFeedback : Feedback
{
    [SerializeField] private float _impulsePower = 0.3f;

    private CinemachineImpulseSource _source;

    private void Awake()
    {
        _source = GetComponent<CinemachineImpulseSource>();
    }

    public override void PlayFeedback()
    {
        _source.GenerateImpulse(_impulsePower);
    }

    public override void StopFeedback()
    {

    }
}
