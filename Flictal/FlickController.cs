using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using DG.Tweening;

public class FlickController : MonoBehaviour
{
    public GameObject scriptbox;
    public int goal;
    public GameObject zentai;
 

    private void OnEnable()
    {
        GetComponent<FlickGesture>().Flicked += OnFlick;
    }
    private void OnDisable()
    {
        GetComponent<FlickGesture>().Flicked -= OnFlick;
    }

    // フリックジェスチャーが成功すると呼ばれるメソッド
    private void OnFlick(object sender, System.EventArgs e)
    {
        timekeeper dt = scriptbox.GetComponent<timekeeper>();
        ImportantValue iv = scriptbox.GetComponent<ImportantValue>();
        ScoreHolder sh = scriptbox.GetComponent<ScoreHolder>();
        stop st = scriptbox.GetComponent<stop>();
        if (dt.time == 0&& scenemover.gamemode() == 0)
            return;
        if (dt.time_lv4 <= 0&& scenemover.gamemode() == 0)
            return;
        if (dt.coolflag == true&& scenemover.gamemode() == 0)
            return;
        if (dt.time_sv <= 0&& scenemover.gamemode() == 1)
            return;
        if (sh.left_jiki < 0&& scenemover.gamemode() == 1)
            return;
        if (st.running== false)
            return;

        ScoreHolder d_score = scriptbox.GetComponent<ScoreHolder>();

        var up = new Vector3(0, 1, 0);//上
        var left = new Vector3(-0.866f, -0.5f, 0);//左下
        var right = new Vector3(0.866f, -0.5f, 0);//右上


        var gesture = sender as FlickGesture;
        //        string str = "フリック: " + gesture.ScreenFlickVector + " (" + gesture.ScreenFlickTime + "秒)";
        var Fvector = gesture.ScreenFlickVector.normalized;
        //  Vector3.Dot(Fvector, uptri);
        //$$遊び
        switch (iv.jiki)
        {
            case 30:
                zentai.transform.DOShakePosition(0.2f, 1, 10, 90, false, true);
                break;
            case 31:
                zentai.transform.DOShakePosition(1f, 10, 100, 90, false, true);
                break;
        }



        if (Vector3.Dot(Fvector, up) > 0.5f)
        {
            goal = 0;
        }
        if (Vector3.Dot(Fvector, left) > 0.5f)
        {
            goal = 1;
        }
        if (Vector3.Dot(Fvector, right) > 0.5f)
        {
            goal = 2;
        }

        Flicked f0 = scriptbox.GetComponent<Flicked>();
        Flicked_1 f1 = scriptbox.GetComponent<Flicked_1>();
        Flicked_2 f2 = scriptbox.GetComponent<Flicked_2>();
        Flicked_3 f3 = scriptbox.GetComponent<Flicked_3>();
        Shrink_3 s3 = scriptbox.GetComponent<Shrink_3>();
        shrink_2 s2 = scriptbox.GetComponent<shrink_2>();
        shrink_1 s1 = scriptbox.GetComponent<shrink_1>();
        shrink_0 s0 = scriptbox.GetComponent<shrink_0>();

        if (dt.nowlevel == 0)//ホントに最初
        {
            if (f0.firstmove(goal))
            {
                dt.flag = true;
                dt.nowlevel = 1;
            }
        }

        else if (dt.flag1 == 0)//最初
        {
            f0.move(goal);
        }
        else if (dt.flag1 == 1)
        {
            if (f1.firstmove(goal))
                dt.flag1 = 2;
            dt.flag = true;
         
        }
        else if (dt.flag2 == 0)
        {
            f1.move(goal);
        }
        else if (dt.flag2 == 1)
        {
            if (f2.firstmove(goal))
                dt.flag2 = 2;
            dt.flag = true;
         
        }
        else if (dt.flag3 == 0)
        {
            f2.move(goal);
        }
        else if (dt.flag3 == 1)
        {
            if (f3.firstmove(goal))
                dt.flag3 = 2;
            dt.flag = true;
         
        }
        else if (dt.flagX3 == 0)
        {
            f3.move(goal);
        }
        else if (dt.flagX3 == 1)
        {
            if (s3.shrink(goal))
                dt.flagX3 = 2;
        }
        else if (dt.flagX2 == 1)
        {
            if (s2.shrink(goal))
                dt.flagX2 = 2;
        }
        else if (dt.flagX1 == 1)
        {
            if (s1.shrink(goal))
                dt.flagX1 = 2;
        }
        else if (dt.LASTflag == 1)
        {
            if (s0.shrink(goal))
                dt.LASTflag = 2;
        }
        else
        {
            //            Debug.Log("もうねえ");
        }
        int var;
        //nextlevel()で全部0に戻される
    }
}