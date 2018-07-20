using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

//値の読み込みに成功、やったぜ
public class json_addresult : MonoBehaviour
{
    public GameObject scriptbox;//曲id拾うためだけのアレ、中にグローバル変数として曲idがある
    MusicResult res = new MusicResult();
    public InputField score_t;
    public InputField perfect_t;
    public InputField great_t;
    public InputField good_t;
    public InputField FS_t;
    public InputField miss_t;
    public InputField maxcombo_t;
    public Toggle FC_toggle;
    public Toggle clear_toggle;
    //public InputField etc_t;
    int sc;
    int aa;
    int bb;
    int cc;
    int dd;
    int ee;
    int ff;
    int mc;
    string json;


    public void addresult()
    {
///////////////////////////////////////////jsonファイルの読み込み
        if (File.Exists(Application.persistentDataPath + "/resultlist.json"))
        {
            json = File.ReadAllText(Application.persistentDataPath + "/resultlist.json");//読み取ってるよ
        }
        else {
#if UNITY_EDITOR
            json = File.ReadAllText(Application.streamingAssetsPath + "/resultlist_model.json");//読み取ってるよ
#elif UNITY_ANDROID
        WWW reader = new WWW(Application.streamingAssetsPath + "/resultlist_model.json");
        while (!reader.isDone){
        }
        json = reader.text;
#endif
            Debug.Log("初回!");
        }
        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json, res);

//////////////////////////////////////jsonファイルの延長
        
        //////////////////////////////////////jsonファイルの最後尾に情報追加していくよ

        MainScript d1 = scriptbox.GetComponent<MainScript>();

        res.songid.Add( d1.SID);//★★idはメインスクリプトから拾うことだけ特殊
        
        res.gameid.Add( 0);//ミリシタ

        Int32.TryParse(score_t.text, out sc);//変換
        res.score.Add( sc);                 //難易度

        Int32.TryParse(perfect_t.text, out aa);//変換
        res.perfect.Add(  aa);
        Int32.TryParse(great_t.text, out bb);//変換
        res.great.Add( bb);
        Int32.TryParse(good_t.text, out cc);//変換
        res.good.Add( cc);
        Int32.TryParse(FS_t.text, out dd);//変換
        res.FS.Add(dd);
        Int32.TryParse(miss_t.text, out ee);//変換
        res.miss.Add( ee);
        Int32.TryParse(maxcombo_t.text, out mc);//変換
        res.maxcombo.Add(mc);

        res.FC.Add(FC_toggle.isOn);//なんかのアレ

        res.clear.Add( clear_toggle.isOn);//なんかのアレ

   //     res.etc.Add(clear_toggle.isOn);//なんかのアレ

                                         //  res.etc[length] = etc_t.text;   //備考

        json = JsonUtility.ToJson(res);
        Debug.Log(json);
        //File.WriteAllText(Application.persistentDataPath + "/resultlist.json", json);
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/resultlist.json"))
        {
            writer.Write(json.ToString());
            writer.Close();
        }
    }

}