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

    private Vector2 IndexesToBegin;

    public void SetMatrix(GenerateMatrix matrix, RectTransform parent, Vector2 indexes)
    {
        Matrix = matrix;
        Parent = parent;
        IndexesToBegin = indexes;
    }

    public void SetPath(int x, int y)
    {
        Vector2 posToMove = new Vector2(Matrix.LevelMatrix[x, y].Position.x + Parent.rect.position.x,
            Matrix.LevelMatrix[x, y].Position.y - Parent.rect.position.y);
        Rect.DOLocalMove(posToMove, 1.0f);       
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
