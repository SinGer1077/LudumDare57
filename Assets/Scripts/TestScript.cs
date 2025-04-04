using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private int counter = 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        _text.text = counter.ToString();
    }
}
