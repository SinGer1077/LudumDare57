using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public float Durability;

    [SerializeField]
    private Image image;

    [HideInInspector]
    public float DefaultDurability;

    [HideInInspector]
    public bool Destroyed;

    private void Start()
    {
        DefaultDurability = Durability;
        Destroyed = false;
    }

    public void ChangeDurability(float value)
    {
        Durability = Mathf.Clamp(Durability - value, 0.0f, DefaultDurability);        
        if (Durability <= 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
            DestroyBlock();
        }
    }

    public void DestroyBlock()
    {
        Destroyed = true;
    }
}
