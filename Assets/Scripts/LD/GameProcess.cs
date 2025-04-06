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

    [SerializeField]
    private AudioSource Theme;

    [SerializeField]
    private AudioSource WinSound;

    [SerializeField]
    private AudioSource LoseSound;

    public void WinLevel()
    {
        WinCanvas.SetActive(true);
        WinPanel.DOFade(0.3f, 0.5f);
        Theme.Stop();
        WinSound.Play();
    }

    public void LoseLevel()
    {
        LoseCanvas.SetActive(true);
        LosePanel.DOFade(0.3f, 0.5f);
        //Theme.Stop();
        //LoseSound.Play();
    }
}
