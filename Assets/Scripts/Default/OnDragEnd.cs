using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnDragEnd : MonoBehaviour, IEndDragHandler
{
    [SerializeField]
    private UnityEvent _onDragEnd;

    public void OnEndDrag(PointerEventData eventData)
    {
        _onDragEnd.Invoke();
    }
}
