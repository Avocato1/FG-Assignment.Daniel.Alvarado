
using UnityEngine;

public class Checkpoint : MonoBehaviour
{ 
    private Car car;


    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<Car>();
        car = player;
        if (car)
        {
            car.carStats.checkpoint = true;
            car.carStats.checkPoint = gameObject;}
    }
}
