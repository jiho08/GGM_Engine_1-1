using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private bool _isEsc = false;
    [SerializeField] private GameObject _escUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isEsc)
        {
            Time.timeScale = 0f;
            _escUI.SetActive(true);
            _isEsc = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isEsc)
        {
            Time.timeScale = 1f;
            _escUI.SetActive(false);
            _isEsc = false;
        }
        
    }

    public void EscTitleButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void EscQuitButton()
    {
        Application.Quit();
    }
}
