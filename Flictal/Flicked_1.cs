using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flicked_1 : MonoBehaviour
{
    [SerializeField]
    Transform rectTran;
    [SerializeField]  //
    Transform IrectTran; //
    public int nowpos ;
    public int targetpos ;
    public int hazurepos ;
    public GameObject bigtriangle;
    public GameObject triangleup;
    public GameObject triangleleft;
    public GameObject triangleright;
    public GameObject scoretext;
    public GameObject scriptbox;
    public GameObject before_edge;
    public GameObject after_edge;
    public int score = 0;

    //三角形の状態
    bool[] pattern;

    //引き継ぎ用資料
    public GameObject childnow;
    public GameObject childup;
    public GameObject childleft;
    public GameObject childright;

    //20回目限定
    public bool firstmove(int goal){
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        ImportantValue v0 = scriptbox.GetComponent<ImportantValue>();//スコアを取得
        ScoreHolder d_score = scriptbox.GetComponent<ScoreHolder>();//スコアを取得

        bool hantei = false;//
 //       var lefttri = new Vector3(-0.2166f, -0.125f, -1);
        //データの引き継ぎ
        Flicked f1 = scriptbox.GetComponent<Flicked>();
        targetpos = f1.targetpos;
        nowpos = f1.nowpos;
        hazurepos = f1.hazurepos;
        if (goal == targetpos)//正解
        {
            before_edge.SetActive(false);
            after_edge.SetActive(true);
            hantei = true;//
            //次段階の登場
            pattern = new bool[3];
            pattern[nowpos] = true;
            pattern[goal] = true;
            pattern[hazurepos] = false;
            Debug.Log(pattern[0] + "," + pattern[1] + ","+pattern[2]);

            triangleup.SetActive(true);
            triangleleft.SetActive(true);
            triangleright.SetActive(true);
            rectTran.DOScale(0.5f , 0.1f);
            switch (goal)
            {
                case 0:
                    if (v0.matFound == true)
                    {
                        childup.GetComponent<SpriteRenderer>().material =v0.jikimat;
                        childup.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    else
                    {
                        childup.GetComponent<SpriteRenderer>().color = Color.white;
                        childup.GetComponent<SpriteRenderer>().sprite = v0.jikispr;
                    }
                    break;
                case 1:
                    if (v0.matFound == true)
                    {
                        childleft.GetComponent<SpriteRenderer>().material = v0.jikimat;
                        childleft.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    else
                    {
                        childleft.GetComponent<SpriteRenderer>().color = Color.white;
                        childleft.GetComponent<SpriteRenderer>().sprite = v0.jikispr;
                    }
                    break;
                case 2:
                    if (v0.matFound == true)
                    {
                        childright.GetComponent<SpriteRenderer>().material = v0.jikimat;
                        childright.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    else
                    {
                        childright.GetComponent<SpriteRenderer>().color = Color.white;
                        childright.GetComponent<SpriteRenderer>().sprite = v0.jikispr;
                    }
                    // childright.GetComponent<SpriteRenderer>().color = v0.mycolor;
                    // childright.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Materials/no" + v0.jiki);
                    break;
            }



            move(goal);//
        }else
        {
            var uptri = new Vector3(0, 0.25f, -5);//
            var lefttri = new Vector3(-0.2166f, -0.125f, -5);//
            var righttri = new Vector3(0.2166f, -0.125f, -5);//

            GetComponent<AudioSource>().PlayOneShot(se.hazure);//効果音を鳴らす
            d_score.left_jiki--;
            d_score.miss();
            var sequence = DOTween.Sequence();
            //追加部分
            switch (goal)
            {
                case 0:
                    switch (nowpos)
                    {
                        case 0:
                            break;
                        case 1:
                            sequence.Append(IrectTran.DOLocalMove(uptri, 0.1f));
                            sequence.Append(IrectTran.DOLocalMove(lefttri, 0.05f));
                            break;
                        case 2:
                            sequence.Append(IrectTran.DOLocalMove(uptri, 0.1f));
                            sequence.Append(IrectTran.DOLocalMove(righttri, 0.05f));
                            break;
                    }
                    break;
                case 1:
                    switch (nowpos)
                    {
                        case 0:
                            sequence.Append(IrectTran.DOLocalMove(lefttri, 0.1f));
                            sequence.Append(IrectTran.DOLocalMove(uptri, 0.05f));
                            break;
                        case 1:
                            break;
                        case 2:
                            sequence.Append(IrectTran.DOLocalMove(lefttri, 0.1f));
                            sequence.Append(IrectTran.DOLocalMove(righttri, 0.05f));
                            break;
                    }
                    break;
                case 2:
                    switch (nowpos)
                    {
                        case 0:
                            sequence.Append(IrectTran.DOLocalMove(righttri, 0.1f));
                            sequence.Append(IrectTran.DOLocalMove(uptri, 0.05f));
                            break;
                        case 1:
                            sequence.Append(IrectTran.DOLocalMove(righttri, 0.1f));
                            sequence.Append(IrectTran.DOLocalMove(lefttri, 0.05f));
                            break;
                        case 2:
                            break;
                    }

                    break;
            }
        }

        return (hantei);//
    }

    public void move(int goal)//(始点,終点)
    {

        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        var uptri = new Vector3(0, 0.25f, -5);
        var lefttri = new Vector3(-0.2166f, -0.125f, -5);
        var righttri = new Vector3(0.2166f, -0.125f, -5);
        ScoreHolder d_score = scriptbox.GetComponent<ScoreHolder>();//スコアを取得
        ImportantValue dx = scriptbox.GetComponent<ImportantValue>();//スコアを取得
        
        if (goal == targetpos)//正解なら三角形が移動し、解答が再配置される
        {
//            Debug.Log("正解");
            GetComponent<AudioSource>().PlayOneShot(se.atari);//効果音を鳴らす
     
            d_score.comboadd();
            ansset(nowpos, goal);   //正解の配置
            triset();               //三角形の配置
            switch (goal)
            {
                case 0:
                    rectTran.DOLocalMove(uptri, 0.1f);

                    break;
                case 1:
                    rectTran.DOLocalMove(lefttri, 0.1f);
                    break;
                case 2:
                    rectTran.DOLocalMove(righttri, 0.1f);
                    break;
            }
        }
        else if (goal == nowpos) //同じ場所にフリックしたら　何もなし
        {

        }
        else
        {//外れたら ペナルティ///////////////////////////////////////////
         //3秒待たせる
            GetComponent<AudioSource>().PlayOneShot(se.hazure);//効果音を鳴らす
          //  d_score.score = d_score.score - dx.missscore_lv2;
            d_score.miss();
            d_score.left_jiki--;
            var sequence = DOTween.Sequence();
            switch (goal)
            {
                case 0:
                    switch (nowpos)
                    {
                        case 0:
                            break;
                        case 1:
                            sequence.Append(rectTran.DOLocalMove(uptri, 0.1f));
                            sequence.Append(rectTran.DOLocalMove(lefttri, 0.05f));
                            break;
                        case 2:
                            sequence.Append(rectTran.DOLocalMove(uptri, 0.1f));
                            sequence.Append(rectTran.DOLocalMove(righttri, 0.05f));
                            break;
                    }
                    break;
                case 1:
                    switch (nowpos)
                    {
                        case 0:
                            sequence.Append(rectTran.DOLocalMove(lefttri, 0.1f));
                            sequence.Append(rectTran.DOLocalMove(uptri, 0.05f));
                            break;
                        case 1:
                            break;
                        case 2:
                            sequence.Append(rectTran.DOLocalMove(lefttri, 0.1f));
                            sequence.Append(rectTran.DOLocalMove(righttri, 0.05f));
                            break;
                    }
                    break;
                case 2:
                    switch (nowpos)
                    {
                        case 0:
                            sequence.Append(rectTran.DOLocalMove(righttri, 0.1f));
                            sequence.Append(rectTran.DOLocalMove(uptri, 0.05f));
                            break;
                        case 1:
                            sequence.Append(rectTran.DOLocalMove(righttri, 0.1f));
                            sequence.Append(rectTran.DOLocalMove(lefttri, 0.05f));
                            break;
                        case 2:
                            break;
                    }

                    break;
            }
            ///////////////////////////////////////////////////////////////////////
            d_score.combo = 0;
            Debug.Log("不正解…正解は" + targetpos);
        }
    }
    void ansset(int start, int goal) //現在地変更　及び　新しい解答の配置
    {
        nowpos = goal;  //現在地(nowpos)を更新

        int rand;
        rand = Random.Range(0, 2);//0か1を生成
        //新しい正解(targetpos)を更新
        if (rand == 0)
        {
            targetpos = nowpos + 1;
            if (targetpos == 3) targetpos = 0;
        }
        else
        {
            targetpos = nowpos - 1;
            if (targetpos == -1) targetpos = 2;
        }

        //hazureposを場所変更
        for (int i = 0; i < 3; i++)
        {
            if (i != targetpos && i != nowpos)
                hazurepos = i;
        }

    }
    void triset()//三角形の再配置
    {
        //正解の配置
        patternset p0 = triangleup.GetComponent<patternset>();//スコアを取得
        patternset p1 = triangleleft.GetComponent<patternset>();//スコアを取得
        patternset p2 = triangleright.GetComponent<patternset>();//スコアを取得
        switch (targetpos)
        {
            case 0:
                p0.set(pattern);
                break;
            case 1:
                p1.set(pattern);
                break;
            case 2:
                p2.set(pattern);
                break;
        }

        //不正解の配置
        switch (hazurepos)
        {
            case 0:
                p0.setrand(pattern);
                p0.kinsoku(pattern);
                break;
            case 1:
                p1.setrand(pattern);
                p1.kinsoku(pattern);
                break;
            case 2:
                p2.setrand(pattern);
                p2.kinsoku(pattern);
                break;
        }


    }
    void missansset()
    {

    }
    void misstriset()
    {

    }

}
