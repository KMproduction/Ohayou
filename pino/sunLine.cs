using UnityEngine;
using System.Collections;

public class sunLine : MonoBehaviour
{
    public GameObject cube_1;
    public GameObject cube_2;

    void Start()
    {

    }

    void Update()
    {

        LineRenderer lineY = GameObject.Find("sun_direction").GetComponent<LineRenderer>();

        lineY.SetPosition(0, cube_1.transform.position);
        lineY.SetPosition(1, cube_2.transform.position);
    }
}