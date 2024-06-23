using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSawBlade : MonoBehaviour
{
    [SerializeField] private float _rotationValue = 5f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _moveIntervalSet = 1f;
    [SerializeField] private Transform _directionTrm;

    private Rigidbody2D _rigid;

    private float _moveInterval;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SpinAndMove();
    }

    private void SpinAndMove()
    {
        
        transform.GetChild(1).localEulerAngles += new Vector3(0, 0, _rotationValue);
        _rigid.velocity = _directionTrm.position.normalized  * _moveSpeed;
        _moveInterval += Time.deltaTime;
        
        if (_moveInterval >= _moveIntervalSet)
        {
            _directionTrm.position *= -1;
            _moveInterval = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAnimator.Instance.OnDeadExplosion();
        }
    }
}
