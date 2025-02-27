using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveBag : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    RectTransform currentRect;
    public float dragSensitivity = 1.0f;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragDelta = eventData.delta / dragSensitivity;

        Vector2 worldDragDelta = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane)) -
                                 Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x - dragDelta.x, eventData.position.y - dragDelta.y, Camera.main.nearClipPlane));
        
        currentRect.anchoredPosition += worldDragDelta;
    }

    void Awake()
    {
        currentRect = GetComponent<RectTransform>();
    }
}
