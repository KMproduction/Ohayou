using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reality : MonoBehaviour {
    public int Width = 480;//1920;
    public int Height = 270;//1080;
    public int FPS = 20;

    // Use this for initialization
    void Start() {
        WebCamDevice[] devices = WebCamTexture.devices;
        // display all cameras
        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }
        WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
