using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Joystick1Button1))  /* || (Input.GetTouch(0).phase == TouchPhase.Began)*/ || (Input.GetKeyDown(KeyCode.Joystick1Button0)))
            Destroy(gameObject);
    }

}
