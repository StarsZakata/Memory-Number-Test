using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_DAD : MonoBehaviour
{
    [SerializeField] private Draggable originalPrefab;
    [SerializeField] private Spawner_Cards _spawner_Cards;

    private List<Draggable> _draggbleObjects = new List<Draggable>();

    private float offsetX = 1.15f;
    private float rangeDistance = 0.5f;

    public void InitDADElements(List<Card> _sortLis) {
            Vector3 startPoint = transform.position;
            for (int i = 0; i < _sortLis.Count; i++)
            {
                Draggable _tmpDraggableObhect;
                _tmpDraggableObhect = Instantiate(originalPrefab, transform);
                _tmpDraggableObhect.InitDraggableObject(_sortLis[i].number);
                _tmpDraggableObhect.endDrag += CheckPoint;
                _draggbleObjects.Add(_tmpDraggableObhect);
                float posX = (offsetX * i) + startPoint.x;
                _tmpDraggableObhect.transform.position = new Vector3(posX, startPoint.y, startPoint.z);
        }
    }

    private void OnDisable()
    {
        originalPrefab.endDrag -= CheckPoint;
    }

    private void CheckPoint(Draggable enemy) {
        List<Card> _listObjects = _spawner_Cards.GetCards();
        for (int i = 0; i < _listObjects.Count; i++) {
            float currentDictance = Vector2.Distance(enemy.transform.position, _listObjects[i].transform.position);
            if (currentDictance < rangeDistance)
            {
                enemy.transform.parent = _listObjects[i]._pointsSet.transform;
                enemy.transform.position = new Vector3(_listObjects[i]._pointsSet.transform.position.x, _listObjects[i]._pointsSet.transform.position.y, -1);
            }
        }
        /*
        for (int i = 0; i < _draggbleObjects.Count; i++)
        {
            for (int j = 0; j < _listObjects.Count; j++)
            {
                float currentDictance = Vector2.Distance(_draggbleObjects[i].transform.position, _listObjects[j].transform.position);
                /*
                Debug.Log("Точка Объекта = " + _draggbleObjects[i].transform.position +
                          " Точка Карты = " + _listObjects[i].transform.position +
                          " Расстояние " + currentDictance +
                          " Значение Объекта = " + _draggbleObjects[i].numberForDraggable +
                          " Значение Карты =  " + _listObjects[i].number);
               
                if (currentDictance < rangeDistance)
                {

                    _draggbleObjects[i].transform.parent = _listObjects[i]._pointsSet.transform;
                    _draggbleObjects[i].transform.position = new Vector3(_listObjects[i]._pointsSet.transform.position.x, _listObjects[i]._pointsSet.transform.position.y, -1);
                }
            }     
        }
        */
    }

    public void ClearListDraggableObject() {
        foreach (Draggable dragobj in _draggbleObjects)
        {
            dragobj.transform.parent = null;
            Destroy(dragobj.gameObject);
        }
        _draggbleObjects.Clear();
    }
}
