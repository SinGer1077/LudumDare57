using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ant : MonoBehaviour, IPointerClickHandler
{
    public float Energy;

    private float DefaultEnergy;

    public Image energySlider;

    public TextMeshProUGUI energyText;

    private float ReturnRound1(float value)
    {
        return (Mathf.Round(value * 10)) / 10.0f;
    }

    public virtual void Start()
    {
        DefaultEnergy = Energy;
        energyText.text = ReturnRound1(Energy) + "/" + ReturnRound1(DefaultEnergy);
    }

    public virtual void SpendEnergy(float value)
    {
        Energy = Mathf.Clamp(Energy - value, 0.0f, DefaultEnergy);
        energySlider.fillAmount = Energy / DefaultEnergy;
        energyText.text = ReturnRound1(Energy) + "/" + ReturnRound1(DefaultEnergy);
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
