using UnityEngine;

public class Ant : MonoBehaviour
{
    public float Energy;

    private float DefaultEnergy;

    private void Start()
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
    }
}
