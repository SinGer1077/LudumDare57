using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private int indexThis;

    [SerializeField]
    private int indexNext;

    public void LevelThisLoad()
    {
        SceneManager.LoadSceneAsync(indexThis);
    }

    public void LevelNextLoad()
    {
        SceneManager.LoadSceneAsync(indexNext);
    }
}
