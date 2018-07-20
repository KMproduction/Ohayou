using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timekeeper : MonoBehaviour {
    public float time;
    float duration;
    float duration_fixed;
    //アニメーション開始からの時間、ずれが加わるはず
    public float speed = 2;//時間(sliderの値)、普通は2
    public Text timetext;

    public GameObject sli;
    public GameObject nisshu;
    public GameObject scriptbox;//sunposition欲しいな
    public float speedfix = 0.5f;//speedchangerと連動すべし
    public int stopflag = 0;
    float rememberspeed = 1;

    float zure;//南中時刻からのずれ(秒)

    // Use this for initialization
    void Start () {
        duration = 0;//今の時間
        speed = 0;//謎、これがないとspeed=1になってる
        zurecalc();
    }
	
	// Update is called once per frame
	void Update () {//時間計算

        //無形文化遺産、別スクリプト参照
        

        duration_fixed = duration + zure/3600;//ずれ補正後の時間（表示用）を求める
        //duration_fixedが0:00～23:59になるように以下4行
        
        //日の出で時間をぴったり指定するので、あとはどうにでもなる
        if (duration_fixed < 0)
            duration_fixed += 24;
        if (duration_fixed > 24)
            duration_fixed -= 24;

        duration += Time.deltaTime * speed *speedfix;
        //timetext.text = duration + " ";
        if (duration_fixed < 23.5) timetext.text = Mathf.Floor(duration_fixed) + "時"+ Mathf.Floor((duration_fixed-Mathf.Floor(duration_fixed))*60 ) + "分";
        // Mathf.RoundToInt(duration)+"時" ;
        else timetext.text = "00時";
        if (duration > 24) duration = 0;//24でdurationをリセット


    }

    public void zurecalc()
    {
        csvload d1 = scriptbox.GetComponent<csvload>();
        SunPosition d2 = scriptbox.GetComponent<SunPosition>();
        zure = d1.CSVuse((int)d2.X);//ずれ(秒)を求める
 
    }

    public void stop()
    {
        //stopフラグを立てて停止
        stopflag = 1;
        speed=0;
    }

    public void restart()
    {
        //stopフラグを折って覚えていたスピードで再開
        stopflag = 0;
        speed = rememberspeed;
    }
}
