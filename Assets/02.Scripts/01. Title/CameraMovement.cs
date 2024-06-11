using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform _SettingPosition;
    [SerializeField] Transform _BackPosition;
    private bool _checkSettingAndBack;

    public static CameraMovement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void FixedUpdate()
    {
        /* if (_checkSettingAndBack)
        {
            transform.position = Vector3.Slerp(gameObject.transform.position, _SettingPosition.transform.position, 0.05f);
        }
        if (!_checkSettingAndBack)
        {
            transform.position = Vector3.Slerp(gameObject.transform.position, _BackPosition.transform.position, 0.05f);
        } */
    }

    public void ClickSetting()
    {
        _checkSettingAndBack = true;
    }

    public void ClickBack()
    {
        _checkSettingAndBack = false;
    }
}
