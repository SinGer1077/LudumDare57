using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ant : MonoBehaviour, IPointerClickHandler
{
    public float Energy;

    private float DefaultEnergy;

    public Image energySlider;

    public virtual void Start()
    {
        DefaultEnergy = Energy;
    }

    public virtual void SpendEnergy(float value)
    {
        Energy = Mathf.Clamp(Energy - value, 0.0f, DefaultEnergy);
        energySlider.fillAmount = Energy / DefaultEnergy;
        if (Energy <= 0.0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {

    }
}
