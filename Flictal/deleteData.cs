using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MiniJSON;

public class deleteData : MonoBehaviour
{
    public GameObject scriptbox;
    public GameObject darkmask;
    public GameObject deletemenu;
    public GameObject deletemenu2;
    public GameObject menu;
    public GameObject setting;
   // public GameObject jiki;
    public bool deleteflag;
    savedata sv = new savedata();
    string json;


    // Use this for initialization
    public void deletepushed()
    {
        deletemenu.SetActive(true);
        darkmask.SetActive(true);
        deleteflag = true;
        setting.SetActive(false);
    }

    public void delete_check()
    {
        deletemenu.SetActive(false);
        deletemenu2.SetActive(true);
       
    }

    public void deletecancel()
    {
        deletemenu.SetActive(false);
        deletemenu2.SetActive(false);
        darkmask.SetActive(false);
        setting.SetActive(true);
        deleteflag = false;
    }

    public void ALLDELETE()
    {
       // encryption ec = scriptbox.GetComponent<encryption>();
#if UNITY_EDITOR
        json = File.ReadAllText(Application.streamingAssetsPath + "/data_model.json");//読み取ってるよ
#elif UNITY_ANDROID
        WWW reader = new WWW(Application.streamingAssetsPath + "/data_model.json");
        while (!reader.isDone){
        }
        json = reader.text;
#endif
        Debug.Log("データ全削除");
//        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
//        json = Json.Serialize(sv);
        json = encryption.EncryptString(json);
        jiki_setter js = scriptbox.GetComponent<jiki_setter>();//スコアを取得   
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//最初のデータを代入
        deleteflag = false;
        deletemenu2.SetActive(false);
        menu.SetActive(true);
        darkmask.SetActive(false);
        title_importaantvalue iv = scriptbox.GetComponent<title_importaantvalue>();//スコアを取得
        iv.Start();
        scenemover sm = scriptbox.GetComponent<scenemover>();//スコアを取得
        sm.homeButtonpushed();  
    }
}
