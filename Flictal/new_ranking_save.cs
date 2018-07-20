using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using System.IO;
using System;

public class new_ranking_save : MonoBehaviour
{
    public GameObject scriptbox;
    public GameObject rankingmenu;
//    public GameObject Topmenu;
    public GameObject makename;
    public GameObject duplicated;
    public InputField namefield;
    public GameObject top_score;
    public GameObject top_level;
    // public Text t_rank;
    public string rankingdata;
    savedata sv = new savedata();
    string json;

    // ボタン押下許可フラグ
    private bool isPushReloadButton = false;

    // ボタンが押されてから次にまた押せるまでの時間(秒)
    private TimeSpan allowTime = new TimeSpan(0, 0, 1);

    // 前回ボタンが押された時点と現在時間との差分を格納
    private TimeSpan pastTime;

    System.DateTime reloadTime;

    public void Savetest()
    {
        int score = 10;
        QuickRanking.Instance.SaveRanking("Text", score);
    }

    public void Savesample()
    {
        saveLevelRanking("太郎", 15, 0);
    }

    public void TrytoSave()
    {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        string myname = sv._name;
        if (myname == "")
        {
            rankingmenu.SetActive(false);
            duplicated.SetActive(false);
            makename.SetActive(true);
        }
        else
        {
            saveScoreRanking(sv._name, sv._bestscore[0], sv._bestscore[1]);
            saveLevelRanking(sv._name, sv._sv_level[0], sv._sv_level[1]);
            CheckScore();
        }
    }

    public void checkPlayerName()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreRanking");
        string playerName = namefield.text;
        query.WhereEqualTo("playername", playerName);
        query.CountAsync((int count, NCMBException e) => { // 1つ上のコードで絞られたデータが何個あるかかぞえる 
            if (e == null)
            {
                if (count == 0 || playerName == "")
                { // 0個なら名前は登録されていないので登録
                    json = File.ReadAllText(Application.persistentDataPath + "/data.json");
                    JsonUtility.FromJsonOverwrite(json, sv);//
                    sv._name = playerName;
                    Debug.Log("あなたの名前は" + sv._name);
                    json = JsonUtility.ToJson(sv);
                    File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった  

                    saveScoreRanking(sv._name, sv._bestscore[0], sv._bestscore[1]);
                    saveLevelRanking(sv._name, sv._sv_level[0], sv._sv_level[1]);
                    Debug.Log("登録しました!!");

                    CheckScore();
                    //                    makename.SetActive(false);
                    //                    Topmenu.SetActive(true);
                    makename.SetActive(false);
//                    scenemover sm = scriptbox.GetComponent<scenemover>();//スコアを取得
//                    sm.homeButtonpushed();
                    
                }
                else
                { // 0個じゃなかったらすでに名前が登録されている
                    Debug.Log("登録できません");
                    duplicated.SetActive(true);
                }
            }
        });
    }

    //データのセーブ部分///////////////////////////////////////////////////////////////////////////
    public void saveScoreRanking(string playerName, int score, int sankaku)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreRanking"); // NCMB上のScoreRankingクラスを取得
        NCMBObject cloudObj = new NCMBObject("ScoreRanking");
        query.WhereEqualTo("playername", playerName); // プレイヤー名でデータを絞る
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { // データの検索が成功したら、

                if (objList.Count == 0)
                { // ハイスコアが未登録の場合
                    Debug.Log("新規登録");
                    cloudObj["playername"] = playerName;
                    cloudObj["score"] = score;
                    cloudObj["sankaku"] = sankaku;
                    cloudObj.SaveAsync(); // セーブ
                }
                else
                { // ハイスコアが登録済みの場合
                    int cloudScore = System.Convert.ToInt32(objList[0]["score"]); // クラウド上のスコアを取得
                    Debug.Log("もうあるよ");
                    if (score > cloudScore)
                    { // 今プレイしたスコアの方が高かったら、
                        Debug.Log("新記録!!");
                        objList[0]["score"] = score; // それを新しいスコアとしてデータを更新
                        objList[0].SaveAsync(); // セーブ
                    }
                }
            }
        });
    }


    public void saveLevelRanking(string playerName, int score, int sankaku)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("LevelRanking"); // NCMB上のScoreRankingクラスを取得
        NCMBObject cloudObj = new NCMBObject("LevelRanking");
        query.WhereEqualTo("playername", playerName); // プレイヤー名でデータを絞る
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { // データの検索が成功したら、

                if (objList.Count == 0)
                { // ハイスコアが未登録の場合
                    Debug.Log("新規登録");
                    cloudObj["playername"] = playerName;
                    cloudObj["level"] = score;
                    cloudObj["sankaku"] = sankaku;
                    cloudObj.SaveAsync(); // セーブ
                }
                else
                { // ハイスコアが登録済みの場合
                    int cloudScore = System.Convert.ToInt32(objList[0]["level"]); // クラウド上のスコアを取得
                    Debug.Log("もうあるよ");
                    if (score > cloudScore)
                    { // 今プレイしたスコアの方が高かったら、
                        Debug.Log("新記録!!");
                        objList[0]["level"] = score; // それを新しいスコアとしてデータを更新
                        objList[0].SaveAsync(); // セーブ
                    }
                }
            }
        });
    }


    //データのロード部分/////////////////////////////////////////////////////////////////////////////

    void Update()
    {
        // 3秒後にボタン押下を許可
        if (isPushReloadButton)
        {
            pastTime = DateTime.Now - reloadTime;
            if (pastTime > allowTime)
            {
                isPushReloadButton = false;
            }
            //        Debug.Log("ボタン停止中");
        }
    }


    //ボタンイベント
    public void trytosaveButton()
    {
        if (isPushReloadButton) return;
        isPushReloadButton = true;

        // ここに通信処理などを書く
        TrytoSave();

        //現在の時間をセット
        reloadTime = DateTime.Now;
    }


    //ボタンイベント
    public void checkplayernameButton()
    {
        if (isPushReloadButton) return;
        isPushReloadButton = true;

        // ここに通信処理などを書く
        checkPlayerName();

        //現在の時間をセット
        reloadTime = DateTime.Now;
    }

    public void CheckScore()
    {
        new_ranking_load rl = scriptbox.GetComponent<new_ranking_load>();
        rl.getScoreRanking();
        top_score.SetActive(true);
        top_level.SetActive(false);
    }

    public void CheckLevel()
    {
        new_ranking_load rl = scriptbox.GetComponent<new_ranking_load>();
        rl.getLevelRanking();
        top_score.SetActive(false);
        top_level.SetActive(true);
    }
}
