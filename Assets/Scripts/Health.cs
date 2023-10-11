
using UnityEngine;

public class Health : MonoBehaviour
{
    private Car car;

    private void OnTriggerEnter(Collider coll)
    {
        var player = coll.gameObject.GetComponentInParent<Car>();
        car = player;
        if (car)
        {
            int addHealth = 30;
            int availableHealthToAdd = car.carStats.maxHealth - car.carStats.currentHealth;

            if (addHealth > availableHealthToAdd)
            {
                car.carStats.currentHealth = car.carStats.maxHealth;
            }
            else
            {
                car.carStats.currentHealth += addHealth;
            }
            car.carStats.healthText.text = car.carStats.currentHealth.ToString();
            Destroy(gameObject);
        }
        
    }
}
