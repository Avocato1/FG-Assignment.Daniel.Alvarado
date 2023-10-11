
using UnityEngine;

public class WallDamage : MonoBehaviour
{
    private Car car;
    
    private int damage = 20;

    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponentInParent<Car>();
        car = player;
        if (car && car.currentSpeed >= 40)
        {
            car.carStats.currentHealth -= damage;
            car.carStats.healthText.text = car.carStats.currentHealth.ToString();
        }
    }
}
