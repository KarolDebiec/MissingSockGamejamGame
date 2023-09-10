using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private CardSlot originalSlot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
        originalSlot = GetComponentInParent<CardSlot>();
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = originalPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        CardSlot newSlot = eventData.pointerCurrentRaycast.gameObject?.GetComponentInParent<CardSlot>();
        if (newSlot != null && newSlot != originalSlot)
        {
            Card tempCard = newSlot.GetCard();
            if (newSlot.SetCard(originalSlot.GetCard())) // This will check if the card types match
            {
                originalSlot.SetCard(tempCard);
            }
        }
    }
}
