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
    private Transform WorkersContainer;

    public void OnPointerClick(PointerEventData eventData)
    {
        SummonAnt(AntType.Junior);
    }

    public void SummonAnt(AntType type)
    {
        switch (type)
        {
            case AntType.Junior:
                Instantiate(Workers[0], SpawnPoint.position, Quaternion.identity, WorkersContainer);
                break;
        }
    }    
}
