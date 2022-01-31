using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private int _nextIndexScene;
    [SerializeField] private AudioSource _audio;

    public event UnityAction<int> NextScene;
    public event UnityAction WinGame;

    public void LoadScene()
    {

        if (_nextIndexScene >= SceneManager.sceneCountInBuildSettings)
        {
            WinGame?.Invoke();
            return;
        }

        _audio.Play();
        StartCoroutine(DelayNextScene());
    }

    IEnumerator DelayNextScene()
    {
        yield return new WaitForSeconds(.4f);

        NextScene?.Invoke(_nextIndexScene);
    }
}
