using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundchange_script : MonoBehaviour {
    public GameObject transparent;
    public GameObject Quadshibafu;
	// Use this for initialization
	public void  groundtrans(bool flag) {
        transparent.SetActive(flag);
        Quadshibafu.SetActive(!flag);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
