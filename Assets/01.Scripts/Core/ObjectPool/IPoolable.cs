using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable // interface : MonoBehaviour�� ����� class ��� interface ����
{
    public string PoolName { get; } // interface������ ���� ������ �ȵǱ� ������ getter�� �ż��� ���
    public GameObject ObjectPrefab { get; }
    public void ResetItem();
}
