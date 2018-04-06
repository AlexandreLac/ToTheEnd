using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : GameStateObserver<HudManager> {

    [SerializeField]
    private Text m_StatutEndGame;
    [SerializeField]
    private Canvas m_CanvasObject;

    protected override void EndGameChangedText(string message)
    {
        m_CanvasObject.gameObject.SetActive(true);

        m_StatutEndGame.text = message;
    }
}
