using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public AntWorker CurrentChosenAnt;

    [HideInInspector]
    public Block CurrentBlock;

    public void SelectAnt(AntWorker worker)
    {
        if (CurrentChosenAnt != worker)
        {
            UnselectAnt();
            CurrentChosenAnt = worker;
            CurrentChosenAnt.UpdateAura(true);
        }
    }

    public void UnselectAnt()
    {
        if (CurrentChosenAnt != null)
        {
            CurrentChosenAnt.UpdateAura(false);
            CurrentChosenAnt = null;
        }
    }
}
