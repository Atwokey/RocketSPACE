using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CongratulationScreen _winScreen;
    [SerializeField] private FinishPoint _finish;

    private void OnEnable()
    {
        _pauseScreen.ResumeButtonClick += OnResumeButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _rocket.GameOver += OnGameOver;
        _finish.NextScene += OnLoadScene;
        _finish.WinGame += OnWinGame;
    }

    private void OnDisable()
    {
        _pauseScreen.ResumeButtonClick -= OnResumeButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _rocket.GameOver -= OnGameOver;
        _finish.NextScene -= OnLoadScene;
        _finish.WinGame -= OnWinGame;
    }

    private void Start()
    {
        Time.timeScale = 1;

        if(SceneManager.GetActiveScene().buildIndex == 1)
            _rocket.ResetStat();
        else
            _rocket.LoadStat();
    }

    private void OnResumeButtonClick()
    {
        _pauseScreen.Close();
    }

    private void OnRestartButtonClick()
    {
        Restart();
    }

    private void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
    }

    private void OnWinGame()
    {
        _winScreen.Open();
    }

    private void OnLoadScene(int value)
    {
        _rocket.SaveStat();
        SceneManager.LoadScene(value);
    }


}
