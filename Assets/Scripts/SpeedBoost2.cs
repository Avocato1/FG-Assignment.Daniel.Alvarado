using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost2 : MonoBehaviour
{
    private Car car;
    [SerializeField]
    private int speedBoost = 6;
    [SerializeField]
    private int accelerationBoost = 50;
    private void OnTriggerEnter(Collider coll)
    {
        var player = coll.gameObject.GetComponentInParent<Car>();
        car = player;
        if(car)
        {
            car.maxSpeed += speedBoost;
            car.acceleration += accelerationBoost;
            car.carStats.StartSpeedTimer();
        }
    }
}
