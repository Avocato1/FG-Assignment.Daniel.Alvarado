using UnityEngine;
using UnityEngine.UI;

public class PlayerWonMenu : MonoBehaviour
{   
    private CarStats carStats;
    [SerializeField] private FloatSO floatSo;
    
    public GameObject playerWonMenuUI;
    
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Text playerWonText;

    
    void Update()
    {
        PlayerWon();
    }

    private void PlayerWon()
    {
        if (floatSo.LapScore == 3)
        {
            Time.timeScale = 0f;
            playerWonMenuUI.SetActive(true);
            playerWonText.text = "Player 1 Won";
            floatSo.LapScore = 0;

            if (!levelManager.levelChanged) return;
            playerWonMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (floatSo.P2LapScore == 3)
        {
            Time.timeScale = 0f;
            playerWonMenuUI.SetActive(true);
            playerWonText.text = "Player 2 Won";
            floatSo.P2LapScore = 0;

            if (!levelManager.levelChanged) return;
            playerWonMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
       
    }
}
