using UnityEngine;

public class ChangeLevelButton : MonoBehaviour
{
    public void ChangeLevel(string levelName)
    {
        LevelManager.instance.LoadLevel(levelName);
    }
}
