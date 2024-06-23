using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    [SerializeField] protected GameObject tar;
    [SerializeField] protected float folowTime = 0.1f;

    protected SpriteRenderer tsr;
    protected SpriteRenderer msr;

    private void Awake()
    {
        if (tar == null)
        {
            Debug.LogWarning("Can't Find Target Transform");
            return;
        }
        msr = GetComponent<SpriteRenderer>();
        tsr = tar.transform.Find("Visual").GetComponent<SpriteRenderer>();

        msr.sprite = tsr.sprite;
        msr.color = tsr.color;
    }

    private void Update()
    {
        if (tar.transform.position != transform.position)
        {
            transform.DOMove(tar.transform.position, folowTime);
        }
    }
}
