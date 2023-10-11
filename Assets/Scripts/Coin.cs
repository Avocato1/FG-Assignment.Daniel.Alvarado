
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Car car;
    private SpeedBoost speedBoost;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<Car>();
        car = player;
        if (car)
        {
            switch (car.playerIndex)
            {
                case 0:
                    car.carStats.scoreSO.CoinScore += 1;
                    car.carStats.coinText.text = car.carStats.scoreSO.CoinScore + "";
                    break;
                case 1:
                    car.carStats.scoreSO.P2CoinScore += 1;
                    car.carStats.coinText.text = car.carStats.scoreSO.P2CoinScore + "";
                    break;
            }
            Destroy(gameObject);
           CoinCollecting();
        }
    }
    
    
    public void CoinCollecting()
    {
        switch (car.playerIndex)
        {
            case 0:
                if (car.carStats.scoreSO.CoinScore % 30 == 0)
                {
                    car.maxSpeed += car.carStats.speedBoost;
                    car.acceleration += 50;
                    car.carStats.StartSpeedTimer();
                }
                break;
            case 1:
                if (car.carStats.scoreSO.P2CoinScore % 30 == 0)
                {
                    car.maxSpeed += car.carStats.speedBoost;
                    car.acceleration += 50;
                    car.carStats.StartSpeedTimer();
                }
                break;
        }
    }
}
