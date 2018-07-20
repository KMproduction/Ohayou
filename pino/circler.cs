using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class circler : MonoBehaviour
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
    public float setkakudo ;

    public float circlex;
    public float circlez;
    public float _x;
    public float _y;
    public float _z;
    public GameObject center;
    public GameObject scriptbox;
    public float chijikutilt = 23.4f;
    public int flag = 1;


    void Update()
    {
        new_timekeeper d3 = scriptbox.GetComponent<new_timekeeper>();
       // Debug.Log("duration=" + d3.duration_fixed);
        //Debug.Log("risekakudoになるはず=" + d3.duration_fixed / 24 * 360);


        Kakudosetter();
        line = center.GetComponent<LineRenderer>();
        
        line.SetVertexCount(segments + 1);//segments +1 だったがゴミが付くのでやめ
        
        line.useWorldSpace = false;
        CreatePoints();
        
    }

    void CreatePoints()
    {


        float y;

        float angle = risekakudo;

        for (int i = 0; i < (segments +1); i++)
        {
            new_timekeeper d3 = scriptbox.GetComponent<new_timekeeper>();

            circlex = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            circlez = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            _x = circlex;
            _z = circlez;
            //            if(angle>risekakudo)
            line.SetPosition(i, new Vector3(_x,_y, _z) );

            //常時表示モード flag = 0
            if (flag == 0)
            {
                angle += ((setkakudo - risekakudo) / segments);
            }
            //順次表示モード flag = 1
            else if(flag == 1) {
                if (d3.duration_fixed / 24 * 360 < setkakudo && d3.duration_fixed / 24 * 360>risekakudo)
                {
                    angle += (((d3.duration_fixed / 24 * 360) - risekakudo) / segments);
                }else
                {
        //            line.SetVertexCount(0);
                }
            }
            //非表示モード flag = 2
            else {
      //          line.SetVertexCount(0);
            }

            
        }
    }

    public void Kakudosetter()
    {
        sunrise d1 = scriptbox.GetComponent<sunrise>();
        setkakudo = (d1.settime_time/86400)*360;
        risekakudo = (d1.risetime_time / 86400) * 360;
    }

    public void ValueChanged(int result)
    {
        flag = result;
    }

}