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
            if (currentX > targetX)
            {
                x--;
                Rect.DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
            }
            if (currentX < targetX)
            {
                x++;
                Rect.DORotate(new Vector3(0.0f, 180.0f, 0.0f), 0.0f);
            }

            Rect.DOLocalMove(CalculatePosWithCoord(x, y), 1.0f);

            yield return new WaitForSeconds(1.0f);

            DestroyBlock(Matrix.LevelMatrix[y, x].block);
            CheckForFruit(y ,x);
            animations.Play("Move");
        }
        for (int i = 0; i < ySteps; i++)
        {
            if (currentY > targetY)
            {
                y--;
                Rect.DORotate(new Vector3(0.0f, 0.0f, 270.0f), 0.0f);
            }
            if (currentY < targetY)
            {
                y++;
                Rect.DORotate(new Vector3(0.0f, 0.0f, 90.0f), 0.0f);
            }

            Rect.DOLocalMove(CalculatePosWithCoord(targetX, y), 1.0f);

            DestroyBlock(Matrix.LevelMatrix[y, x].block);
            CheckForFruit(y ,x);
            animations.Play("Move");
            yield return new WaitForSeconds(1.0f);
        }

        currentX = targetX;  currentY = targetY;
        Interactable = true;
    }
}
