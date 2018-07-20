
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += this.transform.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += this.transform.forward * -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += this.transform.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += this.transform.right * -1;
        }


        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(-1.0f, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(1.0f, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0.0f, -1.0f, 0.0f, Space.World);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0.0f, 1.0f, 0.0f, Space.World);
        }
    }
}
