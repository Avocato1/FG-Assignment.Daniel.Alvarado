
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
    }
}
