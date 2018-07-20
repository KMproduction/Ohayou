using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


//v注意、d1.SID と　isdが存在している
public class recordreminder : MonoBehaviour {

    public GameObject scriptbox;
    public Text songname;

    public Text t_playkaisuu;
    public Text t_clearkaisuu;
    public Text t_FCkaisuu;
    public Text t_avescore;
    public Text t_aveclear;
    public Text t_aveFC;
    public Text t_aveperfect;
    public Text t_highscore;
    public Text t_bestperfect;
    public Text t_FCline;
    public Text t_clearline;
    public Text t_twe_clearkaisuu;
    public Text t_twe_FCkaisuu;
    public Text t_twe_avescore;
    public Text t_twe_aveperfect;
        
    MusicScore ms = new MusicScore();
    MusicResult mr = new MusicResult();
    MusicResult mrx = new MusicResult();

    // Update is called once per frame
    public void Remind () {

    int playkaisuu=0;
    int clearkaisuu=0;
    int FCkaisuu=0;
        long perfectsum = 0;
        long scoresum = 0;
        int highscore = 0;
        int bestperfect = 0;
        int FCline = 0;
        int FCl = 0;
        int clearline = 0;
        int clearl = 0;

        long perfectsum_twe = 0;
        int FCkaisuu_twe = 0;
        int clearkaisuu_twe = 0;
        long scoresum_twe = 0;

    Debug.Log("おはよう");

    // まず、曲リストから楽曲番号を貰ってくる
        MainScript d1 = scriptbox.GetComponent<MainScript>();
        string json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");
        JsonUtility.FromJsonOverwrite(json, ms);
        int sid = ms.songid.IndexOf(d1.SID);//←誤表記、ここが原因でバグった
        //int sid = d1.SID;
        songname.text =ms.songname[sid];
   //次に、結果リストを引っ張ってきて色々やる
        MainScript d2 = scriptbox.GetComponent<MainScript>();
        json = File.ReadAllText(Application.persistentDataPath + "/resultlist.json");
        JsonUtility.FromJsonOverwrite(json, mr);
     var ml = new List<MusicListDX>(); //データ一回避難させた方がいいんじゃね？と思ったがどうなんだろう…
        int j = 0;
//        Debug.Log(sid);
        //for (int i = 0; i < mr.songid.Count; i++)
        for (int i = mr.songid.Count-1; i >=0; i--)
        {
            
            if (/*mr.songid.Contains(sid) && */ mr.songid[i]==d1.SID&& mr.gameid[i]==0)  //選択している曲番号に一致した結果であれば
            {
                
                playkaisuu++;
                perfectsum += mr.perfect[i];
                scoresum += mr.score[i];
                //クリア
                if (mr.clear[i])
                {
                    clearkaisuu++;
                    clearl++;
                    if (clearline < clearl)
                        clearline = clearl;
                }else
                {
                    clearl = 0;
                }


                //フルコン
                if (mr.FC[i])
                {
                    FCkaisuu++;
                    FCl++;
                    if (FCline < FCl)
                        FCline = FCl;
                }else
                {
                    FCl = 0;
                }

                if (mr.score[i] > highscore)
                    highscore = mr.score[i];

                if (mr.perfect[i] > bestperfect)
                    bestperfect = mr.perfect[i];

                //20回以内は特殊判定,jが暗躍、j=20で終了
                if (j < 20)
                {
                    perfectsum_twe = perfectsum;
                    scoresum_twe = scoresum;
                    FCkaisuu_twe = FCkaisuu;
                    clearkaisuu_twe = clearkaisuu;
                    j++;
                }
                
            }
        }


       // if (playkaisuu != 0)
       // {
            t_playkaisuu.text = playkaisuu.ToString();
            t_clearkaisuu.text = clearkaisuu.ToString();
            t_FCkaisuu.text = FCkaisuu.ToString();
            t_avescore.text = (scoresum / playkaisuu).ToString();
            t_aveclear.text = (100 * clearkaisuu / playkaisuu).ToString() + "%";
            t_aveFC.text = (100 * FCkaisuu / playkaisuu).ToString() + "%";
            t_aveperfect.text = (perfectsum / (double)playkaisuu).ToString("#0.0") + "/" + ms.notes[sid];
            t_highscore.text = highscore.ToString();
            t_bestperfect.text = bestperfect.ToString() + "/" + ms.notes[sid];
            t_FCline.text = FCline.ToString();
            t_clearline.text = clearline.ToString();
    /*    }else
        {
            t_playkaisuu.text = "未プレイ";
        }
        */
       // if (j != 0)
       // {
            t_twe_aveperfect.text = (perfectsum_twe / (double)j).ToString("#0.0") + "/" + ms.notes[sid];
            t_twe_avescore.text = (scoresum_twe / j).ToString();
            t_twe_clearkaisuu.text = (100*clearkaisuu_twe/j).ToString() + "%";
            t_twe_FCkaisuu.text = (100*FCkaisuu_twe/j).ToString() + "%";
     /*   }
        else
        {           
            t_avescore.text = "未プレイ";
        }
        */
    }



}

/*
 * classのリスト、今後利用するかもしれない！！
        for(int i = 0; i<mr.songid.Count; i++)
        {
            if (mr.songid.Contains(sid))  //選択している曲番号に一致した結果であれば
            {
                ml.Add(new MusicListDX { _songid = sid, _gameid = mr.gameid[i] });
                Debug.Log(ml);
            }
        }


    */