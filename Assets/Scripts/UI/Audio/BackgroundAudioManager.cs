using UnityEngine;

public class BackgroundAudioManager : AudioManager
{
    [SerializeField] private AudioClip _defaultClip;

    private float _saveTime;
    private void Start()
    {
        PlayAudio(_defaultClip);
    }

    public override void PlayAudio(AudioClip clip)
    {
        if (clip == null)
            _audioSource.Pause();

        _audioSource.clip = clip;

        if (_audioSource.clip == _defaultClip)
            _audioSource.time = _saveTime;

        _audioSource.Play();
    }

    private void Update()
    {
        if (_audioSource != _defaultClip)
            return;

        _saveTime = _audioSource.time;
    }

    public override void StopAudio()
    {
        _audioSource.Stop();
        PlayAudio(_defaultClip);
    }
}
