using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class counter : MonoBehaviour {
    string str;
    public InputField text;
    int num;

    // Use this for initialization
    public void Increase()
    {
        int num;
        num = int.Parse(text.text);
        num += 1;
        text.text = num.ToString();
        
    }
	
	// Update is called once per frame
	public void Decrease () {
        num = int.Parse(text.text);
        if(num>0)
        num -= 1;
        text.text = num.ToString();

    }
}
