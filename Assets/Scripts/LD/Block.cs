using UnityEngine;

public class Block : MonoBehaviour
{
    public float Durability;

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

        }
    }

    public void DestroyBlock()
    {
        Destroyed = true;
    }
}
