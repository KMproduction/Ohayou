using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Title_SE : MonoBehaviour {
    public AudioClip buttonSE;
    public AudioClip backSE;
    public AudioClip gamestart;
    public AudioClip trisound;
    public AudioClip explosion;
    public AudioClip explosion2;
    public AudioClip sexy;
    public AudioClip flick;
    public bool strangesound;
    string json;
    public Toggle SEtoggle;
    public Toggle BGMtoggle; 
    savedata sv = new savedata();
    public GameObject BGMplace;
    // Use this for initialization
    void Start () {
     //   DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void buttonclicked()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonSE);//効果音を鳴らす
    }
    public void startbuttonclicked()
    {
        GetComponent<AudioSource>().PlayOneShot(gamestart);//効果音を鳴らす
    }


    public void TriSelected(int num)//num には選択した三角No.が入る
    {
        //三角によって変える
        int selectnum = num;
        selectnum = 0;
        strangesound = false;
        switch (num)
        {
            case 9:
                strangesound = true;
                GetComponent<AudioSource>().PlayOneShot(sexy);//効果音を鳴らす
               
                break;
            case 30:
                strangesound = true;
                GetComponent<AudioSource>().PlayOneShot(explosion);
               
                break;
            case 31:
                strangesound = true;
                GetComponent<AudioSource>().PlayOneShot(explosion2);
               
                break;
        }
        if(strangesound==false)
        GetComponent<AudioSource>().PlayOneShot(trisound);//効果音を鳴らす

    }

    public void SEChange(bool value)
    {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        sv._sound = value;
        json = JsonUtility.ToJson(sv);
        Debug.Log(json);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった

        SEswitch(value);

    }

    public void SEswitch(bool value)
    {
        GetComponent<AudioSource>().enabled = value;
        Debug.Log("ＳＥは" +value);
        SEtoggle.isOn = value;

    }

    public void BGMChange(bool value)
    {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        sv._BGM = value;
        json = JsonUtility.ToJson(sv);
        Debug.Log(json);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった

        BGMswitch(value);

    }

    public void BGMswitch(bool value)
    {
        BGMplace.GetComponent<AudioSource>().enabled = value;
        Debug.Log("BGMは" + value);
        BGMtoggle.isOn = value;
        
    }

    //音量のonoffはinportantvalueからどうぞ

}
