using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
    [SerializeField] protected AudioSource _audioSource;

    public abstract void PlayAudio(AudioClip clip);

    public abstract void StopAudio();

}
