using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AntQueen : Ant, IPointerClickHandler
{
    [SerializeField]
    private RectTransform Rect;

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

    [SerializeField]
    private GameProcess Process;

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
        //SummonAnt(AntType.Junior);
    }

    public void SummonAnt(AntType type)
    {     

        switch (type)
        {
            case AntType.Junior:
                var ant1 = Instantiate(Workers[0], transform.position, Quaternion.identity, WorkersContainer);
                ant1.Queen = this;
                ant1.SetMatrix(Matrix, WorkersContainer, new Vector2((int)Matrix.Size.x / 2, 0));
                ant1.SetPath((int)Matrix.Size.x / 2, 0, true);                
                SpendEnergy(ant1.AntCost);
                break;
            case AntType.Senior:
                var ant2 = Instantiate(Workers[2], transform.position, Quaternion.identity, WorkersContainer);
                ant2.Queen = this;
                ant2.SetMatrix(Matrix, WorkersContainer, new Vector2((int)Matrix.Size.x / 2, 0));
                ant2.SetPath((int)Matrix.Size.x / 2, 0, true);
                SpendEnergy(ant2.AntCost);
                break;
        }
    }

    public override void Die()
    {
        //animator.SetBool("Dead", true);
        animator.Play("QueenDeath");
        //Rect.DORotate(new Vector3(0.0f, 0.0f, 180.0f), 1.0f);
        Process.LoseLevel();
        //DOVirtual.DelayedCall(1.0f, () =>
        //{
            //base.Die();
        //});
    }
}
