using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OnDragBegin : MonoBehaviour, IBeginDragHandler
{
    [SerializeField]
    private UnityEvent _onDragBegin;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _onDragBegin.Invoke();
    }
}
