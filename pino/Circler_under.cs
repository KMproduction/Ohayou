
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


[RequireComponent(typeof(LineRenderer))]
public class Circler_under : MonoBehaviour
{

    //なんかこの位置じゃないと切れはしが残ってダメ
    [Range(0, 50)]
    public int segments = 20;
    [Range(0, 1000)]
    public float xradius = 50;
    [Range(0, 1000)]
    public float yradius = 50;
    LineRenderer line;
    [Range(0, 360)]
    public float risekakudo;
    [Range(0, 360)]
    public float setkakudo;

    public float circlex;
    public float circlez;
    public float _x;
    public float _y;
    public float _z;
    public GameObject center;
    public GameObject scriptbox;
    public float chijikutilt = 23.4f;

    public int flag;
    public bool existflag;//日没時でも太陽を表示するフラグ
    public GameObject minisunA;
    //バグ、risekakudoto


    void Update()
    {
        new_timekeeper d3 = scriptbox.GetComponent<new_timekeeper>();
        //Debug.Log("duration="+d3.duration_fixed);
        //Debug.Log("risekakudoになるはず=" + d3.duration_fixed/24 * 360);

        Kakudosetter();

        //太陽の登場と消滅について
        if (d3.duration_fixed / 24 * 360 +5 <= risekakudo || d3.duration_fixed / 24 * 360 -5 >= setkakudo)//端数そろえ
        {
            if (existflag == false)
            {
                minisunA.SetActive(false);
            }
            else
            {
                minisunA.SetActive(true);
            }
        }else
        {
            minisunA.SetActive(true);
        }




        if ((d3.duration_fixed / 24 * 360 < risekakudo || d3.duration_fixed / 24 * 360 > setkakudo) && flag != 2)
        {
            if (existflag == true)
            {
                line = center.GetComponent<LineRenderer>();
                line.enabled = true;
                line.SetVertexCount(segments + 1);//segments +1 だったがゴミが付くのでやめ
                line.useWorldSpace = false;
                CreatePoints();

            }
            else
            {
                line = center.GetComponent<LineRenderer>();
                line.enabled=false;
            }
        }
        else
        {
            line = center.GetComponent<LineRenderer>();
            line.enabled=false;

        }

    }


    void CreatePoints()
    {
        float y;
        float angle = setkakudo;

        for (int i = 0; i < (segments + 1); i++)
        {

            circlex = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            circlez = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            _x = circlex;
            _z = circlez;
            //            if(angle>risekakudo)
            line.SetPosition(i, new Vector3(_x, _y, _z));

            angle += ((risekakudo+ 360 - setkakudo) / segments);
        }
    }

    public void Kakudosetter()
    {
        sunrise d1 = scriptbox.GetComponent<sunrise>();
        setkakudo = (d1.settime_time / 86400) * 360;
        risekakudo = (d1.risetime_time / 86400) * 360;
       // Debug.Log("risekakudo"+risekakudo);
    }

    public void ValueChanged(int result)
    {
        flag = result;
    }

    public void existflagChanged(bool result)
    {
        existflag = result;
    }

}