using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateObserver<T> : MonoBehaviour where T : Component
{
    private static T m_Instance;
    public static T Instance
    {
        get
        {
            return m_Instance;
        }
    }

    protected bool m_CanPlay = false;
    protected virtual void Awake()
    {
        if (m_Instance == null) m_Instance = this as T;
        else Destroy(gameObject);
    }

    // Use this for initialization
    protected virtual void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameMenu += GameMenu;
            GameManager.Instance.OnGamePlay += GamePlay;
            GameManager.Instance.OnGameVictory += GameVictory;
            GameManager.Instance.OnGameOnGameOver += GameOnGameOver;
            GameManager.Instance.OnEndGameChangedText += EndGameChangedText;
        }
    }

    protected virtual void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameMenu -= GameMenu;
            GameManager.Instance.OnGamePlay -= GamePlay;
            GameManager.Instance.OnGameVictory -= GameVictory;
            GameManager.Instance.OnGameOnGameOver -= GameOnGameOver;
            GameManager.Instance.OnEndGameChangedText -= EndGameChangedText;
        }
    }

    protected virtual void GameMenu()
    {

    }
    protected virtual void GamePlay()
    {

    }
    protected virtual void GameVictory()
    {
        m_CanPlay = false;
    }
    protected virtual void GameOnGameOver()
    {
        m_CanPlay = false;
    }
    protected virtual void ScoreChanged(float newScore)
    {

    }

    protected virtual void EndGameChangedText(string message)
    {

    }

}
