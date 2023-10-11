using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool levelChanged = false;
    void Awake()
    {
        if(instance == null)
        {
          instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadLevel(string levelName)
    {
        var level = SceneManager.LoadSceneAsync(levelName);
        level.allowSceneActivation = true;
        levelChanged = true;
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
