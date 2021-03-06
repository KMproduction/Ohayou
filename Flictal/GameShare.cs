﻿using System;
using System.IO;
using UnityEngine;
using SocialConnector;
using System.Collections;

public class GameShare : MonoBehaviour
{
    public GameObject scriptbox;
    public void free_Share()
    {
        ScoreHolder sh = scriptbox.GetComponent<ScoreHolder>();//スコアを取得   
        string text = "フリーモードで「" + sh.score + "」点を出した！\n新感覚三角パズルアクション・フリクタル\n#Flictal ";
        string URL = "https://play.google.com/store/apps/details?id=com.KMpro.Flictal";
        SocialConnector.SocialConnector.Share(text, URL);
        //      SocialConnector.SocialConnector.Share(en.jikiname);
    }

    public void sv_Share()
    {
        timekeeper tk = scriptbox.GetComponent<timekeeper>();//スコアを取得   
        string text = "サバイバルモードでLv「" + tk.sv_phase + "」に到達した！\n新感覚三角パズルアクション・フリクタル\n#Flictal ";
        string URL = "https://play.google.com/store/apps/details?id=com.KMpro.Flictal";
        SocialConnector.SocialConnector.Share(text, URL);
        //      SocialConnector.SocialConnector.Share(en.jikiname);
    }


    IEnumerator ShareScreenShot(string triangle)
    {
        //スクリーンショット画像の保存先を設定。ファイル名が重複しないように実行時間を付与
        string fileName = String.Format("image_{0:yyyyMMdd_Hmmss}.png", DateTime.Now);
        string imagePath = Application.persistentDataPath + "/" + fileName;

        //スクリーンショットを撮影
        ScreenCapture.CaptureScreenshot(fileName);
        yield return new WaitForEndOfFrame();

        // Shareするメッセージを設定
        string text = "三角くじで「" + triangle + "」を手に入れた！\n新感覚三角パズルアクション・フリクタル\n#Flictal ";
        string URL = "https://play.google.com/store/apps/details?id=com.KMpro.Flictal";
        yield return new WaitForSeconds(1);

        //Shareする
        SocialConnector.SocialConnector.Share(text, URL);
        //               SocialConnector.SocialConnector.Share(text, URL, imagePath);
    }
}