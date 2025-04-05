using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AntWorker : Ant
{
    [SerializeField]
    private RectTransform Rect;

    private GenerateMatrix Matrix;

    private RectTransform Parent;

    public AntType Grade;

    public float Strength;

    public void SetMatrix(GenerateMatrix matrix, RectTransform parent)
    {
        Matrix = matrix;
        Parent = parent;
    }

    public void SetPath(int x, int y)
    {
        //Rect.DOLocalMove(Matrix.LevelMatrix[x, y].Position - new Vector2(Parent.position.x, Parent.position.y), 2.0f);
        Rect.localPosition = Matrix.LevelMatrix[x, y].Position;
    }

    public void DestroyBlock(Block block)
    {
        if (!block.Destroyed)
        {
            block.ChangeDurability(Strength);
            SpendEnergy(1.0f);
        }
    }

}
