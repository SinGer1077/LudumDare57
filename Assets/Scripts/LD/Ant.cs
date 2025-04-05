using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ant : MonoBehaviour, IPointerClickHandler
{
    public float Energy;

    private float DefaultEnergy;

    public virtual void Start()
    {
        DefaultEnergy = Energy;
    }

    public void SpendEnergy(float value)
    {
        Energy = Mathf.Clamp(Energy - value, 0.0f, DefaultEnergy);
        if (Energy <= 0.0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Ant is dead(");
        Destroy(gameObject);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {

    }
}
