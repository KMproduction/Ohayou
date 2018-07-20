using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sv_ScoreHolder : MonoBehaviour
{

    public int score;
    public int combo;
    public int maxcombo;
    public float time;
    int scorebefore;
    public int progress;//

    public Text scorebonus_t;

    public GameObject scriptbox;
    public GameObject canvas;
    [SerializeField]
    private GameObject scoreUI;


    // Use this for initialization
    void Start()
    {
        score = 0;
    }


    public void comboadd()
    {
        ImportantValue dx = scriptbox.GetComponent<ImportantValue>();
        timekeeper tk = scriptbox.GetComponent<timekeeper>();
        SE_container se = scriptbox.GetComponent<SE_container>();//
        if (scenemover.gamemode() == 0)
        {
            combo++;
            if (maxcombo < combo)
            {
                maxcombo = combo;
            }
            int plusscore = 0;
            switch (tk.nowlevel)
            {
                case 1:
                    if (combo < dx.combobonus_lv1)
                    {
                        plusscore = combo;
                    }
                    else
                    {
                        plusscore = dx.combobonus_lv1;
                    }

                    break;
                case 2:
                    if (combo * 2 < dx.combobonus_lv2)
                    {
                        plusscore = combo * 2;
                    }
                    else
                    {
                        plusscore = dx.combobonus_lv2;
                    }
                    break;

                case 3:
                    if (combo * 3 < dx.combobonus_lv3)
                    {
                        plusscore = combo * 3;
                    }
                    else
                    {
                        plusscore = dx.combobonus_lv3;
                    }

                    break;
                case 4:
                    if (combo * 4 < dx.combobonus_lv4)
                    {
                        plusscore = combo * 4;
                    }
                    else
                    {
                        plusscore = dx.combobonus_lv4;
                    }
                    break;
            }
            // tk.time = tk.time + dx.addtime1;
            score = score + plusscore;

            GameObject score_UI = GameObject.Instantiate(scoreUI) as GameObject;
            score_UI.transform.SetParent(canvas.transform);
            score_UI.GetComponent<RectTransform>().localPosition = new Vector3(-380, 200, 0);
            ScoreUI ui = score_UI.GetComponent<ScoreUI>();//スコアを取得
            ui.hyojiscore = plusscore;



            //時間延長工作

            if (combo % dx.addcombo1 == 0 && (combo % dx.addcombo2 != 0))//5コンボごとに時間追加
            {
                GetComponent<AudioSource>().PlayOneShot(se.Fivecombo);//効果音を鳴らす
                switch (tk.nowlevel)
                {
                    case 1:
                        tk.time_lv1 = tk.time_lv1 + dx.addtime1;
                        break;
                    case 2:
                        tk.time_lv2 = tk.time_lv2 + dx.addtime1;
                        break;

                    case 3:
                        tk.time_lv3 = tk.time_lv3 + dx.addtime1;
                        break;
                    case 4:
                        tk.time_lv4 = tk.time_lv4 + dx.addtime1;
                        break;
                }
                // tk.time = tk.time + dx.addtime1;
            }
            if (combo % dx.addcombo2 == 0)//10コンボごとに時間追加
            {
                GetComponent<AudioSource>().PlayOneShot(se.Tencombo);//効果音を鳴らす
                switch (tk.nowlevel)
                {
                    case 1:
                        tk.time_lv1 = tk.time_lv1 + dx.addtime2;
                        break;
                    case 2:
                        tk.time_lv2 = tk.time_lv2 + dx.addtime2;
                        break;

                    case 3:
                        tk.time_lv3 = tk.time_lv3 + dx.addtime2;
                        break;
                    case 4:
                        tk.time_lv4 = tk.time_lv4 + dx.addtime2;
                        break;
                }
                tk.time = tk.time + dx.addtime2;
            }
        }
        //ここからサバイバル
        //ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        else if(scenemover.gamemode() == 1)
        {


            progress++;
            if (progress== dx.sv_progress_per_level)//5コンボごとに時間追加
            {
                GetComponent<AudioSource>().PlayOneShot(se.Fivecombo);//効果音を鳴らす

                switch (tk.nowlevel)
                {
                    case 1:
                        tk.flag1 = 1;
                        break;
                    case 2:
                        tk.flag2 = 1;
                        break;
                    case 3:
                        tk.flag3 = 1;
                        break;
                    case 4:
                        tk.flagX3 = 1;
                        tk.flagX2 = 1;
                        tk.flagX1 = 1;
                        break;
                }
                progress = 0;
                // tk.time = tk.time + dx.addtime1;
            }

        }

    }


    public void interval()
    {
        ImportantValue dx = scriptbox.GetComponent<ImportantValue>();//スコアを取得
        timekeeper tk = scriptbox.GetComponent<timekeeper>();//スコアを取得
        int bonus_s;
        int bonus_c;
        switch (tk.nowlevel)
        {
            case 1:

                break;
            case 2:

                bonus_s = (int)(score * dx.timebonus_score_lv1);
                scorebonus_t.text = ("+" + bonus_s + "秒");
                tk.time_lv2 = tk.time_lv2 + bonus_s;
                scorebefore = score;
                break;
            case 3:
                bonus_s = (int)((score - scorebefore) * dx.timebonus_score_lv2);
                scorebonus_t.text = ("+" + bonus_s + "秒");
                tk.time_lv3 = tk.time_lv3 + bonus_s;
                scorebefore = score;
                break;
            case 4:
                bonus_s = (int)((score - scorebefore) * dx.timebonus_score_lv3);
                scorebonus_t.text = ("+" + bonus_s + "秒");
                tk.time_lv4 = tk.time_lv4 + bonus_s;
                scorebefore = score;
                break;
        }
    }

    public void miss()
    {
        ImportantValue dx = scriptbox.GetComponent<ImportantValue>();//スコアを取得
        timekeeper tk = scriptbox.GetComponent<timekeeper>();//スコアを取得
        score = score - tk.nowlevel;
        GameObject score_UI = GameObject.Instantiate(scoreUI) as GameObject;
        score_UI.transform.parent = canvas.transform;
        score_UI.GetComponent<RectTransform>().localPosition = new Vector3(-380, 200, 0);
        ScoreUI ui = score_UI.GetComponent<ScoreUI>();//スコアを取得
        ui.hyojiscore = tk.nowlevel;
        ui.type = 1;

    }



    public void Shrink()
    {
        score = score * 2;
        GameObject score_UI = GameObject.Instantiate(scoreUI) as GameObject;
        score_UI.transform.parent = canvas.transform;
        score_UI.GetComponent<RectTransform>().localPosition = new Vector3(-380, 200, 0);
        ScoreUI ui = score_UI.GetComponent<ScoreUI>();//スコアを取得
        ui.type = 2;

    }
}
