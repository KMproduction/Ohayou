using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class relay1 : MonoBehaviour
{
    public GameObject triup;
    public GameObject trileft;
    public GameObject triright;

    // Use this for initialization
    public void setrand(bool[] pattern)//27要素
    {
        relay p0 = triup.GetComponent<relay>();
        relay p1 = trileft.GetComponent<relay>();
        relay p2 = triright.GetComponent<relay>();
        int rand = UnityEngine.Random.Range(0, 5);//0～3を生成
        switch (rand)
        {
            case 0:
                p0.set(new bool[] { pattern[0], pattern[1], pattern[2], pattern[3], pattern[4], pattern[5], pattern[6], pattern[7], pattern[8] });
                p1.setallrand(new bool[] { pattern[9], pattern[10], pattern[11], pattern[12], pattern[13], pattern[14], pattern[15], pattern[16], pattern[17] });
                p2.setallrand(new bool[] { pattern[18], pattern[19], pattern[20], pattern[21], pattern[22], pattern[23], pattern[24], pattern[25], pattern[26] });
                break;
            case 1:
                p0.setallrand(new bool[] { pattern[0], pattern[1], pattern[2], pattern[3], pattern[4], pattern[5], pattern[6], pattern[7], pattern[8] });
                p1.set(new bool[] { pattern[9], pattern[10], pattern[11], pattern[12], pattern[13], pattern[14], pattern[15], pattern[16], pattern[17] });
                p2.setallrand(new bool[] { pattern[18], pattern[19], pattern[20], pattern[21], pattern[22], pattern[23], pattern[24], pattern[25], pattern[26] });
                break;
            case 2:
                p0.setallrand(new bool[] { pattern[0], pattern[1], pattern[2], pattern[3], pattern[4], pattern[5], pattern[6], pattern[7], pattern[8] });
                p1.setallrand(new bool[] { pattern[9], pattern[10], pattern[11], pattern[12], pattern[13], pattern[14], pattern[15], pattern[16], pattern[17] });
                p2.set(new bool[] { pattern[18], pattern[19], pattern[20], pattern[21], pattern[22], pattern[23], pattern[24], pattern[25], pattern[26] });
                break;
            case 3://完全ランダム
                p0.setallrand(new bool[] { pattern[0], pattern[1], pattern[2], pattern[3], pattern[4], pattern[5], pattern[6], pattern[7], pattern[8] });
                p1.setallrand(new bool[] { pattern[9], pattern[10], pattern[11], pattern[12], pattern[13], pattern[14], pattern[15], pattern[16], pattern[17] });
                p2.setallrand(new bool[] { pattern[18], pattern[19], pattern[20], pattern[21], pattern[22], pattern[23], pattern[24], pattern[25], pattern[26] });
                break;
            case 4://完全ランダム
                p0.setallrand(new bool[] { pattern[0], pattern[1], pattern[2], pattern[3], pattern[4], pattern[5], pattern[6], pattern[7], pattern[8] });
                p1.setallrand(new bool[] { pattern[9], pattern[10], pattern[11], pattern[12], pattern[13], pattern[14], pattern[15], pattern[16], pattern[17] });
                p2.setallrand(new bool[] { pattern[18], pattern[19], pattern[20], pattern[21], pattern[22], pattern[23], pattern[24], pattern[25], pattern[26] });
                break;
        }
    }

    public void set(bool[] pattern)
    {
        relay p0 = triup.GetComponent<relay>();
        relay p1 = trileft.GetComponent<relay>();
        relay p2 = triright.GetComponent<relay>();

        p0.set(new bool[] { pattern[0], pattern[1], pattern[2], pattern[3], pattern[4], pattern[5], pattern[6], pattern[7], pattern[8] });
        p1.set(new bool[] { pattern[9], pattern[10], pattern[11], pattern[12], pattern[13], pattern[14], pattern[15], pattern[16], pattern[17] });
        p2.set(new bool[] { pattern[18], pattern[19], pattern[20], pattern[21], pattern[22], pattern[23], pattern[24], pattern[25], pattern[26] });
    }

    public bool[] statusback()
    {
        relay p0 = triup.GetComponent<relay>();
        relay p1 = trileft.GetComponent<relay>();
        relay p2 = triright.GetComponent<relay>();

        bool[] statusall = new bool[27];
        Array.Copy(p0.statusback(), statusall, 9);
        Array.Copy(p1.statusback(), 0, statusall, 9, 9);
        Array.Copy(p2.statusback(), 0, statusall, 18, 9);

        return (statusall);
    }

    public bool kinsoku(bool[] pattern)
    {
        bool[] status = statusback();
        for (int i = 0; i < 27; i++)//0から9までの要素
        {
            if (status[i] != pattern[i])
            {
                Debug.Log("禁則でない");
                return (false);
            }
        }
        Debug.Log("禁則!!!!");
        return (true);
    }

    public void colorchange()
    {
        relay p0 = triup.GetComponent<relay>();
        relay p1 = trileft.GetComponent<relay>();
        relay p2 = triright.GetComponent<relay>();

        p0.colorchange();
        p1.colorchange();
        p2.colorchange();
    }

    public void aroundcolorchange()
    {
        relay p0 = triup.GetComponent<relay>();
        relay p1 = trileft.GetComponent<relay>();
        relay p2 = triright.GetComponent<relay>();

        p0.aroundcolorchange();
        p1.aroundcolorchange();
        p2.aroundcolorchange();
    }


}
