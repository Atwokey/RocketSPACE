using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void Load(int index = 0)
    {
        _animator.SetBool("Faded", true);
        StartCoroutine(AsyncLoad(index));
    }

    IEnumerator  AsyncLoad(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
