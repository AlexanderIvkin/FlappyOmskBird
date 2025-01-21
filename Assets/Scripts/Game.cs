using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private Canvas _inGameCanvas;

    private void OnEnable()
    {
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOvered += OnGameOver;
    }

    private void OnDisable()
    {
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _player.GameOvered -= OnGameOver;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _inGameCanvas.gameObject.SetActive(false);
        _endGameScreen.Open();
    }
}
