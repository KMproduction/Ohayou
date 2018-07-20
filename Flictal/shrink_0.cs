using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class shrink_0 : MonoBehaviour
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

    public int score = 0;

    //三角形の状態


    public bool shrink(int goal)
    {
        ScoreHolder d_score = scriptbox.GetComponent<ScoreHolder>();//スコアを取得
        

        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        ImportantValue v0 = scriptbox.GetComponent<ImportantValue>();

        bool hantei = false;//
                            // var lefttri = new Vector3(-0.2166f, -0.125f, -1);
                            //データの引き継ぎ(Lv4状態から)



        shrink_1 s1 = scriptbox.GetComponent<shrink_1>();
        targetpos = s1.targetpos;
        nowpos = s1.nowpos;
        hazurepos = s1.hazurepos;
        Debug.Log("OK");
        if (goal == targetpos)//正解
        {

            d_score.Shrink();
            GetComponent<AudioSource>().PlayOneShot(se.clear);//効果音を鳴らす
            hantei = true;//

            //  targetpos = 0;//次につなげていく

            //※他の三角形(3_tri)はいらない、inactiveにしてよい
            //""""""""""""""""""""""""""""""遅延して消えた方が美しい
            //         triangleup.SetActive(false);
            //         triangleleft.SetActive(false);
            //         triangleright.SetActive(false);
            DOVirtual.DelayedCall(0.1f, () => triangleup.SetActive(false));
            DOVirtual.DelayedCall(0.1f, () => triangleleft.SetActive(false));
            DOVirtual.DelayedCall(0.1f, () => triangleright.SetActive(false));
            //bigbigbigtriamgleが拡大する＝元に戻る

            bigrectTran.DOLocalMove(new Vector3(0, 0, -10), 0.1f);//flick3のみ、親も戻る
            bigrectTran.DOScale(1, 0.1f);

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
