using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AntQueen : Ant, IPointerClickHandler
{
    [SerializeField]
    private AntWorker[] Workers;

    [SerializeField]
    private RectTransform WorkersContainer;

    [SerializeField]
    private GenerateMatrix Matrix;

    [SerializeField]
    private float EnergyByDeltaTime;

    [SerializeField]
    private Animator animator;

    private void FixedUpdate()
    {
        base.SpendEnergy(EnergyByDeltaTime);
    }

    public override void SpendEnergy(float value)
    {
        base.SpendEnergy(value);
        if (value < 0)
        {
            animator.Play("QueenHappy");
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        SummonAnt(AntType.Junior);
    }

    public void SummonAnt(AntType type)
    {     

        switch (type)
        {
            case AntType.Junior:
                var ant = Instantiate(Workers[0], transform.position, Quaternion.identity, WorkersContainer);
                ant.Queen = this;
                ant.SetMatrix(Matrix, WorkersContainer, new Vector2((int)Matrix.Size.x / 2, 0));
                ant.SetPath((int)Matrix.Size.x / 2, 0, true);                
                SpendEnergy(ant.AntCost);
                break;
        }
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("GAME OVER");
    }
}
