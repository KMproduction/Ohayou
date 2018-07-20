using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadmove : MonoBehaviour {
    public GameObject quad;
    public GameObject camera;
    public bool cameratraceflag ;

    // Use this for initialization
    void Start () {
        cameratraceflag = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(cameratraceflag)
        quad.transform.rotation = camera.transform.rotation;
    }
}
