using UnityEngine;
using System.Collections;

public class arrows : MonoBehaviour
{
    public float start_x, start_y, end_x, end_y, force_x, force_y;
    public int force = 60;
    //public GameObject arrow;



    //Taking the initial position of the mouse
    void OnMouseDown()
    {
        start_x = GameObject.Find("Puck").transform.position.x;
        start_y = GameObject.Find("Puck").transform.position.y;

        //arrow = Instantiate(Resources.Load("Arrow"),new Vector3(start_x,start_y,1f),Quaternion.identity) as GameObject;


    }



    //Taking the end position of the mouse and drawing a line renderer
    void OnMouseDrag()
    {
        GameObject.Find("Line").transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject.Find("Line").transform.position = new Vector3(GameObject.Find("Line").transform.position.x, GameObject.Find("Line").transform.position.y, 0);

        end_x = GameObject.Find("Line").transform.position.x;
        end_y = GameObject.Find("Line").transform.position.y;

        //arrow.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //arrow.transform.position = new Vector3(GameObject.Find("Line").transform.position.x, GameObject.Find("Line").transform.position.y, 0);
        //arrow.transform.rotation = GameObject.Find("Line").transform.rotation;


        if (GetComponent<LineRenderer>() != null)
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetVertexCount(2);
            GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 1));
            GetComponent<LineRenderer>().SetPosition(1, new Vector3(GameObject.Find("Line").transform.position.x, GameObject.Find("Line").transform.position.y, 1));
            GetComponent<LineRenderer>().SetWidth(0f, 1f);
            GetComponent<LineRenderer>().sortingLayerName = ("myLayer");
            GetComponent<LineRenderer>().sortingOrder = 10;
        }
    }


    //Calculating the force
    void OnMouseUp()
    {
        force_x = start_x - end_x;
        force_y = start_y - end_y;

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force_y * force);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * force_x * force);


        //Hide LineRenderer if one is attached
        if (GetComponent<LineRenderer>() != null)
        {
            GetComponent<LineRenderer>().enabled = false;
        }

        //Destroy(arrow);

        //Turning on gravity if needed
        //GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().drag = 0.9f;
    }



}