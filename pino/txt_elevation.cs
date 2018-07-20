using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txt_elevation : MonoBehaviour
{

    private Text targetText;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        GameObject cam = GameObject.Find("Main Camera");
        this.targetText = this.GetComponent<Text>();
        if (cam.transform.localEulerAngles.x < 180) //下を見ていれば
            this.targetText.text = "視線方向:　仰角 " + (- (int)cam.transform.localEulerAngles.x) + " °";
        else //上を見ていれば
            this.targetText.text = "視線方向:　仰角 " + (360 - (int)cam.transform.localEulerAngles.x) + " °";
    }
}
