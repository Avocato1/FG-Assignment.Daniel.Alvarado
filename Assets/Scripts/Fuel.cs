
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private Car car;


    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<Car>();
        car = player;
        int addFuel = 50; 
        int availableFuelToAdd = car.carStats.maxFuel - car.carStats.currentFuel;
        if (car)
        {
            car.carStats.currentFuel += addFuel;
            Destroy(gameObject);
        }
        if (addFuel > availableFuelToAdd)
        {
            car.carStats.currentFuel = car.carStats.maxFuel;
        }
        else
        {
            car.carStats.currentFuel += addFuel;
        }
    }
}
