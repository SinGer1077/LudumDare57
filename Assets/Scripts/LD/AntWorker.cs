using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AntWorker : Ant
{
    [SerializeField]
    protected RectTransform Rect;

    public float AntCost;

    protected GenerateMatrix Matrix;

    protected RectTransform Parent;

    public AntType Grade;

    public float Strength;

    protected Vector2 IndexesToBegin;
    protected int currentX, currentY;

    private bool Chosen;

    protected InputManager InputManager;
    protected FruitManager FruitManager;

    protected Vector2 targetPos;
    protected int targetX, targetY;

    [SerializeField]
    protected Image Aura;

    [HideInInspector]
    public bool Interactable;

    [HideInInspector]
    public AntQueen Queen;

    public override void Start()
    {
        base.Start();
        InputManager = FindFirstObjectByType<InputManager>();
        FruitManager = FindFirstObjectByType<FruitManager>();
        Interactable = true;
    }

    public void SetMatrix(GenerateMatrix matrix, RectTransform parent, Vector2 indexes)
    {
        Matrix = matrix;
        Parent = parent;
        IndexesToBegin = indexes;
        currentX = (int)indexes.x; currentY = (int)indexes.y;
    }

    public Vector2 CalculatePosWithCoord(int x, int y)
    {
        return new Vector2(Matrix.LevelMatrix[x, y].Position.x + Parent.rect.position.x,
           Matrix.LevelMatrix[x, y].Position.y - Parent.rect.position.y);
    }

    public void SetPath(int x, int y, bool justMove)
    {        
        if (justMove) 
        {
            targetPos = CalculatePosWithCoord(x, y);
            var move = Rect.DOLocalMove(targetPos, 0.5f);
        }
        else
        {
            InputManager.UnselectAnt();
            targetX = x; targetY = y;
            GoToTarget();
        }            
    }    

    public virtual void GoToTarget() { }

    public void DestroyBlock(Block block)
    {
        if (!block.Destroyed)
        {
            block.ChangeDurability(Strength);
            SpendEnergy(1.0f);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!Interactable)
            return;

        if (eventData.button == 0)
        {
            if (!Chosen)
            {
                Chosen = true;

                InputManager.SelectAnt(this);                
            }
            else
            {
                Chosen = false;
                InputManager.UnselectAnt();                
            }
        }
    }

    public void UpdateAura(bool flag)
    {
        if (flag)
        {
            var aura = Aura.color;
            aura.a = 1.0f;
            Aura.color = aura;
        }
        else
        {
            var aura = Aura.color;
            aura.a = 0.0f;
            Aura.color = aura;
        }
    }

    public void CheckForFruit(int x, int y)
    {
        Debug.Log(x + " " + y + " " + Matrix.LevelMatrix[x, y].Fruited);
        if (Matrix.LevelMatrix[x, y].Fruited != null)
        {
            Debug.Log("FOUNDED!!!");
            Queen.SpendEnergy(-Matrix.LevelMatrix[x, y].Fruited.EnergyRestore);
            FruitManager.FruitFounded(Matrix.LevelMatrix[x, y].Fruited);
        }
    }

}
