using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private LoadingScreen _loadingScreen;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        Time.timeScale = 0;
        _loadingScreen.Load(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
