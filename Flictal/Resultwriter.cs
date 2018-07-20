using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Resultwriter : MonoBehaviour {
    public int firstdeadlevel;
    string json;
    savedata sv = new savedata();
    // Use this for initialization
    public void addresult (int score,int maxcombo,float lefttime) {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        Debug.Log("おーい"+score+","+sv._bestscore[0]);
        for (int i = 0; i < 10; i++)//ほんとは一位いがいもやりたい…
        {
            if (sv._bestscore[0] < score)
            {
                sv._bestscore[0] = score;
                sv._bestscore[1] = sv._jiki;//コンボ数
                Debug.Log("記録更新");
            }
        }

        sv._yobi1 = sv._yobi1 + (score / 10);

        json = JsonUtility.ToJson(sv);
        Debug.Log(json);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった     
       

    }

    public void sv_addresult(int level)
    {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        Debug.Log("おーい" + level + "," + sv._bestscore[0]);
        for (int i = 0; i < 10; i++)//ほんとは一位いがいもやりたい…
        {
            if (sv._sv_level[0] < level)
            {
                sv._sv_level[0] = level;
                sv._sv_level[1] = sv._jiki;
                Debug.Log("記録更新");
            }
        }
       sv._yobi1 = sv._yobi1 + ((level-firstdeadlevel) * 30);//スコア確保(2回目に得られるスコアはちゃんと低い)
        level = firstdeadlevel;//一回目の死亡時、どこで死んだか覚えておく
        json = JsonUtility.ToJson(sv);
        Debug.Log(json);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった     


    }


    // Update is called once per frame
    void Update () {
		
	}
}
