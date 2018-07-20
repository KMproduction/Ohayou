using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EScape : MonoBehaviour {
    public GameObject scriptbox;
    public GameObject charge;
    public GameObject chargeesc;
    public GameObject chargeescaping;
    public Ease EaseType;
    public float DurationSeconds;
    public bool EScapeflag=false;
    private bool toriaezuflag=false;
    public CanvasGroup canvasGroup;
    // Use this for initialization
    void tenmetu () {
        canvasGroup.DOFade(0.0f, 0.5f).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);

    }

    public void Escape_clicked()
    {
        timekeeper tk = scriptbox.GetComponent<timekeeper>();//スコアを取得
        SE_container se = scriptbox.GetComponent<SE_container>();//スコアを取得
        if (scenemover.gamemode() == 0)//中央ボタンはでサバモードでは機能しない
        {
            if (tk.flag3 == 2 && tk.flagX3 == 0)
            {
                tk.flagX3 = 1;
                tk.flagX2 = 1;
                tk.flagX1 = 1;
                tk.LASTflag = 1;
                GetComponent<AudioSource>().PlayOneShot(se.EScape);//効果音を鳴らす
                EScapeflag = true;
            }
        }
}

    public void Update()   //三角形の表示
    {
        ImportantValue dx = scriptbox.GetComponent<ImportantValue>();//スコアを取得
        ScoreHolder sh = scriptbox.GetComponent<ScoreHolder>();//スコアを取得
        timekeeper tk = scriptbox.GetComponent<timekeeper>();//スコアを取得


        if (EScapeflag == false)
        {
            if (scenemover.gamemode() == 0) {
                charge.transform.localScale = new Vector3((float)sh.combo % dx.addcombo2 / dx.addcombo2, (float)sh.combo % dx.addcombo2 / dx.addcombo2, (float)sh.combo % dx.addcombo2 / dx.addcombo2);
                if (tk.time_lv4 < 6)
                {
                    chargeesc.SetActive(true);
                    if (toriaezuflag == false)
                    {
                        tenmetu();
                        toriaezuflag = true;
                    }
                }
            }
            else//サバイバル時
            {
                charge.transform.localScale = new Vector3((float)sh.sv_progress % dx.sv_progress_per_level / dx.sv_progress_per_level, (float)sh.sv_progress % dx.sv_progress_per_level / dx.sv_progress_per_level, (float)sh.sv_progress % dx.sv_progress_per_level / dx.sv_progress_per_level);
            }

        }
        else
        {
            charge.SetActive(false);
            chargeesc.SetActive(false);
            chargeescaping.SetActive(true);
        }

        if (tk.LASTflag == 2)
        {
            chargeescaping.SetActive(false); ;
        }
    }
    }

    


