using UnityEngine;
using System.IO;
using UnityEngine.UI;


//せっかく作ったけど、200個
public class Songs_setter : MonoBehaviour
{
    MusicScore ms = new MusicScore();
    private GameObject showingcontent;
    public GameObject Oya;//親から見つけていけば非表示の奴を見つけられるよ
    private GameObject dif;//難易度を見つけるためにやむなし
    private Text dift;
    private string json;

    private Color All = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
    private Color Pr = new Color(255.0f / 255.0f, 230.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
    private Color Fa = new Color(200.0f / 255.0f, 240.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
    private Color An = new Color(255.0f / 255.0f, 255.0f / 255.0f, 180.0f / 255.0f, 255.0f / 255.0f);

    public int targettype=4;

    public GameObject scrollview;
    [SerializeField]

    private GameObject songnode;  //ボタンプレハブ
    public GameObject scriptbox;

    //ボタン表示数

    const int BUTTON_COUNT = 200;

    public void Start()
    {
        targettype = 4;
        Set_Default();
    }

    public void Set_Default()
    {
        int i;
        int found=0;//条件に合った曲の数
        int j;
        json = File.ReadAllText(Application.persistentDataPath + "/songslist.json");//読み取ってるよ

        JsonUtility.FromJsonOverwrite(json, ms);//読み取ったのを変換してるよ
  
        //ここでソートやるぜ！！！！！！！！！！！！！！！

        Sort();
        for (i = 0; i < ms.songid.Count; i++)
        {

            if (ms.gameid[i] == 0)     //ゲームの判定、ミリシタなら0の奴だけ通れ
                if (ms.type[i] == targettype || targettype ==4) {
                    //属性の判定
                    showsong(found, ms.songid[i], ms.songname[i], ms.type[i], ms.difficulty[i], ms.notes[i]);
                    found++;
                }
        }
        
        for (j=found; j < 50; j++)
        {
            GameObject unshowingcontent = Oya.transform.Find("SongPrefab (" + j + ")").gameObject;
            unshowingcontent.SetActive(false);
            Debug.Log(j);
        }

    }


    //表示するタイプを切り替える　100は全表示
    public void Typechange()
    {
        switch (targettype)
        {
            case 0:
                targettype = 1;
                break;
            case 1:
                targettype = 2;
                break;
            case 2:
                targettype = 3;
                break;
            case 3:
                targettype = 4;
                break;
            case 4:
                targettype = 0;
                break;
        }
        Debug.Log(targettype+"だよ");
    }

    void Sort()
    {

    }

    void showsong(int num,int songid,string songname,int type,int difficulty,int notes)
    {
        
        showingcontent = Oya.transform.Find("SongPrefab (" + num + ")").gameObject; //まずSongprefab(i)を捕獲※activeでないので親から辿る必要あり

        showingcontent.SetActive(true);
        //難易度付けるのにここから3行、めんどい
        dif=showingcontent.transform.Find("Difficulty").gameObject;
        dift= dif.GetComponent<Text>();
        dift.text= difficulty.ToString();
        //色も付けるよ
        switch (type)
        {
            case 0:
                showingcontent.GetComponent<Image>().color = All;
                break;
            case 1:
                showingcontent.GetComponent<Image>().color = Pr;
                break;
            case 2:
                showingcontent.GetComponent<Image>().color = Fa; 
                break;
            case 3:
                showingcontent.GetComponent<Image>().color = An;
                break;
        }


        //他
        showingcontent.transform.GetComponentInChildren<Text>().text = songname;
        showingcontent.transform.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        showingcontent.transform.GetComponentInChildren<Button>().onClick.AddListener(() => OnClick(songid));

    }


    //ボタンを押したら必ずここに飛ぶ(↑でaddlistenerに登録されてる)！！知ってた！？！？
    public void OnClick(int songid)

    {
        //何故か先に1が来るけど…うーん
        MainScript d1 = scriptbox.GetComponent<MainScript>();
        d1.ResultAddSelected(songid);
    }




    //化石    
    public void SetUseless()

    {

        //Content取得(ボタンを並べる場所)

        RectTransform content = scrollview.GetComponent<RectTransform>();

        //Contentの高さ決定

        //(ボタンの高さ+ボタン同士の間隔)*ボタン数

        float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;

        float btnHeight = songnode.GetComponent<LayoutElement>().preferredHeight;

        content.sizeDelta = new Vector2(0, (btnHeight + btnSpace) * BUTTON_COUNT);
        Debug.Log(content .sizeDelta);
        for (int i = 0; i < BUTTON_COUNT; i++)

        {

            int no = i;

            //ボタン生成

            GameObject btn = (GameObject)Instantiate(songnode);

            //ボタンをContentの子に設定

            btn.transform.SetParent(content, false);

            //ボタンのテキスト変更

            btn.transform.GetComponentInChildren<Text>().text = "Btn_"+no.ToString();

            //ボタンのクリックイベント登録

            btn.transform.GetComponentInChildren<Button>().onClick.AddListener(() => OnClick(no));

            
        }

    }

}