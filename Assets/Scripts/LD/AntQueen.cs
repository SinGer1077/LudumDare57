using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AntQueen : Ant, IPointerClickHandler
{
    [SerializeField]
    private AntWorker[] Workers;

    [SerializeField]
    private RectTransform SpawnPoint;

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
                var ant = Instantiate(Workers[0], SpawnPoint.position, Quaternion.identity, WorkersContainer);
                Debug.Log(WorkersContainer.rect.position);
                ant.SetMatrix(Matrix, WorkersContainer);
                ant.SetPath(1, 1);
                break;
        }
    }    
}
