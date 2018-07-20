using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections.Generic;

public class resultcalc : MonoBehaviour
{
    string str;
    public GameObject scriptbox;
    public InputField perfect;
    public InputField great;
    public InputField good;
    public InputField FS;
    public InputField miss;
    public InputField combo;
    public Text Title_text;
    public Toggle FC;

    //スコアリセット(0,できれば空白)
    //maxcomboリセット
    //フルコンボリセット
    //クリア判定リセットetc
    int per;
    int gre;
    int goo;
    int fas;
    int mis;
    public int notes;
    MusicScore ms = new MusicScore();

    // 起動時はAPにしておけ
    public void Set()//最初、jsonロードしてフルコンコンボ数をセットする
    {
        MainScript d1 = scriptbox.GetComponent<MainScript>();
        string json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");
        JsonUtility.FromJsonOverwrite(json, ms);
        int sid = ms.songid.IndexOf(d1.SID);

        notes = ms.notes[sid];
        perfect.text = notes.ToString();
        great.text = "0";
        good.text = "0";
        FS.text = "0";
        miss.text = "0";

        Title_text.text = ms.songname[sid];
    }

    public void Always()//常にやる事、100コンボに収める
    {
        per = int.Parse(perfect.text);
        gre = int.Parse(great.text);
        goo = int.Parse(good.text);
        fas = int.Parse(FS.text);
        mis = int.Parse(miss.text);
        //フルコン数を超えない
        if (per > notes)
            per = notes;
        if (gre > notes)
            gre = notes;
        if (goo > notes)
            goo = notes;
        if (fas > notes)
            fas = notes;
        if (mis > notes)
            mis = notes;
        //負の数にならない
        if (per < 0)
            per = 0;
        if (gre < 0)
            gre = 0;
        if (goo < 0)
            goo = 0;
        if (fas < 0)
            fas = 0;
        if (mis < 0)
            mis = 0;
        //5判定の和が　総ノーツ数を超えたらperfectを削る
        if (per + gre + goo + fas + mis > notes)
            per = notes -(gre + goo + fas + mis);
        //もう一度、perfectを0以上に
        if (per < 0)
            per = 0;

        perfect.text = per.ToString();
        great.text = gre.ToString();
        good.text = goo.ToString();
        FS.text = fas.ToString();
        miss.text = mis.ToString();
 
//フルコンしてるか判定　miki

        if (mis == 0 && fas == 0)
        {
           FC.isOn=true;
        }
        else
        {
            FC.isOn = false;
        }

        
    }

    //フルコンしたら失敗判定は0に

    
    public void FullCombo()
    {
        if(FC==true)
        combo.text = notes.ToString();
    }
    

}
