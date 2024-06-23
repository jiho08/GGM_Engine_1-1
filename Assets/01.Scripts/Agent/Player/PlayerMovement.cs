using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoSingleton<PlayerMovement>
{
    [Header("[ Settings ]")]
    [SerializeField] private float _moveSpeedSet = 5f;
    [SerializeField] private float _turnSpeed = 15f;
    [SerializeField] private float _jumpTime = 0.3f;
    [SerializeField] private float _jumpPower = 1f;
    [SerializeField] private float _jumpCooltimeSet = 0.7f;
    [SerializeField] private float _jumpLayerDelay = 0.1f;
    [SerializeField] private float _knockbackTime = 0.2f;
    [SerializeField] private Transform directionTrm;
    [SerializeField] private GameObject _startText;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [field: SerializeField] public InputReader PlayerInput { get; private set; }

    public Rigidbody2D RbCompo { get; private set; }

    public bool canMove = true;
    public bool canJump = true;
    public bool isStart = false;
    public bool isDead = false;
    public bool ready = true;

    public UnityEvent JumpEvent;

    private float _moveSpeed;
    private float _jumpCooltime;
    private Coroutine _kbCoroutine;
    private Tween _jumpTween;
    private System.Random _rand = new System.Random();
    private Animator _animator;

    private readonly int _isDeadHash = Animator.StringToHash("IsDead");

    private int _jumpingLayer;
    private int _playerLayer;

    public void Initialize()
    {
        RbCompo = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _jumpingLayer = LayerMask.NameToLayer("Jumping");
        _playerLayer = LayerMask.NameToLayer("Player");
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        PlayerInput.JumpKeyEvent += Jump;
    }

    private void OnDisable()
    {
        PlayerInput.JumpKeyEvent -= Jump;
    }

    private void Start()
    {
        _moveSpeed = _moveSpeedSet;
    }

    private void FixedUpdate()
    {
        ApplyMovement(directionTrm, transform, _moveSpeed);
        CarRotation();
        JumpCooltime();
    }

    public void ApplyMovement(Transform pos, Transform mypos, float moveSpeed)
    {
        if (!canMove || !isStart || isDead)
            return;

        Vector3 direction = pos.position - mypos.position;
        // transform.localPosition += direction * moveSpeed * Time.deltaTime;
        RbCompo.velocity = direction * moveSpeed;
    }

    private void CarRotation()
    {
        if (!canMove || !isStart || isDead)
            return;

        if (PlayerInput.Movement.x > 0)
        {
            transform.localEulerAngles -= new Vector3(0, 0, 5 * _turnSpeed * Time.deltaTime);
        }
        else if (PlayerInput.Movement.x < 0)
        {
            transform.localEulerAngles += new Vector3(0, 0, 5 * _turnSpeed * Time.deltaTime);
        }
    }

    private void FirstSpaceKey()
    {
        isStart = true;
        canJump = true;
        canMove = true;
        _startText.SetActive(false);
    }

    private void Restart()
    {
        _startText.SetActive(true);
        isDead = false;
        isStart = false;
        _playerAnimator.Restart();
        ready = true;

    }

    #region มกวม

    private void JumpCooltime()
    {
        _jumpCooltime -= Time.deltaTime;

        if (_jumpCooltime >= 0)
        {
            canJump = false;
        }
        else if (_jumpCooltime <= 0)
        {
            canJump = true;
            _jumpCooltime = 0;
        }
    }

    private void Jump()
    {
        if (isDead && !_timerText.enabled)
        {
            Restart();
            return;
        }
        if (!isStart && ready && _spriteRenderer.sprite.name == "Car blue")
        {
            FirstSpaceKey();
            return;
        }

        if (!canMove || !canJump)
            return;

        gameObject.tag = "Jumping";
        gameObject.layer = _jumpingLayer;

        JumpEvent?.Invoke();
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        Vector3 pos = new Vector3(0.3f, 0.3f);
        Vector2 power = new Vector2(0, _jumpPower);

        canJump = false;
        _jumpCooltime = _jumpCooltimeSet + _jumpTime;
        _jumpTween = transform.GetChild(0).DOScale(transform.GetChild(0).localScale + pos, _jumpTime).SetLoops(2, LoopType.Yoyo);
        _moveSpeed += power.y * _rand.Next(1, 3);

        yield return new WaitForSeconds(_jumpTime);

        _moveSpeed = _moveSpeedSet;

        yield return new WaitForSeconds(_jumpLayerDelay);

        gameObject.tag = "Player";
        gameObject.layer = _playerLayer;
    }

    #endregion

    #region ณหน้

    public void GetKnockback(Vector3 direction, float power)
    {
        Vector3 difference = direction * power * RbCompo.mass;
        RbCompo.velocity = difference;

        if (_kbCoroutine != null)
            StopCoroutine(_kbCoroutine);

        _kbCoroutine = StartCoroutine(KnockbackCoroutine());
    }

    private IEnumerator KnockbackCoroutine()
    {
        canMove = false;
        yield return new WaitForSeconds(_knockbackTime);
        RbCompo.velocity = Vector2.zero;
        canMove = true;
    }

    public void ClearKnockback()
    {
        RbCompo.velocity = Vector2.zero;
        canMove = true;
    }

    #endregion
}
