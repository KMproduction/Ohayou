using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour {
    public bool running = true;
    public GameObject scriptbox;
    public GameObject stopbutton;
    public GameObject resumubutton;
    public GameObject pausetriangle;
    public int stopkaisuu=0;
	// Use this for initialization
	public void Stop () {
        timekeeper tk = scriptbox.GetComponent<timekeeper>();
        tk.flag = false;
        running = false;
        stopbutton.SetActive(false);
        resumubutton.SetActive(true);
        pausetriangle.SetActive(true);
        stopkaisuu++;

    }
	
	// Update is called once per frame
	public void Resume () {
        timekeeper tk = scriptbox.GetComponent<timekeeper>();
        tk.flag = true;
        running = true;
        stopbutton.SetActive(true);
        resumubutton.SetActive(false);
        pausetriangle.SetActive(false);
    }
}
