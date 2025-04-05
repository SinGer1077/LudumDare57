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



    public void OnPointerClick(PointerEventData eventData)
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
                ant.SetPath((int)Matrix.Size.x / 2, 0);
                break;
        }
    }    
}
