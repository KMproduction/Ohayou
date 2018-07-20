using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THrotate : MonoBehaviour {
    Vector3 vector = new Vector3(0, 0, 0);//太陽の南中角度 x=0
    public GameObject th;//透明半球

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        th.transform.eulerAngles = new Vector3(0, 0, 0);

    }
}
