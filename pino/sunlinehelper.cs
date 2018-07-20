using UnityEngine;
using System.Collections;

public class sunlinehelper : MonoBehaviour
{
    public GameObject front;
    public GameObject sun;
    public float back;//矢印の先端は
    public float medium;
    public float head;//矢印の根元は
    

    void Start()
    {

    }

    void Update()
    {
        LineRenderer lineY = GameObject.Find("sun_direction").GetComponent<LineRenderer>();
        var heading = sun.transform. position - front.transform.position;
        lineY.SetPosition(0, front.transform.position+heading*back);
        lineY.SetPosition(1, front.transform.position+heading*medium);

        LineRenderer lineX = GameObject.Find("sun_direction2").GetComponent<LineRenderer>();
        var heading2 = sun.transform.position - front.transform.position;
        lineX.SetPosition(0, front.transform.position + heading2 * medium);
        lineX.SetPosition(1, front.transform.position + heading2 * head);

    }
}