using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections.Generic;


public class sizefix : MonoBehaviour {
    public GameObject camera;
    public GameObject TH;
    public GameObject TH_k;
    public InputField height_IF;
    public InputField TH_kyori_IF;
    public InputField TH_size_IF;

	// Use this for initialization
	public void TH_kyoriset (string value) {
        float kyori = int.Parse(value);
        TH_k.transform.localPosition = new Vector3(0, 0, kyori/100 -0.5f);

    }

    public void TH_sizeiset(string value)
    {
        float size = int.Parse(value);
        TH.transform.localScale = new Vector3(size/40, size/40, size/40);
    }

    public void heightset(string value)
    {
        float height = int.Parse(value);
        camera.transform.position = new Vector3(10,  height / 100 , 0);

    }
    
}
