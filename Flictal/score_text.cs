using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_text : MonoBehaviour {
    private Text targetText;
    public  Text targetText_r;
    public Text comboText;
    public Text MaxcomboText;
    public Text lefttimeText;
    public Text ResultTitleText;
    //   public GameObject resulttext;
    public GameObject scriptbox;
    public GameObject failinfo;
    public GameObject lefttime;
   
    // Use this for initialization
    void Start () {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text ="0" ;
    }

    void Update()
    {
        ScoreHolder d1 = scriptbox.GetComponent<ScoreHolder>();
        timekeeper tk = scriptbox.GetComponent<timekeeper>();//スコアを取得
        if (scenemover.gamemode() == 0)
        {
            if (tk.LASTflag == 2)
            {
                ResultTitleText.text = ("ゲームクリア!!");
                lefttime.SetActive(true);
                failinfo.SetActive(false);
                lefttimeText.text = (tk.lefttime.ToString("##.##") + "秒");
            }
            else
            {
                ResultTitleText.text = ("時間切れ…");
                lefttime.SetActive(false);
                failinfo.SetActive(true);
            }
            this.targetText.text = (d1.score + "");

            targetText_r.text = (d1.score + "");
            comboText.text = (d1.combo + " ");
            MaxcomboText.text = (d1.maxcombo + " ");
        }
        else if(scenemover.gamemode() == 1)//サバイバル
        {
            ResultTitleText.text = ("ゲーム終了");
            lefttime.SetActive(false);
            failinfo.SetActive(true);

            this.targetText.text = (tk.sv_phase + "");
            targetText_r.text = (tk.sv_phase + "");
            comboText.text = (d1.left_jiki + " ");
            MaxcomboText.text = (tk.sv_phase*30 + " ");

        }
    }
}
