using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TargetPoint : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    public event UnityAction NextScene;

    public void LoadScene()
    {
        _audio.Play();
        NextScene?.Invoke();
    }
}
