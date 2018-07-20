using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class gasha : MonoBehaviour
{
    public GameObject scriptbox;
    jikidata_json jd = new jikidata_json();
    int sum;
    int rand;
    int num;
    savedata sv = new savedata();
    string json;
    private void Start()//キーボードテスト
    {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        Gasha_SE se = scriptbox.GetComponent<Gasha_SE>();//スコアを取得 
       
        se.SEswitch(sv._sound);
        se.BGMswitch(sv._BGM);

    }
    // Use this for initialization
    public void DoGasha()
    {
        sum = 0;
        //        jikidata_json jd = GetComponent<jikidata_json>();
        for (int i = 0; i < jd.rarelity.Length; i++)
        {
            sum = sum + jd.rarelity[i];
        }
        Debug.Log("sum=" + sum);
        rand = Random.Range(0, sum);
        Debug.Log("rand=" + rand);
        num = 0;

        int j = jd.rarelity[0];
        //ちなみに最初の登場確率はゼロ
        while (j <= sum)
        {
            if (rand < j)
            {
                Debug.Log(num + "が当選");
                enshutu d1 = scriptbox.GetComponent<enshutu>();
                d1.ReadytoGasha(num);
                break;
            }
            Debug.Log(rand + "は" + num + "の該当番号である" + j + "より大きい");
            num++;

            j = j + jd.rarelity[num];

        }
        //358
        Debug.Log(num);
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        if (sv._jikiflag[num] == false)
        {
            sv._jikiflag[num] = true;

            json = JsonUtility.ToJson(sv);
            Debug.Log(json);
            json = encryption.EncryptString(json);
            File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった  
            unlock ul = scriptbox.GetComponent<unlock>();
            ul.rainbow();
        }
        mypoint mp = scriptbox.GetComponent<mypoint>();
        mp.PointUsed();

    }

}
