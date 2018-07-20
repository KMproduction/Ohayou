using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txt_way : MonoBehaviour {

    private Text targetText;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {

        GameObject cam = GameObject.Find("Main Camera");
        this.targetText = this.GetComponent<Text>();
        if (cam.transform.localEulerAngles.y < 22.5)
            this.targetText.text = "北";
        else if (cam.transform.localEulerAngles.y < 67.5)
            this.targetText.text = "北東";
        else if (cam.transform.localEulerAngles.y < 112.5)
            this.targetText.text = "東";
        else if (cam.transform.localEulerAngles.y < 157.5)
            this.targetText.text = "南東";
        else if (cam.transform.localEulerAngles.y < 202.5)
            this.targetText.text = "南";
        else if (cam.transform.localEulerAngles.y < 247.5)
            this.targetText.text = "南西";
        else if (cam.transform.localEulerAngles.y < 292.5)
            this.targetText.text = "西";
        else if (cam.transform.localEulerAngles.y < 337.5)
            this.targetText.text = "北西";
        else
            this.targetText.text = "北";
    }        
}
