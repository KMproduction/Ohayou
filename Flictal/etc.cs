using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class etc : MonoBehaviour {
    public Toggle se;
    public Toggle bgm;

	// Use this for initialization
	public void sebutton () {
        se.isOn=!se.isOn;
	}
    public void bgmbutton()
    {
        bgm.isOn = !bgm.isOn;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
