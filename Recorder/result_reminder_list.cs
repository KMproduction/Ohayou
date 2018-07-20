using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class result_reminder_list : MonoBehaviour
{

    public GameObject scriptbox;
    //    public Text songname;
    public GameObject Oya;
    public GameObject Oyaleft;

    private GameObject showingcontent;
    private GameObject showingcontent_left;


    private Text scoret;



    MusicScore ms = new MusicScore();
    MusicResult mr = new MusicResult();
    MusicResult mrx = new MusicResult();

    // Update is called once per frame
    public void Remind()
    {




        Debug.Log("おはよう");

        // まず、曲リストから楽曲番号を貰ってくる
        MainScript d1 = scriptbox.GetComponent<MainScript>();
        string json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");
        JsonUtility.FromJsonOverwrite(json, ms);
   //     int sid = ms.songid.IndexOf(d1.SID);//曲id抽出
                                            // songname.text = ms.songname[sid];
                                            //次に、結果リストを引っ張ってきて色々やる
        MainScript d2 = scriptbox.GetComponent<MainScript>();
        json = File.ReadAllText(Application.persistentDataPath + "/resultlist.json");
        JsonUtility.FromJsonOverwrite(json, mr);
        var ml = new List<MusicListDX>(); //データ一回避難させる先

        for (int j = 0; j < mr.songid.Count; j++)
        {
            // if (mr.songid.Contains(sid))  //選択している曲番号に一致した結果であれば
            if (mr.songid[j]==d1.SID)
            {
                ml.Add(new MusicListDX(d1.SID, mr.gameid[j], mr.score[j], mr.perfect[j], mr.great[j],
                  mr.good[j], mr.FS[j], mr.miss[j], mr.maxcombo[j], mr.FC[j], mr.clear[j] ,mr.maxcombo[j]//,                   mr.etc[j]

               ));
                
            }
        }
        int k = 0;

        //結果が多い奴→少ない曲　となってもいいように一度、結果をすべて不可視化する
        foreach (Transform item in Oya.transform)
        {
            item.gameObject.SetActive(false);
        }
        foreach (Transform item in Oyaleft.transform)
        {
            item.gameObject.SetActive(false);
        }



        //   for (int i = 0; i < ml.Count; i++)
        for (int i=ml.Count -1; i>=0; i--)
            {
            //           Debug.Log(ml);

            showingcontent_left = Oyaleft.transform.Find("numberprefab (" + k + ")").gameObject; //まずSongprefab(i)を捕獲※activeでないので親から辿る必要あり

            showingcontent = Oya.transform.Find("resultprefab (" + k + ")").gameObject; //まずSongprefab(i)を捕獲※activeでないので親から辿る必要あり

            showingcontent.SetActive(true);
            showingcontent_left.SetActive(true);
            showingcontent_left.transform.GetComponentInChildren<Text>().text = (i+1).ToString();


            //スコア付けるのにここから2行、輪をかけてめんどい※注意…transform.findは一層下しか見ない
            GameObject score = showingcontent.transform.Find("score").gameObject;
            score.transform.GetComponentInChildren<Text>().text = ml[i]._score.ToString();
            
            GameObject perfect = showingcontent.transform.Find("perfect").gameObject;
            perfect.transform.GetComponentInChildren<Text>().text = ml[i]._perfect.ToString();

            GameObject great = showingcontent.transform.Find("great").gameObject;
            great.transform.GetComponentInChildren<Text>().text = ml[i]._great.ToString();

            GameObject good = showingcontent.transform.Find("good").gameObject;
            good.transform.GetComponentInChildren<Text>().text = ml[i]._good.ToString();

            GameObject FS = showingcontent.transform.Find("FS").gameObject;
            FS.transform.GetComponentInChildren<Text>().text = ml[i]._FS.ToString();

            GameObject miss = showingcontent.transform.Find("miss").gameObject;
            miss.transform.GetComponentInChildren<Text>().text = ml[i]._miss.ToString();

            GameObject FC = showingcontent.transform.Find("FC").gameObject;
            if(ml[i]._FC==true)
                FC.transform.GetComponentInChildren<Text>().text = "〇";
            else
                FC.transform.GetComponentInChildren<Text>().text = "×";

            GameObject clear = showingcontent.transform.Find("clear").gameObject;
            if (ml[i]._clear == true)
                clear.transform.GetComponentInChildren<Text>().text = "〇";
            else
                clear.transform.GetComponentInChildren<Text>().text = "×";

            GameObject combo = showingcontent.transform.Find("combo").gameObject;
            combo.transform.GetComponentInChildren<Text>().text = ml[i]._combo.ToString();

            k++;
        }
    }

}
