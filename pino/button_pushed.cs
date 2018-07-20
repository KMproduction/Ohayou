using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_pushed : MonoBehaviour
{
    public bool push = false;

    public void PushDown()
    {
        push = true;
        Debug.Log("aa");
    }

    public void PushUp()
    {
        push = false;
    }

}
