using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextsNOWscript : MonoBehaviour
{
    private Text targetText;
    int month;
    int day;

    void Update()
    //「季節変更」>「本日」ボタンを押すと発動、詳細情報の日を変更
    {
        month = System.DateTime.Now.Month;
        day = System.DateTime.Now.Day;
        this.targetText = this.GetComponent<Text>();
        this.targetText.text ="本日\n"+ month + "/" + day;

    }
}
