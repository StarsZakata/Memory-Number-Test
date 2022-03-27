using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Cards : MonoBehaviour
{
    [SerializeField] private Card originalCard;
    [SerializeField] private float offsetX = 2.5f;
    [SerializeField] private float offsetY = 2.5f;

    private List<Card> _cards = new List<Card>();
    public List<Card> GetCards() {
        return _cards;
    }
    public Card GetCard(int i) {
        return _cards[i];
    }


    public void InitCardsNumber(int line, int call) {
        Vector3 startPoint = transform.position;
        for (int i = 0; i < line; i++) {
            for (int j = 0; j < call; j++) {
                Card _tmpCard;
                _tmpCard = Instantiate(originalCard, transform);
                _tmpCard.InitCard();
                _cards.Add(_tmpCard);

                float posX = (offsetX * i) + startPoint.x;
                float posY = (offsetY * j) + startPoint.y;
                _tmpCard.transform.position = new Vector3(posX, posY, startPoint.z);
            }
        }
    }

    public void CloseCardWindow() {
        foreach (Card element in _cards) {
            element.WindowCardNumber(false);
        }
    }

    public void OpenWindowCards()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].WindowCardNumber(true);
        }
    }

    public void ClearListCards() {
        foreach (Card cardi in _cards)
        {
            Destroy(cardi.gameObject);
        }
        _cards.Clear();
    }
}
