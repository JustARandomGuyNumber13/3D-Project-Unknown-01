using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Drag_Handler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public UnityEvent OnBeginDragEvent;
    public UnityEvent<PointerEventData> OnDragEvent;
    public UnityEvent OnEndDragEvent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragEvent?.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(eventData);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragEvent?.Invoke();
    }
}