using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TH_position : MonoBehaviour
{
    public int position;
    public float height;
    public GameObject TH;
    public GameObject THcheck;
    Vector3 center = new Vector3(0, 0, 0);//太陽の南中角度 x=0
    Vector3 north = new Vector3(10, 0.8f, 0.5f);//太陽の南中角度 x=0
    Vector3 east = new Vector3(10.4f, 0.8f, 0);//太陽の南中角度 x=0
    Vector3 south = new Vector3(10, 0.8f, -0.4f);//太陽の南中角度 x=0
    Vector3 west = new Vector3(9.6f, 0.8f, 0);//太陽の南中角度 x=0
    public Text t_direction;
    public Text t_height;
    public bool fix;


    // Use this for initialization
    void Start()
    {
        t_direction.text = ("透明半球位置：正面");
        height = 0.8f;
        position = 4;
    }

    public void PosChange(int pos)
    {
        position = pos;
        Debug.Log("position=" + position);
    }

    public void hankyufix(bool fix_or_not)
    {
        fix = fix_or_not;
    }

    public void heightChange(float value)
    {
        height = value;

        //    Debug.Log("position=" + position);
    }

    // Update is called once per frame
    void Update()
    {
        t_height.text = ("高度:" + height.ToString("f2"));
        if (THcheck.activeSelf==(false))
        {
            t_direction.text = ("透明半球　　　非表示");
        }
        else if (fix == true)
        {
            TH.transform.localPosition = center;
            t_direction.text = ("透明半球の位置：正面");
        }
        else
        {
            switch (position)
            {
                case 0://同じ
                    break;
                case 1://north
                    TH.transform.position = north;
                    TH.transform.position = new Vector3(10, height, 0.5f);
                    t_direction.text = ("透明半球の位置：北");
                    break;
                case 2://east
                    TH.transform.position = new Vector3(10.4f, height, 0); ;
                    t_direction.text = ("透明半球の位置：東");
                    break;
                case 3:
                    TH.transform.position = new Vector3(10, height, -0.4f); ;
                    t_direction.text = ("透明半球の位置：南");
                    break;
                case 4:
                    TH.transform.position = new Vector3(9.6f, height, 0); ;
                    t_direction.text = ("透明半球の位置：西");
                    break;
            }
        }
    }
}
