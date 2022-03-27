using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberCard;
    [SerializeField] private Image _colorImage;

    [SerializeField] private Transform _pointSetEnemy;

    public GameObject _pointsSet;
    public int number;

    public void InitCard() {
        SetNewNumber();
        SetColorCard();
    }

    private void SetNewNumber() {
        number = Random.RandomRange(1, 99);
        _numberCard.text = number.ToString();
    }
    private void SetColorCard() { 
        var r = 1f / Random.Range(0, 255) * 100f;
        var g = 1f / Random.Range(0, 255) * 100f;
        var b = 1f / Random.Range(0, 255) * 100f;
        _colorImage.color = new Color(r, g, b, 1);
    }
    public void WindowCardNumber(bool value) {
        _numberCard.enabled = value;
    }
    public int GetNumberDraggble() {
        if (_pointsSet.GetComponentInChildren<Draggable>() == null) {
            return 0;
        }
        return _pointsSet.GetComponentInChildren<Draggable>().numberForDraggable;
    }
}
