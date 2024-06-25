using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private float _timer = 0f;

    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        PlusTime();
    }

    private void PlusTime()
    {
        if (!PlayerMovement.Instance.isStart)
            return;

        _timer += Time.deltaTime;

        _timerText.text = $"{_timer.ToString("F2")} √ ";
    }

    public void RestartTimer()
    {
        _timer = 0f;
        _timerText.text = $"{_timer.ToString("F2")} √ ";
    }
}
