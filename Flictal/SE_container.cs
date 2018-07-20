using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SE_container : MonoBehaviour {
    string json;
    savedata sv = new savedata();
    public GameObject BGMplace;
    public AudioClip atari;
    public AudioClip hazure;
    public AudioClip levelup;
    public AudioClip Fivecombo;
        public AudioClip Tencombo;
    public AudioClip timeup;
    public AudioClip buttonSE;
    public AudioClip danger;
    public AudioClip shrink3;
    public AudioClip shrink2;
    public AudioClip shrink1;
    public AudioClip clear;
    public AudioClip EScape;
    public AudioClip jiki_explosion;
    public AudioClip jiki_explosion2;
    public AudioClip jiki_sexy;
    public AudioClip congratulations;
    // Use this for initialization
    void Start () {
        //    DontDestroyOnLoad(this);
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        switch (sv._jiki)
        {
            case 9:
                atari = jiki_sexy;
                break;
            case 30:
                atari = jiki_explosion;
                break;
            case 31:
                atari = jiki_explosion2;
                break;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void buttonclicked()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonSE);//効果音を鳴らす
        
    }

    public void DestroyReady()
    {
        //DelayMethodを3.5秒後に呼び出す
        Invoke("DelayMethod", 1.5f);
    }


    void DelayMethod()
    {
       GameObject.Destroy(this);
    }




    public void SEswitch(bool value)
    {
        GetComponent<AudioSource>().enabled = value;
        Debug.Log("ＳＥは" + value);
    }
    public void BGMswitch(bool value)
    {
        BGMplace.GetComponent<AudioSource>().enabled = value;
        Debug.Log("BGMは" + value);
    }


}
