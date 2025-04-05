using DG.Tweening;
using UnityEngine;
using System.Collections;

public class AntJunior : AntWorker
{
    public override void GoToTarget()
    {
        int byX = Mathf.Abs(currentX - targetX);
        int byY = Mathf.Abs(currentY - targetY);

        Interactable = false;

        StartCoroutine(MoveInSteps(byX, byY));
    }

    private IEnumerator MoveInSteps(int xSteps, int ySteps)
    {
        int x = currentX;
        int y = currentY;
        for (int i = 0; i < xSteps; i++)
        {
            if ((int)IndexesToBegin.x > targetX)
                x--;
            else
                x++;

            Rect.DOLocalMove(CalculatePosWithCoord(x, y), 1.0f);

            yield return new WaitForSeconds(1.0f);

            DestroyBlock(Matrix.LevelMatrix[y, x].block);
            CheckForFruit(y ,x);
        }
        for (int i = 0; i < ySteps; i++)
        {
            if ((int)IndexesToBegin.y > targetY)
                y--;
            else
                y++;

            Rect.DOLocalMove(CalculatePosWithCoord(targetX, y), 1.0f);

            DestroyBlock(Matrix.LevelMatrix[y, x].block);
            CheckForFruit(y ,x);
            yield return new WaitForSeconds(1.0f);
        }

        currentX = targetX;  currentY = targetY;
        Interactable = true;
    }
}
