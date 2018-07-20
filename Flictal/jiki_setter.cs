using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


using UnityEngine.UI;

public class jiki_setter : MonoBehaviour {
    savedata sv = new savedata();
    string json;
    private GameObject showingcontent;
    private GameObject tri;
    private GameObject sec;
    public GameObject backsankaku;
    public GameObject Oya;//親から見つけていけば非表示の奴を見つけられるよ
    public GameObject scriptbox;
    public Text jikiname;
    public Text setumei;
    public Material jikimat;
    public Sprite jikispr;
    public bool matFound;
    public Sprite defospr;
    public Material defomat;



    jikidata_json jd = new jikidata_json();

    private GameObject no;//難易度を見つけるためにやむなし
    private Text no_t;

    // Use this for initialization
    public void Set () {
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ

        jikiname.text = jd.name[sv._jiki];
        setumei.text = jd.info[sv._jiki];

        for (int i = 0; i < sv._jikicount; i++)
        {//全ての参画に対して
            showingcontent = Oya.transform.Find("item (" + i + ")").gameObject; //まずitem (i)を捕獲※activeでないので親から辿る必要あり
            showingcontent.SetActive(true);

            no = showingcontent.transform.Find("no").gameObject;
            no_t = no.GetComponent<Text>();
            int number = i;
            no_t.text = (number).ToString();


            if (sv._jikiflag[i] == true)
            {
                tri = showingcontent.transform.Find("tri").gameObject;
                tri.SetActive(true);
               // tri.GetComponent<Image>().material = Resources.Load<Material>("Materials/No" + i);
 //               title_importaantvalue v0 = scriptbox.GetComponent<title_importaantvalue>();
                int rand0 = Random.Range(0, 2);//0か1を生成
                if (jikimat = Resources.Load<Material>("Materials/no" + i))
                {
                    Debug.Log("大丈夫だよね？");
                    tri.GetComponent<Image>().material = jikimat;
                    tri.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    jikispr = Resources.Load<Sprite>("Materials/no" + i);
                    tri.GetComponent<Image>().sprite = jikispr;
                }
                showingcontent.transform.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                showingcontent.transform.GetComponentInChildren<Button>().onClick.AddListener(() => OnClick(number,true));

            }
            else
            {
                sec = showingcontent.transform.Find("secret").gameObject;
                sec.SetActive(true); showingcontent.transform.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                showingcontent.transform.GetComponentInChildren<Button>().onClick.AddListener(() => OnClick(number,false));

            }


          //  Debug.Log("i=" + i);

        }


    }


    public void OnClick(int triid,bool playable)

    {
        if (playable == true) {
            Debug.Log(triid + "を選択しました!!");
            if (jikimat = Resources.Load<Material>("Materials/no" +triid))
            {
                Debug.Log("大丈夫だよね？");
                backsankaku.GetComponent<SpriteRenderer>().material = jikimat;
                backsankaku.GetComponent<SpriteRenderer>().color = Color.white;
                backsankaku.GetComponent<SpriteRenderer>().sprite = defospr;
            }
            else
            {
                backsankaku.GetComponent<SpriteRenderer>().material = defomat;
                jikispr = Resources.Load<Sprite>("Materials/no" + triid);
                backsankaku.GetComponent<SpriteRenderer>().sprite = jikispr;
            }
      //      backsankaku.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Materials/no" + triid);
            sv._jiki = triid;
            json = JsonUtility.ToJson(sv);
            Debug.Log(json);
            json = encryption.EncryptString(json);
            File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった     
            Title_SE se = scriptbox.GetComponent<Title_SE>();//スコアを取得   
            se.TriSelected(triid);
            jikiname.text = jd.name[triid];
            setumei.text = jd.info[triid];
        }
        else
        {
            Debug.Log(triid + "は未開放です…");
            switch (triid)//解放基準を書け
            {
                case 0:
                    break;
            }
        }
    }


    // Update is called once per frame
    void Start () {
        //まずは広告

    }
}
