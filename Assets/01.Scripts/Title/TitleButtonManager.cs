using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{

    [Header("[ 메인 UI ]")]
    [SerializeField] Transform _mainTitleText;
    [SerializeField] Transform _startButton;
    [SerializeField] Transform _settingButton;
    [SerializeField] Transform _quitButton;

    [Header("[ 설정 UI ]")]
    [SerializeField] Transform _settingTitleText;
    [SerializeField] Transform _soundSettingButton;
    [SerializeField] Transform _graphicSettingButton;
    [SerializeField] Transform _backButton;

    [Header("[ 소리 UI ]")]
    [SerializeField] Transform _soundTitleText;
    [SerializeField] Transform _bgmSettingText;
    [SerializeField] Transform _bgmSlider;
    [SerializeField] Transform _sfxSettingText;
    [SerializeField] Transform _sfxSlider;
    [SerializeField] Transform _soundBackButton;

    private bool _clickSetting = false;
    private bool _clickSoundSetting = false;

    private void FixedUpdate()
    {
        if (_clickSetting && !_clickSoundSetting) // 설정 버튼 눌렀을 때
        {
            // 메인 타이틀 UI 퇴장
            _mainTitleText.transform.position = Vector3.Slerp(_mainTitleText.transform.position, new Vector3(-15, 15, 10), 0.05f);
            _startButton.transform.position = Vector3.Slerp(_startButton.transform.position, new Vector3(6, -8.5f, 10), 0.05f);
            _settingButton.transform.position = Vector3.Slerp(_settingButton.transform.position, new Vector3(9, -10.5f, 10), 0.05f);
            _quitButton.transform.position = Vector3.Slerp(_quitButton.transform.position, new Vector3(12, -12.5f, 10), 0.05f);

            // 설정 UI 입장
            _settingTitleText.transform.position = Vector3.Slerp(_settingTitleText.transform.position, new Vector3(-3, 2.5f, 10), 0.05f);
            _soundSettingButton.transform.position = Vector3.Slerp(_soundSettingButton.transform.position, new Vector3(-1, 0, 10), 0.05f);
            _graphicSettingButton.transform.position = Vector3.Slerp(_graphicSettingButton.transform.position, new Vector3(2, -2, 10), 0.05f);
            _backButton.transform.position = Vector3.Slerp(_backButton.transform.position, new Vector3(5, -4, 10), 0.05f);
        }

        if (!_clickSetting && !_clickSoundSetting) // 뒤로가기 버튼 눌렀을 때
        {
            // 설정 UI 퇴장
            _settingTitleText.transform.position = Vector3.Slerp(_settingTitleText.transform.position, new Vector3(-15, 15, 10), 0.05f);
            _soundSettingButton.transform.position = Vector3.Slerp(_soundSettingButton.transform.position, new Vector3(6, -8.5f, 10), 0.05f);
            _graphicSettingButton.transform.position = Vector3.Slerp(_graphicSettingButton.transform.position, new Vector3(9, -10.5f, 10), 0.05f);
            _backButton.transform.position = Vector3.Slerp(_backButton.transform.position, new Vector3(12, -12.5f, 10), 0.05f);

            // 메인 타이틀 UI 입장
            _mainTitleText.transform.position = Vector3.Slerp(_mainTitleText.transform.position, new Vector3(-2, 2.5f, 10), 0.05f);
            _startButton.transform.position = Vector3.Slerp(_startButton.transform.position, new Vector3(-1, 0, 10), 0.05f);
            _settingButton.transform.position = Vector3.Slerp(_settingButton.transform.position, new Vector3(2, -2, 10), 0.05f);
            _quitButton.transform.position = Vector3.Slerp(_quitButton.transform.position, new Vector3(5, -4, 10), 0.05f);
        }

        if (_clickSoundSetting && !_clickSetting) // 소리 버튼 눌렀을 때
        {
            // 설정 UI 퇴장
            _settingTitleText.transform.position = Vector3.Slerp(_settingTitleText.transform.position, new Vector3(-15, 15, 10), 0.05f);
            _soundSettingButton.transform.position = Vector3.Slerp(_soundSettingButton.transform.position, new Vector3(6, -8.5f, 10), 0.05f);
            _graphicSettingButton.transform.position = Vector3.Slerp(_graphicSettingButton.transform.position, new Vector3(9, -10.5f, 10), 0.05f);
            _backButton.transform.position = Vector3.Slerp(_backButton.transform.position, new Vector3(12, -12.5f, 10), 0.05f);

            // 소리 UI 입장
            _soundTitleText.transform.position = Vector3.Slerp(_soundTitleText.transform.position, new Vector3(-3, 2.5f, 10), 0.05f);
            _bgmSettingText.transform.position = Vector3.Slerp(_bgmSettingText.transform.position, new Vector3(-1, 0, 10), 0.05f);
            _bgmSlider.transform.position = Vector3.Slerp(_bgmSlider.transform.position, new Vector3(-1, -1, 10), 0.05f);
            _sfxSettingText.transform.position = Vector3.Slerp(_sfxSettingText.transform.position, new Vector3(2, -2, 10), 0.05f);
            _sfxSlider.transform.position = Vector3.Slerp(_sfxSlider.transform.position, new Vector3(2, -3, 10), 0.05f);
            _soundBackButton.transform.position = Vector3.Slerp(_soundBackButton.transform.position, new Vector3(5, -4, 10), 0.05f);
        }

        if (!_clickSoundSetting) // 소리 뒤로가기 버튼 눌렀을 때
        {
            // 소리 UI 퇴장
            _soundTitleText.transform.position = Vector3.Slerp(_soundTitleText.transform.position, new Vector3(-15, 15, 10), 0.05f);
            _bgmSettingText.transform.position = Vector3.Slerp(_bgmSettingText.transform.position, new Vector3(6, -8.5f, 10), 0.05f);
            _bgmSlider.transform.position = Vector3.Slerp(_bgmSlider.transform.position, new Vector3(6, -8.5f, 10), 0.05f);
            _sfxSettingText.transform.position = Vector3.Slerp(_sfxSettingText.transform.position, new Vector3(9, -10.5f, 10), 0.05f);
            _sfxSlider.transform.position = Vector3.Slerp(_sfxSlider.transform.position, new Vector3(9, -10.5f, 10), 0.05f);
            _soundBackButton.transform.position = Vector3.Slerp(_soundBackButton.transform.position, new Vector3(12, -12.5f, 10), 0.05f);
        }
    }

    public void GameStart()
    {
        // AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        // AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        _clickSetting = true;
        _clickSoundSetting = false;
    }

    public void Quit()
    {
        // DataManager.Instance.SaveGameData();
        // AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        Application.Quit();
    }

    public void Back()
    {
        // AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        _clickSetting = false;
        _clickSoundSetting = false;
    }

    public void SoundBack()
    {
        // AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        _clickSoundSetting = false;
        _clickSetting = true;
    }

    public void Sound()
    {
        // AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        _clickSoundSetting = true;
        _clickSetting = false;
    }

    public void Graphic()
    {
        // AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
    }
}
