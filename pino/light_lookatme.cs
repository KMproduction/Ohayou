using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_lookatme : MonoBehaviour {
    public GameObject me;
    public GameObject light;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        light.transform.LookAt(me.transform);
    }
}
