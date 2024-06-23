using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int _hp;
    private float _rectXSet;
    private float _rectX;

    [SerializeField] private RectTransform _rectTransform;

    private void Awake()
    {
        _hp = Player.Instance.hp;
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        _rectTransform.anchoredPosition = new Vector3(-910, 490);
        _rectXSet = _rectTransform.anchoredPosition.x;
    }

    public void GetDamage(int hp)
    {
        _rectX = 0.625f * (_hp - hp);
        _rectXSet -= _rectX;
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(_rectXSet, 490);
    }
}
