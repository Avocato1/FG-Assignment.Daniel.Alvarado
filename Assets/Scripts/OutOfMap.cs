using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    private Car car;


    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<Car>();
        car = player;
        if (car)
        {
            if (!car.carStats.checkpoint)
            {
                car.carStats.currentHealth -= car.carStats._damage * 2;
                car.carStats.healthText.text = car.carStats.currentHealth.ToString();
                car.ResetPosition();
                car.rb.velocity = Vector3.zero;
            }
            else
            {
                
                car.carStats.currentHealth -= car.carStats._damage * 2;
                car.carStats.healthText.text = car.carStats.currentHealth.ToString();
                car.rb.position = car.carStats.checkPoint.transform.position;
                car.rb.rotation = car.carStats.checkPoint.transform.rotation;

                car.rb.velocity = Vector3.zero;
            }
        }
    }
}
