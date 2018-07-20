using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class type_toggleswich : MonoBehaviour {
    public int type;
	// Use this for initialization
	public void Start () {
        type = 0;
	}
	
	// Update is called once per frame
	public void All (bool toggle) {
        if(toggle==true)
        type = 0;
	}
    public void Pr(bool toggle)
    {
        if (toggle == true)
            type = 1;
    }
    public void Fa(bool toggle)
    {
        if (toggle == true)
            type = 2;
    }
    public void An(bool toggle)
    {
        if (toggle == true)
            type = 3;
    }
}
