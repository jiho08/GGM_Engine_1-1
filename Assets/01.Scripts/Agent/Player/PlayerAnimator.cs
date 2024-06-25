using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _deadUI;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Player _player;
    [SerializeField] private int _deadCamPriority = 11;

    public static PlayerAnimator Instance;

    public Animator _animator;

    private readonly int _isDeadHash = Animator.StringToHash("IsDead");
    private int _deadLayer;
    private int _playerLayer;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _animator = GetComponent<Animator>();
        _deadLayer = LayerMask.NameToLayer("DeadBody");
        _playerLayer = LayerMask.NameToLayer("Player");
    }

    public void OnDeadExplosion()
    {
        _virtualCamera.Priority = _deadCamPriority;
        _deadUI.SetActive(true);
        PlayerMovement.Instance.ready = false;
        PlayerMovement.Instance.isDead = true;
        PlayerMovement.Instance.gameObject.layer = _deadLayer;
        PlayerMovement.Instance.canMove = false;
        PlayerMovement.Instance.RbCompo.velocity = Vector3.zero;
        transform.localScale = new Vector3(2.5f, 2.5f);
        _animator.SetBool(_isDeadHash, true);
    }

    public void EndExplosion()
    {
        Player.Instance.OnDead();
    }

    public void Restart()
    {
        _animator.SetBool(_isDeadHash, false);
        _virtualCamera.Priority = 9;
        _deadUI.SetActive(false);
        PlayerMovement.Instance.gameObject.layer = _playerLayer;
        transform.localScale = new Vector3(1, 1);

        _player.Restart();
    }
}
