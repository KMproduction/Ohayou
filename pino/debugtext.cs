using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugtext : MonoBehaviour
{

    private Text targetText;
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 12; // CSVの行数


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        GameObject sunpos = GameObject.Find("ScriptBox");
        SunPosition script = sunpos.GetComponent<SunPosition>();
        csvload d1 = sunpos.GetComponent<csvload>();


        this.targetText = this.GetComponent<Text>();
        //this.targetText.text = "数値1="+script.xx +"数値2="+script.yy ;
        this.targetText.text = "通日=" + script.xx + "\n視赤緯=" + -script.theta +"\n現在地緯度=35\n経度=135\n南中高度=" + (-script.theta + 55)
            +"\n日の出時刻="+d1.CSVdebug((int)script.xx,2) +"\n日没時刻=" + d1.CSVdebug((int)script.xx, 6)
            + "\n南中時刻=" + d1.CSVdebug((int)script.xx, 4);

    }
}
