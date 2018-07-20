using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class memtest : MonoBehaviour
{
    public Text test;
    int frameCount;
    float prevTime;

    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    void Update()
    {
        ++frameCount;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            test.text=( frameCount / time+"fps");

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}

