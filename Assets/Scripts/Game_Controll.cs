using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controll : MonoBehaviour
{

    [SerializeField] private Spawner_Cards _spawnerCards;
    [SerializeField] private Spawner_DAD _spawner_DAD;
    [SerializeField] private UI_Controll _uicontroll;
    [SerializeField] private InputOutputConroll _inputoutputControll;

    private void Start()
    {
        StartGame();
    }

    public void StartGame() {
        _spawner_DAD.ClearListDraggableObject();
        _spawnerCards.ClearListCards();
        _uicontroll.InitTableCard();
        _inputoutputControll.InitUIText();
    }

    private void OnEnable()
    {
        _inputoutputControll.startGame += StartInitCard;
        _inputoutputControll.endGame += EndGameOpenStatic;
    }

    private void OnDisable()
    {
        _inputoutputControll.startGame -= StartInitCard;
        _inputoutputControll.endGame -= EndGameOpenStatic;
    }

    private void StartInitCard(int line, int call, int speedGame) {
        _spawnerCards.InitCardsNumber(line, call);
        Invoke("CloseCardNumber", speedGame);
    }

    private void CloseCardNumber() {
        _spawnerCards.CloseCardWindow();
        Invoke("StartInitDraggableObj", 0.25f);
    }

    private void StartInitDraggableObj() {
        List<Card> sorringList = _spawnerCards.GetCards();
        SortList(sorringList);
        _spawner_DAD.InitDADElements(sorringList);
    }

    private void EndGameOpenStatic() {
        _uicontroll.WindowEndGame(true);
        CheckCards();
    }
    
    private void CheckCards() {
        for (int i = 0; i < _spawnerCards.GetCards().Count; i++) {
            if (ChekersNumber(i))
            {
                _inputoutputControll.AddWin();
            }
            else {
                _inputoutputControll.AddLose();
            }        
        }
        _spawnerCards.OpenWindowCards();
    }

    private bool ChekersNumber(int i) {
        return _spawnerCards.GetCard(i).GetNumberDraggble() == _spawnerCards.GetCard(i).number;
    }

    private void SortList(List<Card> list) {
        Card temp;
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i].number > list[j].number)
                {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }
}
