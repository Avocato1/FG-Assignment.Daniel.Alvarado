using System.Collections;
using TMPro;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    [Header("Fuel Settings")]
    public int maxFuel = 100; public int currentFuel = 0; 
    [SerializeField] private TextMeshProUGUI fuelText;
    
    [Header("Player 1 Health")]
    public int maxHealth = 100;
    public int currentHealth = 0;
    public TextMeshProUGUI healthText;
    public int _damage = 10;
    
    [Header("ScoreSystem")]
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI lapText;
    public FloatSO scoreSO;
    
    [HideInInspector]
    public float speedBoost = 10f;
    public GameObject checkPoint;
    
    private bool isConsumingFuel = false;

    private Car car;
    
    public bool checkpoint = false;


    private void Start()
    {
        healthText.text = currentHealth + "";
        fuelText.text = currentFuel + "";
    }

    private void Awake()
    {
        scoreSO.LapScore = 0;
        scoreSO.P2LapScore = 0;
        scoreSO.CoinScore = 0;
        scoreSO.P2CoinScore = 0;
        
        lapText.text = scoreSO.LapScore + "";
        coinText.text = scoreSO.CoinScore + "";
        car = GetComponent<Car>();
        currentFuel = maxFuel;
        currentHealth = maxHealth;
    }
    
    
    
    public void Fuel()
    {
        if (!isConsumingFuel && car.currentSpeed > 0)
        {
            isConsumingFuel = true;
            StartCoroutine(FuelConsume());
        }

        if (currentFuel == 0)
        {
            car.rb.velocity = Vector3.zero;
            
            car.ResetPosition();
            currentFuel = maxFuel;
        }
    }


    public void StartSpeedTimer()
    {
        StartCoroutine(SpeedBoostTimer());
    }
    
    private IEnumerator FuelConsume()
    {
        while (car.currentAcceleration > 0 || car.currentAcceleration < 0)
        {
            yield return new WaitForSeconds(.5f);
            currentFuel -= 1;
            fuelText.text = currentFuel + "";

            if (currentFuel <= 0)
            {
                currentFuel = 0;
                car.currentSpeed = 0;
            }
        }
        isConsumingFuel = false;
    }
    
    private IEnumerator SpeedBoostTimer()
    {
        yield return new WaitForSeconds(2f);
        while (car.maxSpeed > 10 && car.acceleration > 65)
        {
            car.maxSpeed -= 1 * Time.deltaTime;
            car.acceleration -= 50 * Time.deltaTime;
        }
    }
}