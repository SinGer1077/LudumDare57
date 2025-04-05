using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Block : MonoBehaviour, IPointerClickHandler
{
    public float Durability;

    [SerializeField]
    private Image image;

    [HideInInspector]
    public float DefaultDurability;

    [HideInInspector]
    public bool Destroyed;

    [HideInInspector]
    public int clickCount;

    [HideInInspector]
    public InputManager InputManager;

    [HideInInspector]
    public int x, y;

    private void Start()
    {
        DefaultDurability = Durability;
        Destroyed = false;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (InputManager.CurrentBlock != this)
            {
                if (InputManager.CurrentBlock != null)
                    InputManager.CurrentBlock.clickCount = 0;
                InputManager.CurrentBlock = this;
            }
            else
            {

            }

            clickCount++;
            if (clickCount == 2)
            {
                InputManager.CurrentBlock.clickCount = 0;
                if (InputManager.CurrentChosenAnt != null)
                {
                    InputManager.CurrentChosenAnt.SetPath(y ,x, false);
                }
            }
        }
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
