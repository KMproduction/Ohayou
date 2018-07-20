using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class SunPosition : MonoBehaviour
{

    public GameObject kohdohMain;
    public GameObject minikohdohMain;
    public GameObject sun;
    public GameObject sun_ex;
    public GameObject sun_ex_under;
    public GameObject nisshu_ex;
    public GameObject nisshu_ex_under;
    public GameObject minisun;
    public GameObject minisun_ex;
    public GameObject minisun_ex_under;
    public GameObject nisshu;
    public GameObject mininisshu;
    public GameObject mininisshu_ex;
    public GameObject mininisshu_ex_under;
    public GameObject sunsphere;
    public GameObject minisunsphere;
    public GameObject scriptbox;
    Vector3 Sunvector = new Vector3(0, 0, 0);//太陽の南中角度 x=0
    //なんかよくわかんいけど(10,0,0)にしていた
    Vector3 mSunvector = new Vector3(0, 0, 0);//太陽の南中角度 x=0

    float r = 50;//透明半球半径
    public float theta = 0; //冬至なら23.4 
    //赤緯計算式
    float SSI;
    float PE;
    float NK;
    public float X;//通日
    int month;//現在日の月
    int day;
    public float xx;
    public float yy;
    int Dmonth = 1;//指定日の月
    int Dday = 1;
    public Text daytext;
    private void Start()
    {
        // X = 80;   
        Today();
    }
    //2.の部分
    void Update()

    {

        Sunvector.y = -r * (Mathf.Sin(Mathf.Deg2Rad * theta)) * Mathf.Sin(Mathf.Deg2Rad * 33);
        Sunvector.z = -r * (Mathf.Sin(Mathf.Deg2Rad * theta)) * Mathf.Cos(Mathf.Deg2Rad * 33);
        mSunvector.y = -r * (Mathf.Sin(Mathf.Deg2Rad * theta)) * Mathf.Sin(Mathf.Deg2Rad * 33);
        mSunvector.z = -r * (Mathf.Sin(Mathf.Deg2Rad * theta)) * Mathf.Cos(Mathf.Deg2Rad * 33);


        //疑惑深い
        //移動ボタン押したとき、行動の位置がおかしくなる
        //平行移動
        kohdohMain.transform.localPosition = Sunvector;
        minikohdohMain.transform.localPosition = mSunvector/5;//ここをlocalにできれば勝ち

        //OK確定
        sun.transform.localPosition = Sunvector;
        minisun.transform.localPosition = mSunvector;//これにしないと太陽の座標が合わない

        sun_ex.transform.localPosition = Sunvector;
        sun_ex_under.transform.localPosition = Sunvector;
        minisun_ex.transform.localPosition = mSunvector;//これにしないと太陽の座標が合わない
        minisun_ex_under.transform.localPosition = mSunvector;//これにしないと太陽の座標が合わない

        //絶対関係ない
        //OK
        kohdohMain.transform.localScale = new Vector3(100 * Mathf.Cos(Mathf.Deg2Rad * theta), 100 * Mathf.Cos(Mathf.Deg2Rad * theta), 100 * Mathf.Cos(Mathf.Deg2Rad * theta));
        minikohdohMain.transform.localScale = new Vector3(1 * Mathf.Cos(Mathf.Deg2Rad * theta), 1 * Mathf.Cos(Mathf.Deg2Rad * theta), 1 * Mathf.Cos(Mathf.Deg2Rad * theta));
        // 元はこれ、透明半球実装にあたって半径を倍にしたkohdohMain.transform.localScale = new Vector3(50 * Mathf.Cos(Mathf.Deg2Rad * theta), 50 * Mathf.Cos(Mathf.Deg2Rad * theta), 50 * Mathf.Cos(Mathf.Deg2Rad * theta));

        //絶対関係ない
        //中央から太陽がどのくらい離れているか
        nisshu.transform.localScale = new Vector3(Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta));
        nisshu_ex.transform.localScale = new Vector3(Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta));
        nisshu_ex_under.transform.localScale = new Vector3(Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta));
        mininisshu.transform.localScale = new Vector3(Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta));
        mininisshu_ex.transform.localScale = new Vector3(Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta));
        mininisshu_ex_under.transform.localScale = new Vector3(Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Cos(Mathf.Deg2Rad * theta));

        //絶対関係ない
        //球の大きさ
        sunsphere.transform.localScale = new Vector3(6 / Mathf.Cos(Mathf.Deg2Rad * theta), 6 / Mathf.Cos(Mathf.Deg2Rad * theta), 6 / Mathf.Cos(Mathf.Deg2Rad * theta));
        minisunsphere.transform.localScale = new Vector3(6 / Mathf.Cos(Mathf.Deg2Rad * theta), 6 / Mathf.Cos(Mathf.Deg2Rad * theta), 6 / Mathf.Cos(Mathf.Deg2Rad * theta));

        xx = X;
        yy = theta;

    }

    //1.の部分
    public void Summer()
    {
        theta = -23.4f;
        X = 172;
        daytext.text = "6/21(夏至)";

}

    //3.の部分
    public void Winter()
    {
        theta = 23.4f;
        X = 356;
        daytext.text = "12/22(冬至)";
    }

    public void Spring()
    {
        theta = 0;
        X = 80;
        daytext.text = "3/21(春分)";
    }

    public void Today()
        //本日
    {
        month = System.DateTime.Now.Month;
        day = System.DateTime.Now.Day;
        //SSI (視赤緯)の計算
        tuujitu(month,day);//通日計算,X=今日
        SSI = 23.4430f * Mathf.Sin(Mathf.Deg2Rad * (0.9856f * (X - 80f)
            - 3.8100f * Mathf.Sin(0.4825f * (X - 80f))));
        PE = 0.9856f * (X - 80)
            - 3.8100f * Mathf.Sin(0.4825f * (X - 80));

        //NK (南中高度)の計算
        //90 - その場所の緯度　+　視赤緯
        NK = 90 - 33 + SSI;

        //theta(春分南中高度とのズレ)の計算
        //theta = -(NK - (90 - 33/*春分の南中高度*/) );
        theta = -SSI;

        //デバッグ
        daytext.text = month + "/" + day;
    }



    public void MValueChanged(int result)
    {
        Dmonth = result + 1;
    }
    public void DValueChanged(int result)
    {
        Dday = result + 1;
    }
    public void SeasonValueChanged(int result)
    {
        Allseasons d5 = scriptbox.GetComponent<Allseasons>();
        sunrise d4 = scriptbox.GetComponent<sunrise>();

        switch (result)
        {
            case 0:
                Spring();//春分秋分
                d5.notallseasons();
                break;
            case 1:
                Summer();//夏至
                d5.notallseasons();
                break;
            case 2:
                Winter();//冬至
                d5.notallseasons();
                break;
            case 3:
                Today();//本日
                d5.notallseasons();
                break;
            case 4:
                theta = 0;
                X = 80;
                daytext.text = "春夏秋冬";
                d5.seasons();//4seasons
                d4.Shrink();//同期させるのに使う
                //
                break;
        }

    }


    public void when()
        //日時指定
    {
        
        //SSI (視赤緯)の計算
        tuujitu(Dmonth, Dday);//通日計算,X=今日
        SSI = 23.4430f * Mathf.Sin(Mathf.Deg2Rad * (0.9856f * (X - 80f)
            - 3.8100f * Mathf.Sin(0.4825f * (X - 80f))));
        PE = 0.9856f * (X - 80)
            - 3.8100f * Mathf.Sin(0.4825f * (X - 80));

        //NK (南中高度)の計算
        //90 - その場所の緯度　+　視赤緯
        NK = 90 - 33 + SSI;

        //theta(春分南中高度とのズレ)の計算
        //theta = -(NK - (90 - 33/*春分の南中高度*/) );
        theta = -SSI;

        //デバッグ

    }


    void tuujitu(int month, float day)
        //month 月 day 日 = 通日X日
    {

        switch (month)
        {
            case 1:
                X = day;
                break;
            case 2:
                X = day + 31;
                break;
            case 3:
                X = day + 59;
                break;
            case 4:
                X = day + 90;
                break;
            case 5:
                X = day + 120;
                break;
            case 6:
                X = day + 151;
                break;
            case 7:
                X = day + 181;
                break;
            case 8:
                X = day + 212;
                break;
            case 9:
                X = day + 243;
                break;
            case 10:
                X = day + 273;
                break;
            case 11:
                X = day + 304;
                break;
            case 12:
                X = day + 334;
                break;
        }
    }
}
