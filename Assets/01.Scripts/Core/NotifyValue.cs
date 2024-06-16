using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // ����ȭ �����ϴ� �˷���
public class NotifyValue<T> // <T> �� ���׸� �����̴�. (T ���� �� �� �ᵵ ��) �̰� ���� ������ �Ϲ�ȭ ���α׷����� ���ؼ���. int �� ���� float ���� ���� �� �ְ� �ϱ� ����
{
    public delegate void ValueChanged(T prev, T next);

    public event ValueChanged OnValueChanged; // �� �ڵ��ϰ� ����

    // public event Action<T, T> OnValueChanged;

    [SerializeField] private T _value; // SerializeField�� �ٿ� �� �༮�� ����ȭ �ϰڴٰ� �˷��ش�

    public T Value
    {
        // get => _value; // ���ٽ� : �����ϴ� �� �ܼ�ȭ ����
        get
        {
            return _value;
        }

        set
        {
            T before = _value;
            _value = value;

            if ((before == null && value != null) || !before.Equals(_value)) // �� ���� null�̸� Equals�� �ȵ�. �׷��� ������ �ϳ� �� ���� �� Equals�� ������ ���ϴ� ��
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
