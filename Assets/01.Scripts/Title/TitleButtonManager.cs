using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{

    [Header("[ ���� UI ]")]
    [SerializeField] Transform _mainTitleText;
    [SerializeField] Transform _startButton;
    [SerializeField] Transform _settingButton;
    [SerializeField] Transform _quitButton;

    [Header("[ ���� UI ]")]
    [SerializeField] Transform _settingTitleText;
    [SerializeField] Transform _soundSettingButton;
    [SerializeField] Transform _graphicSettingButton;
    [SerializeField] Transform _backButton;

    [Header("[ �Ҹ� UI ]")]
    [SerializeField] Transform _soundTitleText;
    [SerializeField] Transform _bgmSettingText;
    [SerializeField] Transform _bgmSlider;
    [SerializeField] Transform _sfxSettingText;
    [SerializeField] Transform _sfxSlider;
    [SerializeField] Transform _soundBackButton;

    [Header("[ ���� UI Ÿ�� ]")]
    [SerializeField] Transform _mainTitleTarget;
    [SerializeField] Transform _startTarget;
    [SerializeField] Transform _settingTarget;
    [SerializeField] Transform _quitTarget;

    [Header("[ ���� UI Ÿ�� ]")]
    [SerializeField] Transform _settingTitleTarget;
    [SerializeField] Transform _soundSettingTarget;
    [SerializeField] Transform _graphicSettingTarget;
    [SerializeField] Transform _backTarget;

    [Header("[ �Ҹ� UI Ÿ�� ]")]
    [SerializeField] Transform _soundTitleTarget;
    [SerializeField] Transform _bgmSettingTarget;
    [SerializeField] Transform _bgmSliderTarget;
    [SerializeField] Transform _sfxSettingTarget;
    [SerializeField] Transform _sfxSliderTarget;
    [SerializeField] Transform _soundBackTarget;

    private bool _clickSetting = false;
    private bool _clickSoundSetting = false;

    private void FixedUpdate()
    {
        if (_clickSetting && !_clickSoundSetting)
        {
            // ���� ��ư�� ������ �� ���� Ÿ��Ʋ UI���� ȭ�� ������ �̵���
            _mainTitleTarget.transform.position = new Vector3(-15, 15, 10);
            _startTarget.transform.position = new Vector3(6, -8.5f, 10);
            _settingTarget.transform.position = new Vector3(9, -10.5f, 10);
            _quitTarget.transform.position = new Vector3(12, -12.5f, 10);

            _mainTitleText.transform.position = Vector3.Slerp(_mainTitleText.transform.position, _mainTitleTarget.transform.position, 0.05f);
            _startButton.transform.position = Vector3.Slerp(_startButton.transform.position, _startTarget.transform.position, 0.05f);
            _settingButton.transform.position = Vector3.Slerp(_settingButton.transform.position, _settingTarget.transform.position, 0.05f);
            _quitButton.transform.position = Vector3.Slerp(_quitButton.transform.position, _quitTarget.transform.position, 0.05f);

            // ���� ��ư�� ������ �� ���� UI���� ȭ������ �̵���
            _settingTitleTarget.transform.position = new Vector3(-3, 2.5f, 10);
            _soundSettingTarget.transform.position = new Vector3(-1, 0, 10);
            _graphicSettingTarget.transform.position = new Vector3(2, -2, 10);
            _backTarget.transform.position = new Vector3(5, -4, 10);

            _settingTitleText.transform.position = Vector3.Slerp(_settingTitleText.transform.position, _settingTitleTarget.transform.position, 0.05f);
            _soundSettingButton.transform.position = Vector3.Slerp(_soundSettingButton.transform.position, _soundSettingTarget.transform.position, 0.05f);
            _graphicSettingButton.transform.position = Vector3.Slerp(_graphicSettingButton.transform.position, _graphicSettingTarget.transform.position, 0.05f);
            _backButton.transform.position = Vector3.Slerp(_backButton.transform.position, _backTarget.transform.position, 0.05f);
        }

        if (!_clickSetting && !_clickSoundSetting)
        {
            // �ڷΰ��� ��ư�� ������ �� ���� UI���� ȭ�� ������ �̵���
            _settingTitleTarget.transform.position = new Vector3(-15, 15, 10);
            _soundSettingTarget.transform.position = new Vector3(6, -8.5f, 10);
            _graphicSettingTarget.transform.position = new Vector3(9, -10.5f, 10);
            _backTarget.transform.position = new Vector3(12, -12.5f, 10);

            _settingTitleText.transform.position = Vector3.Slerp(_settingTitleText.transform.position, _settingTitleTarget.transform.position, 0.05f);
            _soundSettingButton.transform.position = Vector3.Slerp(_soundSettingButton.transform.position, _soundSettingTarget.transform.position, 0.05f);
            _graphicSettingButton.transform.position = Vector3.Slerp(_graphicSettingButton.transform.position, _graphicSettingTarget.transform.position, 0.05f);
            _backButton.transform.position = Vector3.Slerp(_backButton.transform.position, _backTarget.transform.position, 0.05f);

            // �ڷΰ��� ��ư�� ������ �� ���� Ÿ��Ʋ UI���� ȭ������ �̵���
            _mainTitleTarget.transform.position = new Vector3(-2, 2.5f, 10);
            _startTarget.transform.position = new Vector3(-1, 0, 10);
            _settingTarget.transform.position = new Vector3(2, -2, 10);
            _quitTarget.transform.position = new Vector3(5, -4, 10);

            _mainTitleText.transform.position = Vector3.Slerp(_mainTitleText.transform.position, _mainTitleTarget.transform.position, 0.05f);
            _startButton.transform.position = Vector3.Slerp(_startButton.transform.position, _startTarget.transform.position, 0.05f);
            _settingButton.transform.position = Vector3.Slerp(_settingButton.transform.position, _settingTarget.transform.position, 0.05f);
            _quitButton.transform.position = Vector3.Slerp(_quitButton.transform.position, _quitTarget.transform.position, 0.05f);
        }

        if (_clickSoundSetting && !_clickSetting)
        {
            // �Ҹ� ��ư�� ������ �� ���� UI���� ȭ�� ������ �̵���
            _settingTitleTarget.transform.position = new Vector3(-15, 15, 10);
            _soundSettingTarget.transform.position = new Vector3(6, -8.5f, 10);
            _graphicSettingTarget.transform.position = new Vector3(9, -10.5f, 10);
            _backTarget.transform.position = new Vector3(12, -12.5f, 10);

            _settingTitleText.transform.position = Vector3.Slerp(_settingTitleText.transform.position, _settingTitleTarget.transform.position, 0.05f);
            _soundSettingButton.transform.position = Vector3.Slerp(_soundSettingButton.transform.position, _soundSettingTarget.transform.position, 0.05f);
            _graphicSettingButton.transform.position = Vector3.Slerp(_graphicSettingButton.transform.position, _graphicSettingTarget.transform.position, 0.05f);
            _backButton.transform.position = Vector3.Slerp(_backButton.transform.position, _backTarget.transform.position, 0.05f);

            // �Ҹ� ��ư�� ������ �� �Ҹ� UI���� ȭ������ �̵���
            _soundTitleTarget.transform.position = new Vector3(-3, 2.5f, 10);
            _bgmSettingTarget.transform.position = new Vector3(-1, 0, 10);
            _bgmSliderTarget.transform.position = new Vector3(-1, -1, 10);
            _sfxSettingTarget.transform.position = new Vector3(2, -2, 10);
            _sfxSliderTarget.transform.position = new Vector3(2, -3, 10);
            _soundBackTarget.transform.position = new Vector3(5, -4, 10);

            _soundTitleText.transform.position = Vector3.Slerp(_soundTitleText.transform.position, _soundTitleTarget.transform.position, 0.05f);
            _bgmSettingText.transform.position = Vector3.Slerp(_bgmSettingText.transform.position, _bgmSettingTarget.transform.position, 0.05f);
            _bgmSlider.transform.position = Vector3.Slerp(_bgmSlider.transform.position, _bgmSliderTarget.transform.position, 0.05f);
            _sfxSettingText.transform.position = Vector3.Slerp(_sfxSettingText.transform.position, _sfxSettingTarget.transform.position, 0.05f);
            _sfxSlider.transform.position = Vector3.Slerp(_sfxSlider.transform.position, _sfxSliderTarget.transform.position, 0.05f);
            _soundBackButton.transform.position = Vector3.Slerp(_soundBackButton.transform.position, _soundBackTarget.transform.position, 0.05f);
        }

        if (!_clickSoundSetting)
        {
            // �Ҹ� �ڷΰ��� ��ư�� ������ �� �Ҹ� UI���� ȭ�� ������ �̵���
            _soundTitleTarget.transform.position = new Vector3(-15, 15, 10);
            _bgmSettingTarget.transform.position = new Vector3(6, -8.5f, 10);
            _bgmSliderTarget.transform.position = new Vector3(6, -8.5f, 10);
            _sfxSettingTarget.transform.position = new Vector3(9, -10.5f, 10);
            _sfxSliderTarget.transform.position = new Vector3(9, -10.5f, 10);
            _soundBackTarget.transform.position = new Vector3(12, -12.5f, 10);

            _soundTitleText.transform.position = Vector3.Slerp(_soundTitleText.transform.position, _soundTitleTarget.transform.position, 0.05f);
            _bgmSettingText.transform.position = Vector3.Slerp(_bgmSettingText.transform.position, _bgmSettingTarget.transform.position, 0.05f);
            _bgmSlider.transform.position = Vector3.Slerp(_bgmSlider.transform.position, _bgmSliderTarget.transform.position, 0.05f);
            _sfxSettingText.transform.position = Vector3.Slerp(_sfxSettingText.transform.position, _sfxSettingTarget.transform.position, 0.05f);
            _sfxSlider.transform.position = Vector3.Slerp(_sfxSlider.transform.position, _sfxSliderTarget.transform.position, 0.05f);
            _soundBackButton.transform.position = Vector3.Slerp(_soundBackButton.transform.position, _soundBackTarget.transform.position, 0.05f);
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
