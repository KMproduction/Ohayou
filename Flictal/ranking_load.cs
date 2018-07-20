using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using System.IO;

public class ranking_load : MonoBehaviour
{
    string json;
    savedata sv = new savedata();

    public GameObject rankingmenu;
    public GameObject Topmenu;
  //  public Text t_rank;
    public string rankingdata;
    public GameObject Oya;
    private GameObject showingcontent;
    private GameObject _num;//難易度を見つけるためにやむなし
    private Text numt;
    public Text myname;
    public Text mysankaku;
    public Text myresult;

    // Use this for initialization
    public void ShowRanking()
    {
        rankingmenu.SetActive(true);
        rankingdata = QuickRanking.Instance.GetRankingByText();
       // t_rank.text = rankingdata;
        rankingmenu.SetActive(true);
        Topmenu.SetActive(false);
    }

    // Update is called once per frame
    public void HideRanking()
    {
        rankingmenu.SetActive(false);
        Topmenu.SetActive(true);
    }
    public void Savetest()
    {
        int score = 10;
        QuickRanking.Instance.SaveRanking("Text", score);
    }
    //データのロード部分/////////////////////////////////////////////////////////////////////////////

    public void getScoreRanking()
    {
        jikidata_json jd = new jikidata_json();
        myscorerank();
        bool isme = false;
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreRanking");
        query.OrderByDescending("score"); // スコアを降順に並び替える
        query.Limit = 100; // 上位10件のみ取得
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { //検索成功したら
                List<string> nameList = new List<string>(); // 名前のリスト
                List<string> sankakuList = new List<string>(); // 使用三角のリスト
                List<int> scoreList = new List<int>(); // スコアのリスト
                for (int i = 0; i < objList.Count; i++)
                {
                    if (i < 100)
                    {
                        string s = System.Convert.ToString(objList[i]["playername"]); // 名前を取得
                        string t = jd.name[System.Convert.ToInt32(objList[i]["sankaku"])]; // スコアを取得
                        int n = System.Convert.ToInt32(objList[i]["score"]); // スコアを取得
                        nameList.Add(s); // リストに突っ込む
                        sankakuList.Add(t);
                        scoreList.Add(n);
                        if (s == sv._name)
                        {
                            isme = true;
                        }
                        addrank(i + 1, s, t, n, isme);
                        isme = false;
                    }
                    
                }
            }
        });
        ////ここから表示
    }

    public void getLevelRanking()
    {
        jikidata_json jd = new jikidata_json();
        mylevelrank();
        bool isme = false;
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("LevelRanking");
        query.OrderByDescending("level"); // スコアを降順に並び替える
        query.Limit = 100; // 上位10件のみ取得
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { //検索成功したら
                List<string> nameList = new List<string>(); // 名前のリスト
                List<string> sankakuList = new List<string>(); // 使用三角のリスト
                List<int> scoreList = new List<int>(); // スコアのリスト
                for (int i = 0; i < objList.Count; i++)
                {
                    if (i < 100)
                    {
                        string s = System.Convert.ToString(objList[i]["playername"]); // 名前を取得
                        string t = jd.name[System.Convert.ToInt32(objList[i]["sankaku"])]; // スコアを取得
                        Debug.Log("t=" + t);
                        int n = System.Convert.ToInt32(objList[i]["level"]); // スコアを取得
                        nameList.Add(s); // リストに突っ込む
                        sankakuList.Add(t);
                        scoreList.Add(n);
                        if (s == sv._name)
                        {
                            isme = true;
                        }
                        addrank(i + 1, s, t, n,isme);
                        isme = false;
                    }
                }
            }
        });
        ////ここから表示
    }


    void addrank(int num, string playername, string sankaku, int score,bool isme)
    {

        showingcontent = Oya.transform.Find("Image (" + num + ")").gameObject; //まずSongprefab(i)を捕獲※activeでないので親から辿る必要あり

        showingcontent.SetActive(true);

        //名前付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("rank_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = num.ToString();
        if (isme == true)
            numt.color = Color.red;
        else
            numt.color = Color.black;
        //名前付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("name_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = playername.ToString();
        if (isme == true)
            numt.color = Color.red;
        else
            numt.color = Color.black;
        //難易度付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("sankaku_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = sankaku.ToString();
        if (isme == true)
            numt.color = Color.red;
        else
            numt.color = Color.black;


        //難易度付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("score_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = score.ToString();
        if (isme == true)
            numt.color = Color.red;
        else
            numt.color = Color.black;



    }


 /*   void myscorerank()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreRanking"); // NCMB上のScoreRankingクラスを取得
        NCMBObject cloudObj = new NCMBObject("ScoreRanking");
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { // データの検索が成功したら、

                if (objList.Count != 0)
                { // ハイスコアが未登録の場合
                    Debug.Log("新規登録");
                    string s = System.Convert.ToString(objList[0]["playername"]);
                    mysankaku.text= System.Convert.ToString(objList[0]["sankaku"]);
                    myresult.text = System.Convert.ToString(objList[0]["score"]);
                    cloudObj.SaveAsync(); // セーブ
                }
            }
        });
    }
    */
    void myscorerank()
    {
        jikidata_json jd = new jikidata_json();
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        //myname.text = sv._name;
        mysankaku.text = jd.name[sv._bestscore[1]].ToString();
        myresult.text = sv._bestscore[0].ToString();

    }

    void mylevelrank()
    {
        jikidata_json jd = new jikidata_json();
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        //myname.text = sv._name;
        mysankaku.text =jd.name[sv._sv_level[1]].ToString();
        myresult.text = sv._sv_level[0].ToString();

    }
}
