using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public AntWorker CurrentChosenAnt;

    [HideInInspector]
    public Block CurrentBlock;

    public void SelectAnt(AntWorker worker)
    {
        CurrentChosenAnt = worker;
    }

    public void UnselectAnt()
    {
        CurrentChosenAnt = null;
    }

}
