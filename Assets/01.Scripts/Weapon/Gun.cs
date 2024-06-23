using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnShootEvent;
    public UnityEvent OnEmptyClipEvent;
    public UnityEvent OnReloadEvent;

    public Transform firePosTrm;
    public GunDataSO gunData;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public NotifyValue<int> bulletCount;
    public NotifyValue<float> reloadTimer;

    private float _availableFireTime = 0;

    public void Initialize(GunDataSO gunData)
    {
        this.gunData = gunData;
        bulletCount = new NotifyValue<int>(gunData.maxAmmo);
        reloadTimer = new NotifyValue<float>(0);
        SetUpWeapon();
    }

    private void OnEnable()
    {
        OnShootEvent.AddListener(ShootProjectile);
    }

    private void OnDisable()
    {
        OnShootEvent.RemoveListener(ShootProjectile);
    }

    private void ShootProjectile()
    {
        Projectile newBullet = PoolManager.Instance.Pop("Bullet") as Projectile;
        newBullet.InitAndFire(firePosTrm, gunData.damage, gunData.knockBackPower);
    }

    public void TryToShoot()
    {
        if (_availableFireTime < Time.time)
        {
            if (bulletCount.Value <= 0)
                OnEmptyClipEvent?.Invoke();
            else
            {
                bulletCount.Value -= 1;
                OnShootEvent?.Invoke();
            }

            ResetCoolDown();
        }
    }

    private void ResetCoolDown()
    {
        _availableFireTime = Time.time + gunData.cooldown;
    }

    public void SetUpWeapon()
    {
        _spriteRenderer.sprite = gunData.gunSprite;
        _spriteRenderer.transform.localPosition = gunData.spritePosition;
        firePosTrm.localPosition = gunData.fireTrmPosition;

        gameObject.name = gunData.gunName;
    }

#if UNITY_EDITOR

    private void OnValidate()
    {
        UnityEditor.EditorApplication.delayCall += _OnValidate;
    }

    private void _OnValidate()
    {
        if (gunData != null && _spriteRenderer != null)
        {
            SetUpWeapon();
        }
    }

#endif
}
