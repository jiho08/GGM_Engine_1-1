using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable // interface : MonoBehaviour를 지우고 class 대신 interface 쓰기
{
    public string PoolName { get; } // interface에서는 변수 선언이 안되기 때문에 getter로 매서드 취급
    public GameObject ObjectPrefab { get; }
    public void ResetItem();
}
