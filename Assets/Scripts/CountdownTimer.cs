using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    public float currentCountDownTime = 0f;
    float startingTime = 3f;
    
     
        
    [SerializeField] private Text countDownText;
    void Start()
    {
        currentCountDownTime = startingTime;
    }
    
    void Update()
    {
        currentCountDownTime  -= 1 * Time.deltaTime;
        countDownText.text = currentCountDownTime .ToString("0");
        
        
        
        if (currentCountDownTime  <= 0)
        {
            countDownText.gameObject.SetActive(false);
            currentCountDownTime  = 0;
        }
    }
}
