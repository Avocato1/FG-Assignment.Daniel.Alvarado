using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int damage = 20;

    private void OnCollisionEnter(Collision other)
    {
        var enemyCar = other.gameObject.GetComponentInParent<Car>();
        var yourCar = GetComponentInParent<Car>();

        //Deal damage to another player
        if (enemyCar == null || yourCar == null || enemyCar.playerIndex == yourCar.playerIndex) return;
        if (!(yourCar.currentSpeed >= 40)) return;
        enemyCar.carStats.currentHealth -= damage;
        enemyCar.carStats.healthText.text = enemyCar.carStats.currentHealth.ToString();
    }
}