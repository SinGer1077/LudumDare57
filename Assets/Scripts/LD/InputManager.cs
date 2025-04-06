using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GenerateMatrix Matrix;

    [HideInInspector]
    public AntWorker CurrentChosenAnt;

    [HideInInspector]
    public Block CurrentBlock;

    [HideInInspector]
    public List<Block> Path;

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

    public void CreatePath(Block chosenBlock)
    {
        Path = new List<Block>();

        int byX = Mathf.Abs(CurrentChosenAnt.currentX - chosenBlock.y);
        int byY = Mathf.Abs(CurrentChosenAnt.currentY - chosenBlock.x);

        int x = CurrentChosenAnt.currentX;
        int y = CurrentChosenAnt.currentY;
        for (int i = 0; i < byX; i++)
        {
            if (CurrentChosenAnt.currentX > chosenBlock.y)
                x--;
            if (CurrentChosenAnt.currentX < chosenBlock.y)
                x++;
            Matrix.LevelMatrix[y, x].block.SetPath();
            Path.Add(Matrix.LevelMatrix[y, x].block);
        }
        for (int i = 0; i < byY; i++)
        {
            if (CurrentChosenAnt.currentY > chosenBlock.x)
                y--;
            if (CurrentChosenAnt.currentY < chosenBlock.x)
                y++;
            Matrix.LevelMatrix[y, x].block.SetPath();
            Path.Add(Matrix.LevelMatrix[y, x].block);
        }
    }

    public void PathChosen()
    {
        foreach (var point in Path)
        {
            point.UnsetPath();
        }
    }
}
