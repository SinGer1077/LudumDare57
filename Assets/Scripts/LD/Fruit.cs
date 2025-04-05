using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    public float EnergyRestore;

    [SerializeField]
    private Image image;

    public void Start()
    {
        var color = image.color;
        color.a = 0.0f;
        image.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        image.DOFade(1.0f, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        image.DOFade(0.0f, 0.5f);
    }
}
