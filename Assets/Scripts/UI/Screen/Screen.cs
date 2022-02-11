using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private Button _exitButton;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioClip _audio;
    [SerializeField] protected Button _button;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);

        if (_button != null)
            _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);

        if (_button != null)
            _button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    private void OnExitButtonClick()
    {
        _loadingScreen.Load();
        Close();
    }

    public virtual void Open()
    {
        _panel.SetActive(true);
        _audioManager.PlayAudio(_audio);
        Time.timeScale = 0;
    }

    public virtual void Close()
    {
        _panel.SetActive(false);
        _audioManager.StopAudio();
        Time.timeScale = 1;
    }
}
