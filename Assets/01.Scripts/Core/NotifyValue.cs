using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // 직렬화 가능하다 알려줌
public class NotifyValue<T> // <T> 는 제네릭 문자이다. (T 말고 딴 거 써도 됨) 이걸 쓰는 이유는 일반화 프로그래밍을 위해서임. int 값 말고 float 등을 받을 수 있게 하기 위해
{
    public delegate void ValueChanged(T prev, T next);

    public event ValueChanged OnValueChanged; // 밑 코드하고 같다

    // public event Action<T, T> OnValueChanged;

    [SerializeField] private T _value; // SerializeField를 붙여 이 녀석을 직렬화 하겠다고 알려준다

    public T Value
    {
        // get => _value; // 람다식 : 구독하는 걸 단순화 해줌
        get
        {
            return _value;
        }

        set
        {
            T before = _value;
            _value = value;

            if ((before == null && value != null) || !before.Equals(_value)) // 전 값이 null이면 Equals가 안됨. 그래서 조건을 하나 더 만든 것 Equals는 같은지 비교하는 거
            {
                OnValueChanged?.Invoke(before, _value);
            }
        }
    }

    public NotifyValue()
    {
        _value = default(T);
    }

    public NotifyValue(T value)
    {
        _value = value;
    }
}
