using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputOutputConroll : MonoBehaviour
{
    [SerializeField] private Text numberLine;
    [SerializeField] private Text numberCall;
    [SerializeField] private Text numberSpeed;

    [SerializeField] private Slider _sliderSpeed;

    public event UnityAction<int,int,int> startGame;
    public event UnityAction endGame;

    [SerializeField] private Text numberWin;
    [SerializeField] private Text numberLose;


    private int line;
    private int call;
    private int speedGame;

    public void InitUIText()
    {
        line = 1;
        call = 1;
        speedGame = 1;
        numberWin.text = "0";
        numberLose.text = "0";
        numberLine.text = line.ToString();
        numberCall.text = call.ToString();
    }

    public void SliderChangesSpeedGame()
    {
        speedGame = Convert.ToInt32(_sliderSpeed.value);
        numberSpeed.text = speedGame.ToString();
    }

    public void ButtonAddLine() {
        if (line >= 5) {
            return;
        }
        line++;
        numberLine.text = line.ToString();
    }
    public void ButtonReduceLine()
    {
        if (line == 1) {
            return;
        }
        line--;
        numberLine.text = line.ToString();
    }

    public void ButtonAddCall() {
        if (call >= 3)
        {
            return;
        }
        call++;
        numberCall.text = call.ToString();
    }
    public void ButtonReduceCall() {
        if (call == 1)
        {
            return;
        }
        call--;
        numberCall.text = call.ToString();
    }

    public void ButtonStartGame() {
        Debug.Log(line + " " + call + " " + speedGame);
        startGame?.Invoke(line,call,speedGame);
        gameObject.GetComponentInParent<UI_Controll>().WindowStartGame(false);
    }


    public void AddWin() {
        int number  = Convert.ToInt32(numberWin.text);
        number++;
        numberWin.text = number.ToString();
    }
    public void AddLose()
    {
        int number = Convert.ToInt32(numberLose.text);
        number++;
        numberLose.text = number.ToString();
    }

    public void ButtonCheckGameCards() {
        endGame?.Invoke();
    }
}
