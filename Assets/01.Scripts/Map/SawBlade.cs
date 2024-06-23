using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private float _rotationValue = 5f;

    private void Update()
    {
        Spin();
    }

    private void Spin()
    {
        transform.GetChild(0).localEulerAngles += new Vector3(0, 0, _rotationValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAnimator.Instance.OnDeadExplosion();
        }
    }
}
