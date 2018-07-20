using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle_script : MonoBehaviour {
    public Toggle toggle;
    public GameObject shukusho_nomi;
    // Use this for initialization
	public void Reverse () {
        toggle.isOn = !toggle.isOn;
        
    }
	public void ava_buttoncontrol()
    {
        shukusho_nomi.SetActive(toggle.isOn);
    }
}
