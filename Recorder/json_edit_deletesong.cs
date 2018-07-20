using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

//値の読み込みに成功、やったぜ
public class json_edit_deletesong : MonoBehaviour
{
    public GameObject scriptbox;

    MusicScore ms = new MusicScore();
    public InputField songname_t;
    public GameObject type_toggle;
    public InputField difficulty_t;
    public InputField notes_t;
    int dd;
    int ll;
    string json;
    int j;

    public void songinfoset()
    {
        json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");// perから読むにはreadalltextしかない、wwwは無理…散々悩んだ
        Debug.Log(json);

        JsonUtility.FromJsonOverwrite(json, ms);
        MainScript d1 = scriptbox.GetComponent<MainScript>();

        for (j = 0; j < ms.songid.Count; j++)
        {
            if (ms.songid[j] == d1.SID)
            {

                songname_t.text = ms.songname[j];
                difficulty_t.text = ms.difficulty[j].ToString();
                notes_t.text = ms.notes[j].ToString();
                break;
            }
        }

//        songname_t.text = ms.songname[d1.SID];
//        difficulty_t.text = ms.difficulty[d1.SID].ToString();
 //       notes_t.text = ms.notes[d1.SID].ToString();
    }

    public void editsong()
    {
            json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");// perから読むにはreadalltextしかない、wwwは無理…散々悩んだ

        Debug.Log(json);

        JsonUtility.FromJsonOverwrite(json, ms);

        MainScript d1 = scriptbox.GetComponent<MainScript>();


        ms.songname[j]=(songname_t.text);   //曲名

        type_toggleswich d2 = type_toggle.GetComponent<type_toggleswich>();
        ms.type[j] = d2.type;

        Int32.TryParse(difficulty_t.text, out dd);//変換
        ms.difficulty[j]=(dd);                 //難易度
        Int32.TryParse(notes_t.text, out ll);   //変換
        ms.notes[j]=(ll);                  //ノーツ数
        json = JsonUtility.ToJson(ms);
        Debug.Log(json);



        File.WriteAllText(Application.persistentDataPath + "/songslist.json", json);//結局これでよかった


    }
}