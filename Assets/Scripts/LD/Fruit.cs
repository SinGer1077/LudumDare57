using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    public float EnergyRestore;

    [SerializeField]
    private Image image;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Collider2D collider;

    [HideInInspector]
    public bool Taken;

    public void Start()
    {
        var color = image.color;
        color.a = 0.0f;
        image.color = color;

        text.text = EnergyRestore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        image.DOFade(1.0f, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        image.DOFade(0.0f, 0.5f);
    }

    public void FruitTaken()
    {
        Taken = true;
        text.gameObject.SetActive(true);
        text.rectTransform.DOJump(text.rectTransform.position, 3.0f, 5, 2.0f);
        image.DOFade(0.0f, 0.0f);
        collider.enabled = false;
        DOVirtual.DelayedCall(2.0f, () =>
        {
            //text.gameObject.SetActive(false);
            Destroy(this.gameObject);
        });
    }
}
