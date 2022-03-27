
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberForDraggable;

    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    public int numberForDraggable;

    public event UnityAction<Draggable> endDrag;

    public void InitDraggableObject(int number) {
        numberForDraggable = number;
        _numberForDraggable.text = numberForDraggable.ToString();
    }

    private void OnMouseDown()
    {
        transform.parent = null;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }
    private void OnMouseDrag()
    {
        if (isDragged)
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
    }
    private void OnMouseUp()
    {
        isDragged = true;
        endDrag?.Invoke(this);
    }
}
