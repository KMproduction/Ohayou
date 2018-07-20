using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flicked : MonoBehaviour
{
    [SerializeField]
    Transform rectTran;
    public int nowpos = 1;
    public int targetpos = 0;
    public int hazurepos = 2;
    public GameObject scriptbox;
    public GameObject triangleup;
    public GameObject triangleleft;
    public GameObject triangleright;
    public GameObject trianglenow;
    public GameObject scoretext;
    public int score = 0;
    public GameObject canvas;
    public bool newstatus;

    //!!!!!!!!!!!!!!!!!!!!!!
    [SerializeField]
    private GameObject scoreUI;

    public bool firstmove(int goal)
    {
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        timekeeper tk = scriptbox.GetComponent<timekeeper>();


        var uptri = new Vector3(0, 0.25f, -5);
        if (goal == 0)//正解
        {
            rectTran.DOLocalMove(uptri, 0.1f);
            rectTran.DOScale(0.5f, 0.1f);
           // GetComponent<AudioSource>().PlayOneShot(se.atari);//効果音を鳴らす
            move(0);
            return true;
        }
        else
            
            return false;
    }


    public void move(int goal)//(始点,終点)
    {
        var uptri = new Vector3(0, 0.25f, -5);
        var lefttri = new Vector3(-0.2166f, -0.125f, -5);
        var righttri = new Vector3(0.2166f, -0.125f, -5);
        ImportantValue dx = scriptbox.GetComponent<ImportantValue>();//スコアを取得
                ScoreHolder d_score = scriptbox.GetComponent<ScoreHolder>();//スコアを取得

        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        
        Debug.Log("ouu");

        if (goal == targetpos)//正解なら三角形が移動し、解答が再配置される
        {
            Debug.Log("ouua");
            /*      GameObject score_UI = GameObject.Instantiate(scoreUI ) as GameObject;
                  score_UI.transform.parent=canvas.transform;
                  score_UI.GetComponent<RectTransform>().localPosition = new Vector3(-340, 200, 0);
                  ScoreUI ui = score_UI.GetComponent<ScoreUI>();//スコアを取得
                  ui.hyojiscore = 3;
                  // score_UI.transform =uptri;
                  */
            //            Debug.Log("正解");

            d_score.comboadd();
            ansset(nowpos, goal);   //正解の配置
            triset();               //三角形の配置
            GetComponent<AudioSource>().PlayOneShot(se.atari);//効果音を鳴らす
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
            d_score.left_jiki--;
            GetComponent<AudioSource>().PlayOneShot(se.hazure);//効果音を鳴らす
         //   d_score.score = d_score.score - dx.missscore_lv1;
            d_score.miss();
            var sequence = DOTween.Sequence();
            switch (goal)// goal…フリック先、ミス
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

                    /*
                    case 0:
                        switch (nowpos)//今の場所
                        {
                            case 0:
                                break;
                            case 1:
                                rectTran.DOLocalMove(uptri, 0.1f);
                                break;
                            case 2:
                                rectTran.DOLocalMove(uptri, 0.1f);

                                break;
                        }
                        break;
                    case 1:
                        switch (nowpos)
                        {
                            case 0:
                                rectTran.DOLocalMove(lefttri, 0.1f);

                                break;
                            case 1:
                                break;
                            case 2:
                                rectTran.DOLocalMove(lefttri, 0.1f);
                                break;
                        }
                        break;
                    case 2:
                        switch (nowpos)
                        {
                            case 0:
                                rectTran.DOLocalMove(righttri, 0.1f);
                                break;
                            case 1:
                                rectTran.DOLocalMove(righttri, 0.1f);
                                break;
                            case 2:
                                break;
                        }

                        break;
                        */
            }
            //            missansset(nowpos, goal);
            //            triset();
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
        switch (targetpos)
        {
            case 0:
                triangleup.SetActive(true);
                break;
            case 1:
                triangleleft.SetActive(true);
                break;
            case 2:
                triangleright.SetActive(true);
                break;
        }

        //不正解の配置
        switch (hazurepos)
        {
            case 0:
                triangleup.SetActive(false);
                break;
            case 1:
                triangleleft.SetActive(false);
                break;
            case 2:
                triangleright.SetActive(false);
                break;
        }
    

/*        switch(nowpos)
        {
            case 0:
                triangleup.SetActive(false);
                break;
            case 1:
                triangleleft.SetActive(false);
                break;
            case 2:
                triangleright.SetActive(false);
                break;
        }*/
    }
}

    /*
    void triset()//三角形の再配置
    {
        newstatus = !trianglenow.activeSelf;//今の逆が新しい正解になる

        //正解の配置
        //
        switch (targetpos)
        {
            case 0:
                triangleup.SetActive(newstatus);
                break;
            case 1:
                triangleleft.SetActive(newstatus);
                break;
            case 2:
                triangleright.SetActive(newstatus);
                break;
        }

        //不正解の配置
        switch (hazurepos)
        {

            case 0:
                triangleup.SetActive(!newstatus);
                break;
            case 1:
                triangleleft.SetActive(!newstatus);
                break;
            case 2:
                triangleright.SetActive(!newstatus);
                break;
        }


    }

    void missansset(int start, int hazuregoal)//実質変化なし
    {
        nowpos = hazuregoal;  //現在地(nowpos)を更新

        int rand;
        rand = Random.Range(0, 2);//0か1を生成
        //新しい正解(targetpos)を更新
        if (rand == 0)
        {
            targetpos = nowpos + 1;
            if (targetpos == 3) targetpos = 0;
        }
        else if(rand ==1)
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
    void misstriset()
    {

        //正解の配置
        switch (targetpos)
        {
            case 0:
                triangleup.SetActive(true);
                break;
            case 1:
                triangleleft.SetActive(true);
                break;
            case 2:
                triangleright.SetActive(true);
                break;
        }

        //不正解の配置
        switch (hazurepos)
        {
            case 0:
                triangleup.SetActive(false);
                break;
            case 1:
                triangleleft.SetActive(false);
                break;
            case 2:
                triangleright.SetActive(false);
                break;
        }

    }
}
*/
  