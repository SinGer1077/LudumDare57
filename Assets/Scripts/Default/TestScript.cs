using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using DG.Tweening;

public class TestScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private int counter = 1;

    private Vector3 _defaultPosition;

    private void Start()
    {
        _defaultPosition = _text.transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        _text.text = counter.ToString();

        _text.transform.DOJump(_defaultPosition, 5.0f, 2, 1.0f);
    }

    public void ScaleText()
    {
        _text.transform.DOScale(2.0f, 1.0f);
    }

    public void UnscaleText()
    {
        _text.transform.DOScale(1.0f, 1.0f);
    }
}
