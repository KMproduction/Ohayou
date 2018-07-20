using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class csvload : MonoBehaviour
{

    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 12; // CSVの行数


    void Start()
    {
        csvFile = Resources.Load("CSV/akashi_data") as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算
        }
    }

    //通日　→　ずれ
    public float CSVuse(int tsuujitu)
    {
        float a;
        //Debug.Log(csvDatas[tsuujitu][11]);//[通日][11…秒]
        a = float.Parse(csvDatas[tsuujitu][11]);
        return a;
    }

    public float CSVsunrise(int tsuujitu)
    {
      
    float a;
        //Debug.Log(csvDatas[tsuujitu][11]);//[通日][11…秒]
        a = float.Parse(csvDatas[tsuujitu][3]);
        return a;

    }
    public float CSVsunset(int tsuujitu)
    {
        float a;
        //Debug.Log(csvDatas[tsuujitu][11]);//[通日][11…秒]
        a = float.Parse(csvDatas[tsuujitu][7]);
        return a;

    }

    public string CSVdebug(int tsuujitu,int info)
    {
        string a;
        //Debug.Log(csvDatas[tsuujitu][11]);//[通日][11…秒]
        a = csvDatas[tsuujitu][info];
        return a;

    }
}