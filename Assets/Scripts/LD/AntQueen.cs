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

    private void FixedUpdate()
    {
        SpendEnergy(EnergyByDeltaTime);
        Debug.Log(Energy);
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
