using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private Car car;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<Car>();
        car = player;
        if (car && car.carStats.checkpoint)

        {
            switch (car.playerIndex)
            {
                case 0:
                    car.carStats.scoreSO.LapScore += 1;
                    car.carStats.lapText.text = car.carStats.scoreSO.LapScore + "";
                    car.carStats.checkpoint = false;
                    break;
                case 1:
                    car.carStats.scoreSO.P2LapScore += 1;
                    car.carStats.lapText.text = car.carStats.scoreSO.P2LapScore + "";
                    car.carStats.checkpoint = false;
                    break;
            }
        }
    }
}
