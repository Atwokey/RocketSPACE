using UnityEngine;

public class RocketAudioManager : AudioManager
{
    public override void PlayAudio(AudioClip clip)
    {
        if (_audioSource.clip != clip)
            _audioSource.clip = clip;

        if (!_audioSource.isPlaying)
            _audioSource.Play();
    }

    public override void StopAudio()
    {
        if(_audioSource.isPlaying)
            _audioSource.Stop();
    }
}
