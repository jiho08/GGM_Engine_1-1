using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingBar : MonoBehaviour
{
    [SerializeField] private float _rotationValue = 5f;

    private void Update()
    {
        Spin();
    }

    private void Spin()
    {
        transform.localEulerAngles += new Vector3(0, 0, _rotationValue);
    }
}
