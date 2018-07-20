using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

//値の読み込みに成功、やったぜ
public class Json_deletesong : MonoBehaviour
{
    MusicScore ms = new MusicScore();
    MusicResult mr = new MusicResult();
    public GameObject scriptbox;

    public GameObject Oya;
    string json;

    public void deletesong()
    {

        json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");
        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json, ms);

        int length = ms.songid.Count;//現在の長さ
                                      
       //////////////////////////////まず、idが配列の何番目にあるか検索する

        MainScript d1 = scriptbox.GetComponent<MainScript>();

        int delete_content = ms.songid.IndexOf(d1.SID);//消したい場所が〇番目かを検索


        //////////////////////////////その番目の配列を削除する

        Debug.Log(delete_content);
        
        ms.songid.RemoveAt(delete_content);                              //_listの三番目の要素を削除
     
       ms.gameid.RemoveAt(delete_content);                              //_listの三番目の要素を削除
       ms.songname.RemoveAt(delete_content);                              //_listの三番目の要素を削除
        
        ms.type.RemoveAt(delete_content);                              //_listの三番目の要素を削除
        ms.difficulty.RemoveAt(delete_content);                              //_listの三番目の要素を削除
        ms.notes.RemoveAt(delete_content);                              //_listの三番目の要素を削除
        
        //ms.value1.RemoveAt(delete_content);                              //_listの三番目の要素を削除
        //ms.value2.RemoveAt(delete_content);                              //_listの三番目の要素を削除
        

        ///////////////////////////////////////////////書き込み
        json = JsonUtility.ToJson(ms);
        Debug.Log(json);

        File.WriteAllText(Application.persistentDataPath + "/songslist.json", json);


//消した曲に関する記録結果を全削除する
        json = File.ReadAllText(Application.persistentDataPath + "/resultlist.json");
        JsonUtility.FromJsonOverwrite(json, mr);
        Debug.Log(json);

        for (int j = 0; j < mr.songid.Count; j++)
        {
            if (mr.songid[j] == d1.SID)
            {
                mr.songid.RemoveAt(j);
                mr.gameid.RemoveAt(j);
                mr.score.RemoveAt(j);
                mr.perfect.RemoveAt(j);
                mr.great.RemoveAt(j);
                mr.good.RemoveAt(j);
                mr.FS.RemoveAt(j);
                mr.miss.RemoveAt(j);
                mr.maxcombo.RemoveAt(j);
                mr.FC.RemoveAt(j);
                mr.clear.RemoveAt(j);
                //mr.etc.RemoveAt(j);
                j--;//多分これいるっしょ！
            }
        }

        json = JsonUtility.ToJson(mr);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/resultlist.json", json);



        //最後に…選曲画面の一番最後の四角を非可視にする
        //          GameObject unshowingcontent = GameObject.Find("Main Camera") ;
        //iranaihako.SetActive(false);
        //        GameObject unshowingcontent = Oya.transform.Find("SongPrefab (0)").gameObject; //まずSongprefab(i)を捕獲※activeでないので親から辿る必要あり

        //   unshowingcontent.SetActive(false);

    }
}