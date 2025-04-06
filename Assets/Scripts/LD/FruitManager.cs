using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public int FruitsCountOnLvl;

    [SerializeField]
    private Fruit[] Fruits;

    [SerializeField]
    private GenerateMatrix Matrix;

    [SerializeField]
    private RectTransform Parent;

    [SerializeField]
    private TextMeshProUGUI fruitCountText;

    [SerializeField]
    private GameProcess Process;

    public void Start()
    {
        fruitCountText.text = FruitsCountOnLvl.ToString();
    }

    public void FruitFounded(Fruit fruit)
    {
        fruit.FruitTaken();
        FruitsCountOnLvl--;
        fruitCountText.text = FruitsCountOnLvl.ToString();
        fruitCountText.rectTransform.DOJump(fruitCountText.rectTransform.position, 1.0f, 3, 1.5f);
        if (FruitsCountOnLvl <= 0)
        {
            Process.WinLevel();
        }
    }

    public Vector2 CalculatePosWithCoord(int x, int y)
    {
        return new Vector2(Matrix.LevelMatrix[x, y].Position.x + Parent.rect.position.x,
           Matrix.LevelMatrix[x, y].Position.y - Parent.rect.position.y);
    }

    public void ShuffleFruits()
    {
        var position = GetRandomPositions((int)Matrix.Size.x, (int)Matrix.Size.y, FruitsCountOnLvl);
        foreach (var poses in position)
        {
            //Matrix.LevelMatrix[poses.y, poses.x].Fruited = Instantiate(Fruits[Random.Range(0, Fruits.Length)], 
            //    CalculatePosWithCoord(poses.y, poses.x), Quaternion.identity, Parent);
            Matrix.LevelMatrix[poses.x, poses.y].Fruited = Instantiate(Fruits[Random.Range(0, Fruits.Length)],
                Matrix.LevelMatrix[poses.x, poses.y].block.transform);
            Debug.Log(poses.x + " " + poses.y);
        }
    }

    List<Vector2Int> GetRandomPositions(int width, int height, int count)
    {
        List<Vector2Int> allPositions = new List<Vector2Int>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                allPositions.Add(new Vector2Int(x, y));
            }
        }

        Shuffle(allPositions);

        return allPositions.GetRange(0, Mathf.Min(count, allPositions.Count));
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }
}
