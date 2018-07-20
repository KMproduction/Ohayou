using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_speedchanger : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Animator>().speed += 0.2f;
        }
    }
}
