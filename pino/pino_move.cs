using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pino_move : MonoBehaviour {
    public GameObject head;
    public GameObject body;
    public GameObject camera;
    public GameObject sun;
    Quaternion angle = Quaternion.identity;
    Quaternion anglehead = Quaternion.identity;
    public int pinoflag;//1、視線一致　2,固定　3、太陽凝視
    int pinoflag_memory;
    public bool moveflag;
    public GameObject GodCupsule;
    public GameObject transparent;

    // Use this for initialization
    void Start () {
        pinoflag =2;
	}

    public void pinochange(int pflag){
        pinoflag = pflag;
        pinoflag_memory = pflag;
        }
    public void pinomove(bool move)
    {
        if (move == true) moveflag = true;
        else moveflag=false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = camera.transform.localEulerAngles.x;
        float y = camera.transform.localEulerAngles.y;
        float z = camera.transform.localEulerAngles.z;

        if (x > 180)
        {
      //      Debug.Log(x + " " + y + " " + z);
            GodCupsule.SetActive(false);
            transparent.SetActive(true);
        }else
        {
            GodCupsule.SetActive(true);
            transparent.SetActive(false);
        }
        if (moveflag == true)
        {
            if (pinoflag == 1)
            {
                //head.transform.rotation = camera.transform.rotation;
                angle.eulerAngles = new Vector3(0, y, 0);
                body.transform.rotation = angle;
                anglehead.eulerAngles = new Vector3(x, y, 0);
                head.transform.rotation = anglehead;
            }
            else if (pinoflag == 2)//太陽注視
            {

                head.transform.LookAt(sun.transform);
                Vector3 targetPos = sun.transform.position;
                targetPos.y = body.transform.position.y;
                //         targetPos.z = body.transform.position.z;
                body.transform.LookAt(targetPos);

            }
        }
    }
}
