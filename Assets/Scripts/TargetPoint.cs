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
        StartCoroutine(DelayNextScene());
    }

    IEnumerator DelayNextScene()
    {
        yield return new WaitForSeconds(.4f);

        NextScene?.Invoke();
    }
}
