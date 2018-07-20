using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class debug : MonoBehaviour {
    string json;

	// Update is called once per frame
	public void Debug () {
        savedata sv = new savedata();
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ

        for (int i = 0; i < 31; i++)
        {
            sv._jikiflag[i] = true;
            //getflag = 19;                
        }
        json = JsonUtility.ToJson(sv);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった 
    }

    public void Debugkane()
    {
        savedata sv = new savedata();
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ

        sv._yobi1 += 100000;

        json = JsonUtility.ToJson(sv);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった 
    }

}
