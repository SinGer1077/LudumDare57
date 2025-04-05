using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;
using System;

public class GenerateMatrix : MonoBehaviour
{    
    public Vector2 Size;

    public LevelBlock[,] LevelMatrix;

    public Block[] BlockPossibleTypes;

    [SerializeField]
    private GridLayoutGroup Grid;


    private void Awake()
    {
        LevelMatrix = new LevelBlock[(int)Size.x, (int)Size.y];
        FillMatrix();
        CreateGrid();
    }

    private void FillMatrix()
    {
        for (int i = 0; i < LevelMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < LevelMatrix.GetLength(1); j++)
            {
                LevelMatrix[i, j] = new LevelBlock(BlockPossibleTypes[Mathf.CeilToInt(UnityEngine.Random.Range(0, BlockPossibleTypes.Length))]);
            }
        }
    }
    private void CreateGrid()
    {
        RectTransform rectTransform = Grid.GetComponent<RectTransform>();
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        Grid.spacing = Vector2.zero;
        Grid.padding = new RectOffset(0, 0, 0, 0);
        Grid.childAlignment = TextAnchor.UpperLeft;

        float cellWidth = Mathf.Floor(width / Size.x);
        float cellHeight = Mathf.Floor(height / Size.y);

        Grid.cellSize = new Vector2(cellWidth, cellHeight);
        Grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        Grid.constraintCount = (int)Size.x;

        for (int i = 0; i < LevelMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < LevelMatrix.GetLength(1); j++)
            {
                var block = Instantiate(LevelMatrix[i, j].block, transform);
                
                if (j == (int)(Size.x / 2) && i == 0)
                {
                    block.ChangeDurability(1.0f);
                }

                float x = Grid.padding.left + i * (Grid.cellSize.x + Grid.spacing.x) + Grid.cellSize.x / 2.0f;
                float y = -Grid.padding.top - j * (Grid.cellSize.y + Grid.spacing.y) - Grid.cellSize.y / 2.0f;
                LevelMatrix[i, j].Position = new Vector2(x, y);
            }
        }



    }
}
