using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Gun _gunPrefab;

    public NotifyValue<Gun> currentGun;

    private Transform _playerTrm;
    private InputReader _playerInput;
    private List<Gun> _gunList;
}
