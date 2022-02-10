using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Rocket")]
    [SerializeField] private Rocket _rocketPrefab;
    [SerializeField] private Point _startPoint;
    [Header("Screens")]
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CongratulationScreen _winScreen;
    [SerializeField] private TargetPoint _targetPoint;

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
        SceneManager.LoadScene(1);
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
    }

    private void OnNextScene()
    {
        int nextIndexScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndexScene >= SceneManager.sceneCountInBuildSettings)
            WinGame();

        SceneManager.LoadScene(nextIndexScene);
    }

    private void WinGame()
    {
        _winScreen.Open();
    }
}
