using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { menu, play, victory, gameOver }

public class GameManager : GameStateObserver<GameManager>
{

    public event Action OnGamePlay;
    public event Action OnGameMenu;
    public event Action OnGameVictory;
    public event Action OnGameOnGameOver;
    public event Action<string> OnEndGameChangedText;
    private GameState m_GameState;

    public void StartGame()
    {
        if (m_GameState == GameState.gameOver ||
            m_GameState == GameState.victory)
        {
            SceneManager.LoadScene(0);
            return;
        }
        m_GameState = GameState.play;

        if (OnGamePlay != null) OnGamePlay();
    }

    protected override void Start()
    {
        m_GameState = GameState.menu;
    }

    public void WinGame()
    {
        Debug.Log("I Win");
        m_GameState = GameState.victory;
        if (OnGameVictory != null) OnGameVictory();
        if (OnEndGameChangedText != null) OnEndGameChangedText("You Win");
    }

    public void LooseGame()
    {
        m_GameState = GameState.gameOver;
        if (OnGameOnGameOver != null) OnGameOnGameOver();
        if (OnEndGameChangedText != null) OnEndGameChangedText("You Loose");
    }
}
