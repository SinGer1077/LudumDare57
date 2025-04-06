using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{
    [SerializeField]
    private GameObject WinCanvas;
    [SerializeField]
    private Image WinPanel;

    [SerializeField]
    private GameObject LoseCanvas;
    [SerializeField]
    private Image LosePanel;

    public void WinLevel()
    {
        WinCanvas.SetActive(true);
        WinPanel.DOFade(0.3f, 0.5f);
    }

    public void LoseLevel()
    {
        LoseCanvas.SetActive(true);
        LosePanel.DOFade(0.3f, 0.5f);
    }
}
