using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class unlock : MonoBehaviour
{
    public string json;
    public GameObject scriptbox;
    savedata sv = new savedata();
    public static int getflag=0;
    // Use this for initialization
    public void rainbow()
    {
        {
            json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
            json = encryption.DecryptString(json);
            JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
            bool have = true;
            for (int i = 0; i < 32; i++)
            {
                if (sv._jikiflag[i] == false)
                {
                    have = false;
                    break;
                }
            }

            if (have == true)
            {
                sv._jikiflag[32] = true;
                json = JsonUtility.ToJson(sv);
                Debug.Log(json);
                json = encryption.EncryptString(json);
                File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった  
            }   
        }

    }
    public void triunlock(int level)
    {
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        switch (level)
        {
            case 50:
                json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
                json = encryption.DecryptString(json);
                JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
                if (sv._jikiflag[16] == false)
                {
                    GetComponent<AudioSource>().PlayOneShot(se.congratulations);
                    sv._jikiflag[16] = true;
                    //getflag = 19;
                    json = JsonUtility.ToJson(sv);
                    Debug.Log(json);
                    json = encryption.EncryptString(json);
                    File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった     
                    //rainbow();
                }
                break;
            case 100:
                json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
                json = encryption.DecryptString(json);
                JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
                if (sv._jikiflag[17] == false)
                {
                    GetComponent<AudioSource>().PlayOneShot(se.congratulations);
                    sv._jikiflag[17] = true;
                    //getflag = 19;

                    json = JsonUtility.ToJson(sv);
                    Debug.Log(json);
                    json = encryption.EncryptString(json);
                    File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった     
                    //rainbow();
                }
                break;
            case 125:
                json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
                json = encryption.DecryptString(json);
                JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
                if (sv._jikiflag[18] == false)
                {
                    GetComponent<AudioSource>().PlayOneShot(se.congratulations);
                    sv._jikiflag[18] = true;
                    //getflag = 19;

                    json = JsonUtility.ToJson(sv);
                    Debug.Log(json);
                    json = encryption.EncryptString(json);
                    File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった     
                   // rainbow();
                }
                break;
            case 150:
                json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
                json = encryption.DecryptString(json);
                JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
                if (sv._jikiflag[19] == false)
                {
                    GetComponent<AudioSource>().PlayOneShot(se.congratulations);
                    sv._jikiflag[19] = true;
                    //getflag = 19;

                    json = JsonUtility.ToJson(sv);
                    Debug.Log(json);
                    json = encryption.EncryptString(json);
                    File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった     
                    rainbow();
                }
                break;


        }

    }
}
           

