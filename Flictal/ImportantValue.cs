using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImportantValue : MonoBehaviour {
    public GameObject scriptbox;
    public GameObject firsttriangle;
    public GameObject BigTriangleNOW;
    public GameObject BigBigTriangleNOW;
    public GameObject BigBigBigTriangleNOW;
    public GameObject Triup_third;
    public GameObject Trileft_third;
    public GameObject Triright_third;

    // 自機の色
    public Color mycolor;
    public Color aroundcolor;
    public Color centercolor_esc;
    public Color dangertxtcolor;

    public int score_lv1;//flick lv1 １打のポイント
    public int score_lv2;//flick_1
    public int score_lv3;
    public int score_lv4;
    public int combobonus_lv1;
    public int combobonus_lv2;
    public int combobonus_lv3;
    public int combobonus_lv4;
    public int addcombo1;
    public int addtime1;//scoreholder
    public int addcombo2;
    public int addtime2;
    public int addcombo3;
    public int addtime3;
    public float timebonus_score_lv1;
    public float timebonus_score_lv2;
    public float timebonus_score_lv3;
    public int missscore_lv1;
    public int missscore_lv2;
    public int missscore_lv3;
    public int missscore_lv4;
    public float timebonus_combo;
    public float cooltime;
    public float cooltimeholder;
    public int jiki;//jsonから引っ張ってきた自機番号
    public int GAMEMODE;
    public float sv_progress_per_level;
    public float[] sv_PlayTime;
    public int zanki = 3;
    public Material jikimat;
    public Sprite jikispr;
    public Material defomat;
    public Sprite defospr;
    public bool matFound;
    //
    public string json;

    void Start()
    {
        //jsonの初回ロード
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        savedata sv = new savedata();
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        jiki = sv._jiki;
        //jiki = 10;

        //ここから
        if (jikimat = Resources.Load<Material>("Materials/no" + jiki))
        {
            firsttriangle.GetComponent<SpriteRenderer>().material = jikimat;
            Debug.Log(jiki + "じゃん");
            matFound = true;
        }
        else
        {
            jikispr= Resources.Load<Sprite>("Materials/no" + jiki);
            firsttriangle.GetComponent<SpriteRenderer>().sprite = jikispr;
            Debug.Log("ないじゃｎ");
        }
        //ここまで

        //自機色決定
        //        mycolor = new Color(0, 1, 1, 1);
        //  
        //自機色決定
        //        mycolor = new Color(0, 1, 1, 1);
        //        aroundcolor = new Color(1, 0, 1, 1);

        firsttriangle.GetComponent<SpriteRenderer>().color = mycolor;



        firsttriangle.GetComponent<SpriteRenderer>().color = mycolor;


        //周りの色決定
        patternset pm = BigTriangleNOW.GetComponent<patternset>();
        relay pmm = BigBigTriangleNOW.GetComponent<relay>();
        relay1 pmmm = BigBigBigTriangleNOW.GetComponent<relay1>();
        relay1 pup = Triup_third.GetComponent<relay1>();
        relay1 pleft = Trileft_third.GetComponent<relay1>();
        relay1 pright = Triright_third.GetComponent<relay1>();

        pm.aroundcolorchange();
        pmm.aroundcolorchange();
        pmmm.aroundcolorchange();
        pup.aroundcolorchange();
        pleft.aroundcolorchange();
        pright.aroundcolorchange();

        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得 
        se.SEswitch(sv._sound);
        se.BGMswitch(sv._BGM);
    }

    public void colorReset()
    {
        patternset pm = BigTriangleNOW.GetComponent<patternset>();
        relay pmm = BigBigTriangleNOW.GetComponent<relay>();
        relay1 pmmm = BigBigBigTriangleNOW.GetComponent<relay1>();
        relay1 pup = Triup_third.GetComponent<relay1>();
        relay1 pleft = Trileft_third.GetComponent<relay1>();
        relay1 pright = Triright_third.GetComponent<relay1>();

        pm.aroundcolorchange();
        pmm.aroundcolorchange();
        pmmm.aroundcolorchange();
        pup.aroundcolorchange();
        pleft.aroundcolorchange();
        pright.aroundcolorchange();
    }
}
