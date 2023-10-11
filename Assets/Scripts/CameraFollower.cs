using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform vehicle;
    public GameObject child;
    public float camDistance = 8;
    
    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * camDistance);
        gameObject.transform.LookAt(vehicle.gameObject.transform.position);
    }
}
