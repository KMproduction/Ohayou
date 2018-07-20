using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class scenemover : MonoBehaviour
{
    public static int GAMEMODE = 0;
    public GameObject scriptbox;
    public GameObject admob;
    // Use this for initialization
    public void homeButtonpushed()
    {
        AdMob ad = admob.GetComponent<AdMob>();//スコアを取得
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
                                                                 //se.DestroyReady();
                                                                 //        nextscene = 0;
                                                                 //        SceneManager.LoadScene("loading");
        ad.StopBanner();
        SceneManager.LoadScene("title");//puzzleシーンをロードする
        
    }

    // Update is called once per frame
    public void resetButtonpushed()
    {
        AdMob ad = admob.GetComponent<AdMob>();//スコアを取得
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
                                                                 //  se.DestroyReady();
                                                                 //        nextscene = 1;
                                                                 //        SceneManager.LoadScene("loading");
        ad.StopBanner();
        SceneManager.LoadScene("puzzle");//puzzleシーンをロードする
    }

    public void timeup()
    {
        AdMob ad = admob.GetComponent<AdMob>();//スコアを取得
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
                                                                 //  se.DestroyReady();
//        nextscene = 0;
//        SceneManager.LoadScene("loading");
ad.StopBanner();
        SceneManager.LoadScene("title");//puzzleシーンをロードする
    }
    public static int gamemode()
    {
        return (GAMEMODE);
    }


    // Update is called once per frame
    public void Title_gotoGame()
    {
        //    SceneManager.LoadScene("loading");
        AdMob ad = admob.GetComponent<AdMob>();//スコアを取得
                                                    //        nextscene = 1;
        ad.StopBanner();
        GAMEMODE = 0;
        SceneManager.LoadScene("puzzle");//puzzleシーンをロードする
    }

    public void Title_gotoSurvival()
    {
        //    SceneManager.LoadScene("loading");
        AdMob ad = admob.GetComponent<AdMob>();//スコアを取得
                         //        nextscene = 1;
        ad.StopBanner();
        GAMEMODE = 1;
        SceneManager.LoadScene("survival");//puzzleシーンをロードする
    }

    public void Title_gotoGasha()
    {
        AdMob ad = admob.GetComponent<AdMob>();//スコアを取得
                                                    //      SceneManager.LoadScene("loading");

        //      nextscene = 2;
        ad.StopBanner();
        SceneManager.LoadScene("gasha");//puzzleシーンをロードする
    }

    public void Title_gotoRanking()
    {
        AdMob ad = admob.GetComponent<AdMob>();//スコアを取得
                                               //      SceneManager.LoadScene("loading");

        //      nextscene = 2;
        ad.StopBanner();
        SceneManager.LoadScene("ranking");//puzzleシーンをロードする
    }


}


//場を散り頻る力
//