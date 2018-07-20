using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Shrink_3 : MonoBehaviour
{
    [SerializeField]
    Transform rectTran;
    [SerializeField]
    Transform bigrectTran;
    public int nowpos;
    public int targetpos;
    public int hazurepos;
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

    //引き継ぎ用資料
    public GameObject childnow;
    public GameObject childup;
    public GameObject childleft;
    public GameObject childright;


    //40回目限定
    public bool shrink(int goal)
    {
        ScoreHolder d_score = scriptbox.GetComponent<ScoreHolder>();//スコアを取得

        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        bool hantei = false;//
                            // var lefttri = new Vector3(-0.2166f, -0.125f, -1);
                            //データの引き継ぎ(Lv4状態から)



        Flicked_3 f3 = scriptbox.GetComponent<Flicked_3>();
        targetpos = f3.targetpos;
        nowpos = f3.nowpos;
        hazurepos = f3.hazurepos;
        Debug.Log("OK");
        if (goal == targetpos)//正解
        {
            before_edge.SetActive(false);
            after_edge.SetActive(true);

            GetComponent<AudioSource>().PlayOneShot(se.shrink3);//効果音を鳴らす
            hantei = true;//
            d_score.Shrink();

            //※他の三角形(3_tri)はいらない、inactiveにしてよい
            //""""""""""""""""""""""""""""""遅延して消えた方が美しい
            DOVirtual.DelayedCall(0.1f, () => triangleup.SetActive(false));
            DOVirtual.DelayedCall(0.1f, () => triangleleft.SetActive(false));
            DOVirtual.DelayedCall(0.1f, () => triangleright.SetActive(false));
            //   triangleleft.SetActive(false);
            //   triangleright.SetActive(false);
            //bigbigbigtriamgleが拡大する＝元に戻る


            bigrectTran.DOLocalMove(new Vector3(0, 0, -10), 0.1f);//flick3のみ、親も戻る
            bigrectTran.DOScale(1, 0.1f);
            //  rectTran.DOLocalMove(new Vector3(0, 0, -10), 0.1f);


            relay p0 = childup.GetComponent<relay>();//スコアを取得
            relay p1 = childleft.GetComponent<relay>();//スコアを取得
            relay p2 = childright.GetComponent<relay>();//スコアを取得
            relay px = childnow.GetComponent<relay>();
            bool[] p0pattern = new bool[9];
            bool[] p1pattern = new bool[9];
            bool[] p2pattern = new bool[9];
            bool[] pxpattern = new bool[9];
            Array.Copy(p0.statusback(), p0pattern, 9);
            Array.Copy(p1.statusback(), p1pattern, 9);
            Array.Copy(p2.statusback(), p2pattern, 9);
            Array.Copy(px.statusback(), pxpattern, 9);
            int yabaiflag = 1;

            int key = (int)(childnow.transform.localPosition.x*10)+2;
            //次のプレイヤーの位置(bigbigtriの)場所をじかに求める-2…左　0…上　2…右
            Debug.Log(key+"にいるぞ!!!");
           switch (key)//nowのある場所
                     //	bigbigtriangleがプレイヤー色のままだが、他の子(2_tri)は背景色に戻す
            {
                case 0://左
                    p2.aroundcolorchange();
                    p0.aroundcolorchange();
                    p1.aroundcolorchange();//
                    nowpos = 1;

                    //p0pattern== pxpatternの判定
                    for (int i = 0; i < 9; i++)
                    {
                        if (p0pattern[i] != pxpattern[i])//2なら
                        {
                            targetpos = 2;
                            hazurepos = 0;
                            yabaiflag = 0;
                            break;
                        }
                        if (p2pattern[i] != pxpattern[i])//0なら
                        {
                            targetpos = 0;
                            hazurepos = 2;
                            yabaiflag = 0;
                            break;
                        }
                    }
                    break;
                case 2://上
                    p1.aroundcolorchange();
                    p2.aroundcolorchange();
                    p0.aroundcolorchange();//
                    nowpos = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        if (p2pattern[i] != pxpattern[i])//1なら
                        {
                            targetpos = 1;
                            hazurepos = 2;
                            yabaiflag = 0;
                            break;
                        }
                        if (p1pattern[i] != pxpattern[i])//2なら
                        {
                            targetpos = 2;
                            hazurepos = 1;
                            yabaiflag = 0;
                            break;
                        }
                    }
                    break;
                case 4://右
                    p0.aroundcolorchange();
                    p1.aroundcolorchange();
                    p2.aroundcolorchange();//
                    nowpos = 2;

                    for (int i = 0; i < 9; i++)
                    {
                        if (p1pattern[i] != pxpattern[i])//0なら
                        {
                            targetpos = 0;
                            hazurepos = 1;
                            yabaiflag = 0;
                            break;
                        }
                        if (p0pattern[i] != pxpattern[i])//1なら
                        {
                            targetpos = 1;
                            hazurepos = 0;
                            yabaiflag = 0;
                            break;
                        }
                    }
                    
                    break;
            }
            Debug.Log("targetpos =" + targetpos + ",hazurepos =" + hazurepos + "nowpos=" + nowpos);
            if(yabaiflag == 1)
            {
                Debug.Log("えええええええええええええなんでｓｓｓｓｓっせえええええええええええええええええええええええええええええ");
            }
            

            px.colorchange();

            // move(goal);
            
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(se.hazure);//効果音を鳴らす
            //減点
            d_score.Shrinkmiss();
            d_score.left_jiki--;

            var uptri = new Vector3(0, 0.25f, -5);//
            var lefttri = new Vector3(-0.2166f, -0.125f, -5);//
            var righttri = new Vector3(0.2166f, -0.125f, -5);//
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

        }
        return (hantei);//
    }
    

}
