using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile, IPoolable
{
    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private float _lifeTime = 2f;

    private int _damage;
    private float _knockPower;
    private Vector2 _fireDirection;

    [SerializeField] private string _poolName;

    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void InitAndFire(Transform firePosTrm, int damage, float knockBackPower)
    {
        _damage = damage;
        _knockPower = knockBackPower;
        transform.SetPositionAndRotation(firePosTrm.position, firePosTrm.rotation);
        _fireDirection = firePosTrm.right;
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        _rigidBody.velocity = _fireDirection * _moveSpeed;
        _timer += Time.fixedDeltaTime;

        if (_timer >= _lifeTime)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead)
            return;

        EffectPlayer effect = PoolManager.Instance.Pop("BulletImpact") as EffectPlayer;
        effect.SetPositionAndPlay(transform.position);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        _isDead = true;
        PoolManager.Instance.Push(this);
    }
}
