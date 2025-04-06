using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LevelLoad(int buildIndex)
    {
        SceneManager.LoadSceneAsync(buildIndex);
    }
}
