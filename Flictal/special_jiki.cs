using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityStandardAssets.ImageEffects;

public class special_jiki : MonoBehaviour {
    public GameObject parti0;
    public GameObject parti1;
    public GameObject parti2;
    public GameObject parti3;
    public GameObject parti4;
    public GameObject Rainbow;
    public Camera Mcamera;
    string json;
    // Use this for initialization
    void Start () {
        //jsonの初回ロード
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        savedata sv = new savedata();
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        //sv._jiki = 16;
        switch (sv._jiki)
        {
            case 16:
                Debug.Log("いいぞー");
                Mcamera. GetComponent<SepiaTone>().enabled = true;
                break;
            case 17:
                parti0.SetActive(true);
                parti1.SetActive(true);
                parti2.SetActive(true);
                parti3.SetActive(true);
                parti4.SetActive(true);
                break;
            case 18:
                Mcamera.GetComponent<MotionBlur>().enabled = true;
                break;
            case 19:
                Mcamera.GetComponent<Twirl>().enabled = true;
                break;
            case 32:
                Rainbow.SetActive(true);
                break;
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
