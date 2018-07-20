using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class relay : MonoBehaviour {
    public GameObject triup;
    public GameObject trileft;
    public GameObject triright;

    // Use this for initialization
    public void setrand(bool[] pattern)//9要素
    {
        patternset p0 = triup.GetComponent<patternset>();
        patternset p1 = trileft.GetComponent<patternset>();
        patternset p2 = triright.GetComponent<patternset>();

        int rand = UnityEngine.Random.Range(0, 6);//0～3を生成
        switch (rand) {
            case 0:
                p0.set(new bool[] { pattern[0], pattern[1], pattern[2] });
                p1.setrand(new bool[] { pattern[3], pattern[4], pattern[5] });
                p2.setrand(new bool[] { pattern[6], pattern[7], pattern[8] });
                break;
            case 1:
                p0.setrand(new bool[] { pattern[0], pattern[1], pattern[2] });
                p1.set(new bool[] { pattern[3], pattern[4], pattern[5] });
                p2.setrand(new bool[] { pattern[6], pattern[7], pattern[8] });
                break;
            case 2:
                p0.setrand(new bool[] { pattern[0], pattern[1], pattern[2] });
                p1.setrand(new bool[] { pattern[3], pattern[4], pattern[5] });
                p2.set(new bool[] { pattern[6], pattern[7], pattern[8] });
                break;
            case 3://完全ランダム
                p0.setrand(new bool[] { pattern[0], pattern[1], pattern[2] });
                p1.setrand(new bool[] { pattern[3], pattern[4], pattern[5] });
                p2.setrand(new bool[] { pattern[6], pattern[7], pattern[8] });
                break;
            case 4://完全ランダム
                p0.setrand(new bool[] { pattern[0], pattern[1], pattern[2] });
                p1.setrand(new bool[] { pattern[3], pattern[4], pattern[5] });
                p2.setrand(new bool[] { pattern[6], pattern[7], pattern[8] });
                break;
            case 5://完全ランダム
                p0.setrand(new bool[] { pattern[0], pattern[1], pattern[2] });
                p1.setrand(new bool[] { pattern[3], pattern[4], pattern[5] });
                p2.setrand(new bool[] { pattern[6], pattern[7], pattern[8] });
                break;
        }

    }

    public void setallrand(bool[] pattern)//9要素
    {
        patternset p0 = triup.GetComponent<patternset>();
        patternset p1 = trileft.GetComponent<patternset>();
        patternset p2 = triright.GetComponent<patternset>();

                p0.setrand(new bool[] { pattern[0], pattern[1], pattern[2] });
                p1.setrand(new bool[] { pattern[3], pattern[4], pattern[5] });
                p2.setrand(new bool[] { pattern[6], pattern[7], pattern[8] });
    }


    public void set(bool[] pattern)
    {
        patternset p0 = triup.GetComponent<patternset>();
        patternset p1 = trileft.GetComponent<patternset>();
        patternset p2 = triright.GetComponent<patternset>();

        p0.set(new bool[] { pattern[0], pattern[1], pattern[2] });
        p1.set(new bool[] { pattern[3], pattern[4], pattern[5] });
        p2.set(new bool[] { pattern[6], pattern[7], pattern[8] });
    }

    public void colorchange()
    {
        patternset p0 = triup.GetComponent<patternset>();
        patternset p1 = trileft.GetComponent<patternset>();
        patternset p2 = triright.GetComponent<patternset>();

        p0.colorchange();
        p1.colorchange();
        p2.colorchange();
    }

    public void aroundcolorchange()
    {
        patternset p0 = triup.GetComponent<patternset>();
        patternset p1 = trileft.GetComponent<patternset>();
        patternset p2 = triright.GetComponent<patternset>();

        p0.aroundcolorchange();
        p1.aroundcolorchange();
        p2.aroundcolorchange();
    }




    public bool[] statusback()
    {
        patternset p0 = triup.GetComponent<patternset>();
        patternset p1 = trileft.GetComponent<patternset>();
        patternset p2 = triright.GetComponent<patternset>();

        bool[] statusall = new bool[9];
        Array.Copy(p0.statusback(), statusall, 3);
        Array.Copy(p1.statusback(), 0, statusall, 3, 3);
        Array.Copy(p2.statusback(), 0, statusall, 6, 3);

        return (statusall);
    }

    public bool kinsoku(bool[] pattern)
    {
        bool[] status = statusback();
        for (int i = 0; i < 9; i++)//0から9までの要素
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




}
