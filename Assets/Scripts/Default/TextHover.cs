using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI Text;

    [SerializeField]
    private AntType ToSummon;

    [SerializeField]
    private AntQueen Queen;

    private float fontSize;

    private void Start()
    {
        fontSize = Text.fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Text.rectTransform.DOScale(1.3f, 0.5f);
            
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Text.rectTransform.DOScale(1.0f, 0.5f);
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        Queen.SummonAnt(ToSummon);
    }
}
