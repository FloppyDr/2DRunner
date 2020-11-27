using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreLable;
    [SerializeField] private TMP_Text _coinsLable;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = !_gameOverGroup.interactable;
    }

    private void OnDied()
    {
        ShowFinalScore();
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = !_gameOverGroup.interactable;
        Time.timeScale = 0;
    }

    private void ShowFinalScore()
    {
        _scoreLable.text += _player.Distance;
        _coinsLable.text += _player.Coins;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
