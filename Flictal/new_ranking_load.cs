using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class new_ranking_load : MonoBehaviour
{
    public GameObject rankingmenu;
 //   public GameObject Topmenu;
    //  public Text t_rank;
    public string rankingdata;
    public GameObject Oya;
    private GameObject showingcontent;
    private GameObject _num;//難易度を見つけるためにやむなし
    private Text numt;
    public GameObject scriptbox;

    void Start()
    {
        //rankingmenu.SetActive(false);
        //        Topmenu.SetActive(true);
        getScoreRanking();
    }

    // Use this for initialization
    public void ShowRanking()
    {
        rankingmenu.SetActive(true);
        rankingdata = QuickRanking.Instance.GetRankingByText();
        // t_rank.text = rankingdata;
        rankingmenu.SetActive(true);
      //  Topmenu.SetActive(false);
    }

    // Update is called once per frame
    public void HideRanking()
    {
        //rankingmenu.SetActive(false);
//        Topmenu.SetActive(true);
        scenemover sm = scriptbox.GetComponent<scenemover>();//スコアを取得
        sm.homeButtonpushed();
    }
    public void Savetest()
    {
        int score = 10;
        QuickRanking.Instance.SaveRanking("Text", score);
    }
    //データのロード部分/////////////////////////////////////////////////////////////////////////////

    public void getScoreRanking()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreRanking");
        query.OrderByDescending("score"); // スコアを降順に並び替える
        query.Limit = 100; // 上位10件のみ取得
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { //検索成功したら
                List<string> nameList = new List<string>(); // 名前のリスト
                List<int> sankakuList = new List<int>(); // 使用三角のリスト
                List<int> scoreList = new List<int>(); // スコアのリスト
                for (int i = 0; i < objList.Count; i++)
                {
                    string s = System.Convert.ToString(objList[i]["playername"]); // 名前を取得
                    int t = System.Convert.ToInt32(objList[i]["sankaku"]); // スコアを取得
                    int n = System.Convert.ToInt32(objList[i]["score"]); // スコアを取得
                    nameList.Add(s); // リストに突っ込む
                    scoreList.Add(t);
                    scoreList.Add(n);
                    addrank(i + 1, s, t, n);
                }
            }
        });
        ////ここから表示
    }

    public void getLevelRanking()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("LevelRanking");
        query.OrderByDescending("level"); // スコアを降順に並び替える
        query.Limit = 100; // 上位10件のみ取得
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { //検索成功したら
                List<string> nameList = new List<string>(); // 名前のリスト
                List<int> sankakuList = new List<int>(); // 使用三角のリスト
                List<int> scoreList = new List<int>(); // スコアのリスト
                for (int i = 0; i < objList.Count; i++)
                {
                    string s = System.Convert.ToString(objList[i]["playername"]); // 名前を取得
                    int t = System.Convert.ToInt32(objList[i]["sankaku"]); // スコアを取得
                    int n = System.Convert.ToInt32(objList[i]["level"]); // スコアを取得
                    nameList.Add(s); // リストに突っ込む
                    scoreList.Add(t);
                    scoreList.Add(n);
                    addrank(i + 1, s, t, n);
                }
            }
        });
        ////ここから表示
    }



    void addrank(int num, string playername, int sankaku, int score)
    {

        showingcontent = Oya.transform.Find("Image (" + num + ")").gameObject; //まずSongprefab(i)を捕獲※activeでないので親から辿る必要あり

        showingcontent.SetActive(true);

        //名前付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("rank_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = num.ToString();

        //名前付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("name_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = playername.ToString();

        //難易度付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("sankaku_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = sankaku.ToString();


        //難易度付けるのにここから3行、めんどい
        _num = showingcontent.transform.Find("score_t").gameObject;
        numt = _num.GetComponent<Text>();
        numt.text = score.ToString();
        //色も付けるよ

        //他
        //        showingcontent.transform.GetComponentInChildren<Text>().text = songname;
        //      showingcontent.transform.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        //    showingcontent.transform.GetComponentInChildren<Button>().onClick.AddListener(() => OnClick(songid));

    }


}
