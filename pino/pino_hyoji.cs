using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pino_hyoji : MonoBehaviour {
    public GameObject TH_out;
    public GameObject TH_in;
    public GameObject pino;
    public float disappearsize;
    public int size;
    public bool pinoactive;
 
    // Use this for initialization
    void Start () {
        size = 100;
      
    }

    public void ava_active(bool activeornot)
    {
        pinoactive = activeornot;
    }

    // Update is called once per frame
    void Update () {
//        Debug.Log("ohayou");
//        Debug.Log(TH_in.transform.localScale + " , " + TH_out.transform.localScale+" , " +size);
        if(size == 1 && (TH_in.transform.localScale.x * TH_out.transform.localScale.x > disappearsize || pinoactive==false))//十分大きくなった
        {
            pino.SetActive(false);
            size = 100;
        }
        else if (TH_in.transform.localScale.x * TH_out.transform.localScale.x <= disappearsize&&pinoactive==true && size == 100)//十分小さくなった
        {
            pino.SetActive(true);
            size = 1;
        }

    }

}
