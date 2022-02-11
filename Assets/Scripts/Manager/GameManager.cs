using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rocket _rocketPrefab;
    [SerializeField] private Point _startPoint;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CongratulationScreen _winScreen;
    [SerializeField] private TargetPoint _targetPoint;
    [SerializeField] private LoadingScreen _loadingScreen;

    public Rocket Rocket { get; private set; }

    private void OnEnable()
    {
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _targetPoint.NextScene += OnNextScene;
    }

    private void OnDisable()
    {
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _targetPoint.NextScene -= OnNextScene;
        Rocket.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Rocket = Instantiate(_rocketPrefab, _startPoint.transform.position, Quaternion.Euler(0, 0, 45));
        Rocket.GameOver += OnGameOver;

        if (SceneManager.GetActiveScene().buildIndex == 1)
            Rocket.ResetStat();

        Time.timeScale = 1;
    }

    private void OnRestartButtonClick()
    {
        _loadingScreen.Load(1);
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
    }

    private void OnNextScene()
    {
        int nextIndexScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndexScene >= SceneManager.sceneCountInBuildSettings)
        {
            WinGame();
            return;
        }

        Rocket.SaveStat();
        _loadingScreen.Load(nextIndexScene);
    }

    private void WinGame()
    {
        _winScreen.Open();
    }
}
