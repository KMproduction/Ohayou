using UnityEngine;
//ジャイロのみ
public class compass : MonoBehaviour
{

    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion gattitude = Input.gyro.attitude;
        gattitude.x *= -1;
        gattitude.y *= -1;
        transform.localRotation =
            Quaternion.Euler(90, 0, 0) * gattitude;
    }
}