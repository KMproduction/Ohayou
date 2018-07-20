using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_normal : MonoBehaviour {
    public bool push = false;

	public void PushDown()
    {
        push = true;
    }

    public void PushUp()
    {
        push = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
