using DG.Tweening;
using UnityEngine;
using System.Collections;

public class AntJunior : AntWorker
{
    public override void GoToTarget()
    {
        int byX = Mathf.Abs((int)IndexesToBegin.x - targetX);
        int byY = Mathf.Abs((int)IndexesToBegin.y - targetY);

        StartCoroutine(MoveInSteps(byX, byY));
    }

    private IEnumerator MoveInSteps(int xSteps, int ySteps)
    {
        int x = (int)IndexesToBegin.x;
        int y = (int)IndexesToBegin.y;
        for (int i = 0; i < xSteps; i++)
        {
            if ((int)IndexesToBegin.x > targetX)
                x--;
            else
                x++;

            Rect.DOLocalMove(CalculatePosWithCoord(x, y), 1.0f);

            yield return new WaitForSeconds(1.0f);
        }
        for (int i = 0; i < ySteps; i++)
        {
            if ((int)IndexesToBegin.y > targetY)
                y--;
            else
                y++;

            Rect.DOLocalMove(CalculatePosWithCoord(targetX, y), 1.0f);

            yield return new WaitForSeconds(1.0f);
        }

        IndexesToBegin = new Vector2(targetX, targetY);
    }
}
