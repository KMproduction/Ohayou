using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class txt_day : MonoBehaviour {
    private Text targetText;
    int month;
    int day;
    int Dmonth = 1;
    int Dday = 1;
   
    public void Today()
        //「季節変更」>「本日」ボタンを押すと発動、詳細情報の日を変更
    {
        month = System.DateTime.Now.Month;
        day = System.DateTime.Now.Day;
        this.targetText = this.GetComponent<Text>();
        this.targetText.text =month + "/" +day;

    }


    public void MValueChanged(int result)
    {
        Dmonth = result + 1;
    }
    public void DValueChanged(int result)
    {
        Dday = result + 1;
    }
    public void When()
    //「指定日」ボタンで発動
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = Dmonth + "/" + Dday;
    }

}
