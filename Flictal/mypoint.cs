using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class mypoint : MonoBehaviour {
    savedata sv = new savedata();
    string json;
    public Text point;
    public GameObject mawasu;
    public GameObject mawasenai;
    public GameObject re_mawasu;
    

    // Use this for initialization
    void Start () {
        Load();
	}
	
	// Update is called once per frame
	public void Load () {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        point.text = sv._yobi1.ToString();
//        json = encryption.EncryptString(json);
//        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった  
        canGasha(sv._yobi1);

        }
    public void PointUsed()
    {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        sv._yobi1-=250;

        canGasha(sv._yobi1);
        json = JsonUtility.ToJson(sv);
        Debug.Log(json);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった  

        canGasha(sv._yobi1);
    }


    public bool canGasha(int pt)
    {
        if (pt < 250)
        {
            mawasu.SetActive(false);
            mawasenai.SetActive(true);
            re_mawasu.SetActive(false);
            return false;
        }
        else
        {
            mawasu.SetActive(true);
            mawasenai.SetActive(false);
            re_mawasu.SetActive(true);
            return true;
        }

    }
}
