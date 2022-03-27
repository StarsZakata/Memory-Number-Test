using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Controll : MonoBehaviour
{
    [SerializeField] private GameObject PanelStartGame;
    [SerializeField] private GameObject PanelEndGame;
    [SerializeField] private GameObject ButtonCheckCards;

    public void InitTableCard() {
        PanelStartGame.SetActive(true);
        PanelEndGame.SetActive(false);
        ButtonCheckCards.SetActive(false);
    }

    public void WindowStartGame(bool value) {
        ButtonCheckCards.SetActive(true);
        PanelStartGame.SetActive(false);
    }

    public void WindowEndGame(bool value) {
        ButtonCheckCards.SetActive(false);
        PanelEndGame.SetActive(value);
    }

}
