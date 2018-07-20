using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class timekeeper : MonoBehaviour
{
    public float time = 50;
    public float time_lv1 = 50;
    public float time_lv2 = 40;
    public float time_lv3 = 30;
    public float time_lv4 = 20;
    public float time_sv = 30;
    public bool flag = true;
    public GameObject time_txt;
    public GameObject scriptbox;
    public GameObject result;
    public GameObject playingbutton;

    public bool STARTflag = false;
    public int flag1 = 0;
    public int flag2 = 0;
    public int flag3 = 0;
    public int flagX3 = 0;
    public int flagX2 = 0;
    public int flagX1 = 0;
    public int LASTflag = 0;
    public int sv_phase;

    public bool coolflag = false;
    public int nowlevel;
    public Text t_info;
    public Text t_info2;
    public int dangerflag = 5;
    public float lefttime;
    public bool deadonce=false;

    void Start()
    {
        //初期値60を表示
        //float型からint型へCastし、String型に変換して表示
        //GetComponent<Text>().text = ((int)time).ToString();
        flag = false;
    }

    void Update()
    {
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        ImportantValue dx = scriptbox.GetComponent<ImportantValue>();//スコアを取得
        ScoreHolder sh = scriptbox.GetComponent<ScoreHolder>();
        stop st = scriptbox.GetComponent<stop>();
        if (st.running == false)
        {
            t_info.text = ("一時停止中");
            t_info2.text = ("再開ボタンを押して再開");
        }
        else

            if (scenemover.gamemode() == 0)
        {
            switch (nowlevel)
            {
                case 0:
                    {
                        time_txt.GetComponent<Text>().text = (((int)time_lv1).ToString());
                        t_info.text = ("READY?");
                        t_info2.text = ("上にフリックしてスタート");
                        break;
                    }
                case 1:
                    if (coolflag == true)
                    {
                        time_txt.GetComponent<Text>().text = ("Lv.1");
                    }
                    else
                    {
                        time_txt.GetComponent<Text>().text = (((int)time_lv1).ToString());
                        if (flag == true)
                        {
                            time_lv1 -= Time.deltaTime;
                            t_info.text = ("ROUND1");
                            t_info2.text = (" ");
                        }
                        //時間切れしたら止める
                        if (time_lv1 < 0)
                        {
                            GetComponent<AudioSource>().PlayOneShot(se.levelup);//効果音を鳴らす
                            flag = false;
                            flag1 = 1;
                            nowlevel = 2;
                            coolflag = true;
                            sh.interval();
                        }
                        if (flag == false)
                        {
                            t_info.text = ("ROUND1 READY ?");
                            t_info2.text = ("フリックしてスタート");
                        }
                    }
                    break;

                case 2:
                    if (coolflag == true)
                    {
                        time_txt.GetComponent<Text>().text = ("Lv.2");
                    }
                    else
                    {

                        time_txt.GetComponent<Text>().text = (((int)time_lv2).ToString());

                        if (flag == true)
                        {
                            time_lv2 -= Time.deltaTime;
                            t_info.text = ("ROUND2");
                            t_info2.text = (" ");
                        }
                        //マイナスは表示しない
                        if (time_lv2 < 0)
                        {
                            GetComponent<AudioSource>().PlayOneShot(se.levelup);//効果音を鳴らす
                            flag = false;
                            flag2 = 1;
                            coolflag = true;
                            nowlevel = 3;
                            sh.interval();
                        }

                        if (flag == false)
                        {
                            t_info.text = ("ROUND2 READY ?");
                            t_info2.text = ("フリックしてスタート");
                        }
                    }
                    break;
                case 3:
                    if (coolflag == true)
                    {
                        time_txt.GetComponent<Text>().text = ("Lv.3");
                    }
                    else
                    {

                        time_txt.GetComponent<Text>().text = (((int)time_lv3).ToString());

                        if (flag == true)
                        {
                            t_info.text = ("ROUND3");
                            t_info2.text = (" ");
                            time_lv3 -= Time.deltaTime;
                        }
                        //マイナスは表示しない
                        if (time_lv3 < 0)
                        {
                            GetComponent<AudioSource>().PlayOneShot(se.levelup);//効果音を鳴らす
                            flag = false;
                            flag3 = 1;
                            coolflag = true;
                            nowlevel = 4;
                            sh.interval();
                        }

                        if (flag == false)
                        {
                            t_info.text = ("ROUND3 READY ?");
                            t_info2.text = ("フリックしてスタート");
                        }
                    }
                    break;
                case 4:
                    if (coolflag == true)
                    {
                        time_txt.GetComponent<Text>().text = ("Lv.4");
                    }
                    else
                    {

                        time_txt.GetComponent<Text>().text = (((int)time_lv4).ToString());


                        EScape es = scriptbox.GetComponent<EScape>();
                        if (es.EScapeflag == true)
                        {
                            t_info.color = Color.red;
                            t_info.text = ("CLIMAX!!");
                            t_info2.text = (" ");
                            time_lv4 -= Time.deltaTime;
                        }
                        else

                            if (flag == true)
                        {
                            t_info.text = ("ROUND4");
                            t_info2.text = (" ");
                            time_lv4 -= Time.deltaTime;
                        }

                        if (time_lv4 < 6)
                        {
                            if (dangerflag == 6)
                            {
                                GetComponent<AudioSource>().PlayOneShot(se.danger);//効果音を鳴らす
                                dangerflag = 0;
                            }
                        }
                        //マイナスは表示しない
                        if (time_lv4 < 0)
                        {
                            GetComponent<AudioSource>().PlayOneShot(se.timeup);//効果音を鳴らす
                            time_lv4 = 2;
                            result.SetActive(true);
                            playingbutton.SetActive(false);
                            Resultwriter rw = scriptbox.GetComponent<Resultwriter>();
                            rw.addresult(sh.score, sh.maxcombo, lefttime);
                            nowlevel = 5;
                            coolflag = true;
                        }
                        if (flag == false)
                        {
                            t_info.text = ("ROUND4 READY ?");
                            t_info2.text = ("フリックしてスタート");
                        }
                    }
                    break;
            }
            //コピペはここまで
            if (coolflag == true)
            {
                dx.cooltime -= Time.deltaTime;

                if (dx.cooltime < 0)
                {
                    dx.cooltime = dx.cooltimeholder;
                    if (nowlevel != 5) coolflag = false;
                }
            }
            else
            {
                //ScoreHolder sh = GameObject.Instantiate(ScoreHolder) as GameObject;
                sh.scorebonus_t.text = ("");
            }
            //時間切れでタイトル

            if (time_lv4 < 10)
            {
                time_txt.GetComponent<Text>().color = dx.dangertxtcolor;
            }

            //無事成功
            if (LASTflag == 2)
            {
                if (result.activeSelf == false)
                {
                    //一回だけ処理
                    Debug.Log("o----");
                    nowlevel = 5;
                    lefttime = time_lv4;
                    flag = false;
                    playingbutton.SetActive(false);
                    Resultwriter rw = scriptbox.GetComponent<Resultwriter>();
                    rw.addresult(sh.score, sh.maxcombo, lefttime);
                    result.SetActive(true);

                }
            }
        }

        //*********************************************************************************************************************************************************************************:以下、レベル1
        else if (scenemover.gamemode() == 1)
        {
            //  Debug.Log("おっけー");
            time_txt.GetComponent<Text>().text = (((int)time_sv).ToString());

            sv_phase = sh.sv_level * 5 + nowlevel;



            if (nowlevel == 0)
            {
                t_info.text = ("LEVEL" + (sh.sv_level * 5 + 1) + " READY ?");
                t_info2.text = ("上にフリックしてスタート");
            }
            if (flag == true)//時間計測中
            {
                time_sv -= Time.deltaTime;

                t_info.text = ("LEVEL" + (sh.sv_level * 5 + nowlevel));//現在のレベルは、+(状態)
                t_info2.text = (" ");
                if (sh.left_jiki < 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(se.timeup);
                    result.SetActive(true);
                    Resultwriter rw = scriptbox.GetComponent<Resultwriter>();
                    rw.sv_addresult(sv_phase);
                    playingbutton.SetActive(false);
                    flag = false;
                }
                if (time_sv < 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(se.timeup);
                    result.SetActive(true);
                    Resultwriter rw = scriptbox.GetComponent<Resultwriter>();
                    rw.sv_addresult(sv_phase);
                    playingbutton.SetActive(false);
                    flag = false;
                }

                if (LASTflag == 2)//次のレベルに行こうぜ処理
                {

                    nextlevel();
                    flag = false;//時止め
                }

            }
            //時間切れしたら結果発表
        }

        //クリアしたら次いってみよう

    }
    public void nextlevel()
    {
        FlickController fc = scriptbox.GetComponent<FlickController>();
        ScoreHolder sh = scriptbox.GetComponent<ScoreHolder>();
        Flicked f = scriptbox.GetComponent<Flicked>();
        ImportantValue iv = scriptbox.GetComponent<ImportantValue>();
        BackGround bg = scriptbox.GetComponent<BackGround>();
        unlock ul = scriptbox.GetComponent<unlock>();
        flag1 =flag2=flag3=flagX1=flagX2=flagX3= 0;//ぜーんぶ初期化
        LASTflag = 0;
        nowlevel = 0;
        f.targetpos = 0;//上にスワイプして再開
        sh.sv_level++;
        time_sv=iv.sv_PlayTime[(int)sh.sv_level/2];
        if (sh.sv_level*5>=300)
        {
            time_sv = iv.sv_PlayTime[30];
        }
        time_sv = iv.sv_PlayTime[(int)sh.sv_level / 2];
        Debug.Log("[" + (int)sh.sv_level / 2+"]でいきます");
        iv.colorReset();
        bg.BGchange(sh.sv_level*5);
        ul.triunlock(sh.sv_level * 5);

        switch (sh.sv_level*5)
        {
            case 20:
                sh.left_jiki++;
                break;
            case 40:
                sh.left_jiki++;
                break;
            case 60:
                sh.left_jiki++;
                break;
            case 80:
                sh.left_jiki++;
                break;
            case 100:
                sh.left_jiki++;
                break;
            case 120:
                sh.left_jiki++;
                break;
            case 140:
                sh.left_jiki++;
                break;
            case 160:
                sh.left_jiki++;
                break;
            case 180:
                sh.left_jiki++;
                break;
            case 200:
                sh.left_jiki++;
                break;
            case 220:
                sh.left_jiki++;
                break;
            case 240:
                sh.left_jiki++;
                break;
            case 260:
                sh.left_jiki++;
                break;
            case 280:
                sh.left_jiki++;
                break;
            case 300:
                sh.left_jiki++;
                break;


        }
    }
}
