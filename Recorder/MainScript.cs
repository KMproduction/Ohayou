using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {
    

    public int SID;//現在選択中の曲id……ここで管理
    public GameObject addsong;  //楽曲登録画面（プレハブ）
    public GameObject addresult;//結果入力画面（プレハブ
    public GameObject song_select;
    public GameObject recordcheck;
    public GameObject songedit;
    public GameObject history;
    public Camera camera;

    public GameObject canvas;
    private GameObject btn;
    private GameObject btm;
    private GameObject bto;
    public bool resultcheck;//ボタンクリックで変える
    public Text t_modechange;

    public void Start()
    {
        song_select.SetActive(false);
        song_select.SetActive(true);
    }

    //選ばれた曲番号を記憶
    public void GameSelected()
    {
        /*
         * 
         */
    }





    //選曲画面→楽曲追加画面
    public void SongAddSelected()
    {
        
        RectTransform content = canvas.GetComponent<RectTransform>();
        //ボタン(=プレハブから作った新しい登録メニュー)生成
        btn = (GameObject)Instantiate(addsong);
        //ボタンをCanvasの子に設定
        btn.transform.SetParent(content, false);
        //showingcontent = canvas.transform.Find("").gameObject;
        btn.SetActive(true);
//        resultcheck = true;
        song_select.SetActive(false);
    }

    //楽曲追加→選曲
    public void SongAddFinished()
    {
        song_select.SetActive(true);
        Destroy(btn);
    }


    //楽曲選択→結果入力   or     楽曲選択→履歴確認
    //resultcheckフラグ(中央↓クリックでonoff)によって挙動ちぇんじ
    //※onclickのaddlistenerに追加されるので、ボタン押したときの動作にいちいち追加する必要はない
    public void ResultAddSelected(int SID_selected)//引数は曲id
    {
        SID = SID_selected;
        Debug.Log("You choose" + SID);

        if (resultcheck == false) { 
        RectTransform content = canvas.GetComponent<RectTransform>();
        //ボタン(=プレハブから作った新しい登録メニュー)生成
        btm = (GameObject)Instantiate(addresult);
        //ボタンをCanvasの子に設定
        btm.transform.SetParent(content, false);
        btm.SetActive(true);

        song_select.SetActive(false);
            resultcalc d1 = btm.GetComponent<resultcalc>();
            d1.Set();
        }

        else
        {
            RectTransform content = canvas.GetComponent<RectTransform>();
            //ボタン(=プレハブから作った新しい登録メニュー)生成
            bto = (GameObject)Instantiate(recordcheck);
            //ボタンをCanvasの子に設定
            bto.transform.SetParent(content, false);
            bto.SetActive(true);

            song_select.SetActive(false);
            recordreminder d2 = bto.GetComponent<recordreminder>();//なんか参照されてないけどいけてんじゃん
            d2.Remind();
            Debug.Log("aaa"+SID);
        }
    }

    //結果入力→選曲
    public void ResultAddFinished()
    {
        song_select.SetActive(true);
        Destroy(btm);
    }


    public void RecordCheckFinished()
    {
        song_select.SetActive(true);
        Destroy(bto);
    }

    //recordcheck→楽曲編集　※注意、決定、楽曲削除ボタンの時は↓
    public void Recordcheck_to_Edit()
    {
        songedit.SetActive(true);
        bto.SetActive(false);
        json_edit_deletesong d5 = songedit.GetComponent<json_edit_deletesong>();//なんか参照されてないけどいけてんじゃん
        d5.songinfoset();

    }

    //楽曲編集→recordcheck ※注意、モドルボタンの時は↑
    public void Edit_to_Recordcheck()
    {
        songedit.SetActive(false);
        bto.SetActive(true);
 
    }

    //楽曲編集完了したら　楽曲一覧に戻ると同時に更新
    public void Edit_to_songselect()
    {
        songedit.SetActive(false);
        Destroy(bto);
        song_select.SetActive(true);
        Songs_setter d4 = song_select.GetComponent<Songs_setter>();//なんか参照されてないけどいけてんじゃん
        d4.Set_Default();
    }

    //確認→ヒストリー
    public void Recordcheck_to_History()
    {
        history.SetActive(true);
        bto.SetActive(false);
        result_reminder_list d3 = history.GetComponent<result_reminder_list>();//なんか参照されてないけどいけてんじゃん
        d3.Remind();

    }
    //ヒストリー→確認
    public void History_to_Recordcheck()
    {
        history.SetActive(false);
        bto.SetActive(true);
    }





    public void ResultRecord()
    {
        /*
         * 現在のSongIDの結果をログファイルに記入(今は使ってない)
         */
    }

    //選曲場面で　「成績確認」ボタンを押したとき
    public void modechange()
    {
        resultcheck = !resultcheck;
        if (resultcheck)
        {
            t_modechange.text = "確認モード";
            Camera.main.backgroundColor = Color.blue;
            //buttonSerif.GetComponent<Image>().color = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 120.0f / 255.0f);
        }
        else
        {
            t_modechange.text = "入力モード";
            Camera.main.backgroundColor = Color.red;

        }
    }
}
