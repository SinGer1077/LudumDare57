using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnDragEvent : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private UnityEvent _onDrag;

    [SerializeField]
    private RectTransform _rectTransform;

    [SerializeField]
    private Canvas _canvas;

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        _onDrag.Invoke();
    }
}
