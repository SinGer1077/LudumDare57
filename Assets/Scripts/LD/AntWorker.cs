using UnityEngine;

public class AntWorker : Ant
{
    public AntType Grade;

    public float Strength;

    public void DestroyBlock(Block block)
    {
        if (!block.Destroyed)
        {
            block.ChangeDurability(Strength);
            SpendEnergy(1.0f);
        }
    }

}
