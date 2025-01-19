using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StartGameScreen _startGameScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private Canvas _inGameCanvas;
    [SerializeField] private Ground _ground;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyBulletSpawner _enemyBulletSpawner;

    private void OnEnable()
    {
        _startGameScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOvered += OnGameOver;
    }

    private void OnDisable()
    {
        _startGameScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _player.GameOvered -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startGameScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Restart();
        _ground.Restart();
        _inGameCanvas.gameObject.SetActive(true);
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _inGameCanvas.gameObject.SetActive(false);
        _endGameScreen.Open();
    }
}
