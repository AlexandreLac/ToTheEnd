using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : GameStateObserver<MenuManager>
{

    [SerializeField]
    private Canvas m_MainMenuCanvas;

    protected override void Start()
    {
        base.Start();

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void GameMenu()
    {

    }
    protected override void GamePlay()
    {
        m_MainMenuCanvas.gameObject.SetActive(false);
    }
    protected override void GameVictory()
    {

    }
    protected override void GameOnGameOver()
    {

    }
    public void PlayButtonHasBeenClicked()
    {
        GameManager.Instance.StartGame();
    }
}
