using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoSingleton<Player>
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private GameObject _deadMark;
    [SerializeField] private GameObject _healthUI;
    [SerializeField] private GameObject _startPlace;

    public GameObject timerUI;

    public int hp = 100;

    public UnityEvent OnCollisonEvent;

    [SerializeField] private Health _health;
    [SerializeField] private Timer _timer;
    [SerializeField] private Timer _timer2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            OnCollisonEvent?.Invoke();

            OnHit();
        }
    }

    private void Start()
    {
        transform.position = _startPlace.transform.position;
        transform.rotation = _startPlace.transform.rotation;
    }

    public void OnHit()
    {
        hp -= _damage;
        _health.GetDamage(hp);

        if (hp <= 0)
        {
            PlayerAnimator.Instance.OnDeadExplosion();
        }
    }

    public void OnDead()
    {
        //transform.gameObject.SetActive(false);
        // Destroy(gameObject);
        PlayerMovement.Instance.ready = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;

        Instantiate(_deadMark, transform.position, Quaternion.identity);
        _deadMark.SetActive(true);

        // _healthUI.SetActive(false);
        _healthUI.transform.GetChild(0).GetComponent<Image>().enabled = false;
        _healthUI.transform.GetChild(1).GetComponent<Image>().enabled = false;
        _healthUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
        _healthUI.transform.GetChild(2).GetChild(1).GetComponent<Image>().enabled = false;
        // _timerUI.SetActive(false);
        timerUI.transform.GetChild(0).GetComponent<Image>().enabled = false;
        timerUI.transform.GetChild(1).GetComponent<Image>().enabled = false;
        timerUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void Restart()
    {
        hp = 100;
        transform.position = _startPlace.transform.position;
        transform.rotation = _startPlace.transform.rotation;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;

        // _healthUI.SetActive(true);
        _healthUI.transform.GetChild(0).GetComponent<Image>().enabled = true;
        _healthUI.transform.GetChild(1).GetComponent<Image>().enabled = true;
        _healthUI.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = true;
        _healthUI.transform.GetChild(2).GetChild(1).GetComponent<Image>().enabled = true;
        _health.SetMaxHealth();

        // _timerUI.SetActive(true);
        timerUI.transform.GetChild(0).GetComponent<Image>().enabled = true;
        timerUI.transform.GetChild(1).GetComponent<Image>().enabled = true;
        timerUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().enabled = true;
        _timer.RestartTimer();
        _timer2.RestartTimer();
    }
}
