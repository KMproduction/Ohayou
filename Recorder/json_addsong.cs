using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

//値の読み込みに成功、やったぜ
public class json_addsong : MonoBehaviour
{
    MusicScore ms = new MusicScore();
    public Text songname_t;
    public GameObject type_toggle;
    public Text difficulty_t;
    public Text notes_t;
    int dd;
    int ll;
    string json;
    int sid;

    public void addsong()
    {
        if (File.Exists(Application.persistentDataPath + "/songslist.json") )
            json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");// perから読むにはreadalltextしかない、wwwは無理…散々悩んだ
        else
        {
#if UNITY_EDITOR
            json = File.ReadAllText(Application.streamingAssetsPath + "/songslist_model.json");//読み取ってるよ
#elif UNITY_ANDROID
            WWW reader = new WWW(Application.streamingAssetsPath + "/songslist_model.json");
          while (!reader.isDone){
            }
           json = reader.text;
#endif

        }
        Debug.Log(json);

        JsonUtility.FromJsonOverwrite(json, ms);
        int length = ms.songid.Count;//現在の長さ
                                      //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                      //songID求めるよ
        int i;
        for (i = 0; (i < length); i++){
            //普通は曲idは埋まっているはず即ち indexof()=(正の数)
            
            //でももし空きidがあればそこでstop
            if (ms.songid.IndexOf(i) == -1)
                break;
        }
        //「i」…空きがあるか検索する曲id
        //iが長さに達するか、ms.songidのなかに「i」が存在するかまでiを上げていく
        //一行ずつ足していくよ
       
        if ((ms.songid.IndexOf(sid) != -1))//検索中idが今まで全部見つかっているとき=明菜氏(i==lengthのときこっちに来る)
        {
            Debug.Log("曲id「" + i + "」空きあるのでそう命名します");
        }
        else//idが見つかった時
        {

            Debug.Log(i + "未満の曲id埋まってたので新曲id「" + i + "」を追加します!");
            Debug.Log(i + "ぬるぽっぽ");
        }
        sid = i;
        //最後の行に色々足していくよ


        ms.songid.Add( sid);//
        ms.gameid.Add( 0);//ミリシタ
        ms.songname.Add (songname_t.text);   //曲名

        type_toggleswich d1 = type_toggle.GetComponent<type_toggleswich>();
        ms.type.Add ( d1.type);//なんかのアレ

        Int32.TryParse(difficulty_t.text, out dd);//変換
        ms.difficulty.Add( dd);                 //難易度
        Int32.TryParse(notes_t.text, out ll);   //変換
        ms.notes.Add(  ll);                  //ノーツ数
        json = JsonUtility.ToJson(ms);
        Debug.Log(json);



            File.WriteAllText(Application.persistentDataPath + "/songslist.json", json);//結局これでよかった
        /*
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/songslist.json"))
        {
            writer.Write(json.ToString());
            writer.Close();
        }
        */
        /*
        FileStream stream = File.Create(Application.persistentDataPath + "/songslist.json");
        byte[] contentBytes = new UTF8Encoding(true).GetBytes(json);
        stream.Write(contentBytes, 0, contentBytes.Length);
        stream.Close();
        */
    }
    }