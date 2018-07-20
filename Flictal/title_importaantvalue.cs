    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using MiniJSON;

public class title_importaantvalue : MonoBehaviour
{
    savedata sv = new savedata();
    public bool soundflag;
    public int jikino;
    int kaisuu;
    string json;
    public GameObject backsankaku;
    public GameObject scriptbox;
    public Text hidari;
    public Text migi;
    public Text center;
    public Material jikimat;
    public Sprite jikispr;
    public bool matFound;
    public GameObject explanation;

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/data.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
            json = encryption.DecryptString(json);
        }
        else
        {
#if UNITY_EDITOR
            json = File.ReadAllText(Application.streamingAssetsPath + "/data_model.json");//読み取ってるよ
#elif UNITY_ANDROID
        WWW reader = new WWW(Application.streamingAssetsPath + "/data_model.json");
        while (!reader.isDone){
        }
        json = reader.text;
#endif
            Debug.Log("初回!");
            explanation.SetActive(true);
        }


        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ

        sv._yobi5++;
        hidari.text = sv._name;
        migi.text = sv._yobi1.ToString();//一瞬変えてる
        json = JsonUtility.ToJson(sv);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった

        if (jikimat = Resources.Load<Material>("Materials/no" + sv._jiki))
        {
            backsankaku.GetComponent<SpriteRenderer>().material = jikimat;
            Debug.Log(sv._jiki + "じゃん");
            matFound = true;
        }
        else
        {
            jikispr = Resources.Load<Sprite>("Materials/no" + sv._jiki);
            backsankaku.GetComponent<SpriteRenderer>().sprite = jikispr;
            Debug.Log("ないじゃｎ");
        }
//        backsankaku.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Materials/no" + sv._jiki);
        Title_SE se = scriptbox.GetComponent<Title_SE>();//スコアを取得 
        se.SEswitch(sv._sound);
        se.BGMswitch(sv._BGM);
    }
    void Update()
    {
        //       Debug.Log("キーボードは"+TouchScreenKeyboard.visible);
    }
}
