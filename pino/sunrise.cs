using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sunrise : MonoBehaviour
{
    public GameObject nisshu;
    public GameObject mininisshu;
    public GameObject nisshuS;//サブ
    public GameObject nisshuW;//サブ
    public GameObject nisshuSM;//サブ
    public GameObject nisshuWM;//サブ
    private Animator _animator;
    private Animator _minianimator;
    private Animator _animatorS;
    private Animator _animatorW;
    private Animator _animatorSM;
    private Animator _animatorWM;
    public GameObject B_shrinking;
    public GameObject B_shrinked;
    public GameObject scriptbox;
    public float risetime_time;//そのまま時間
    public float risetime;//注:南中時刻のずれ含む
    public float settime_time;
    public float settime;
    public bool startflag ;

    void Start()
    {
        startflag = true;
        _animator = nisshu.gameObject.GetComponent<Animator>();
        _minianimator = mininisshu.gameObject.GetComponent<Animator>();
        _animatorS = nisshuS.gameObject.GetComponent<Animator>();
        _animatorSM = nisshuSM.gameObject.GetComponent<Animator>();
        _animatorW = nisshuW.gameObject.GetComponent<Animator>();
        _animatorWM = nisshuWM.gameObject.GetComponent<Animator>();
    }
    //startでいきなりcsv読み込んだら死ぬという謎現象

    void Update()
    {
        if (startflag == true)
        {
            Hinode();
            startflag = false;
        
        }
    }

    public void Hinode()//日の出ボタン押したときの制御
        {
        //無形文化遺産コピー
        //   Debug.Log("おはよう");
        
        csvload d1 = scriptbox.GetComponent<csvload>();
        SunPosition d2 = scriptbox.GetComponent<SunPosition>();
        risetime_time = d1.CSVsunrise((int)d2.X);
        settime_time = d1.CSVsunset((int)d2.X);
        risetime = d1.CSVsunrise((int)d2.X)-d1.CSVuse((int)d2.X);//日の出時刻(秒)を求める
        settime = d1.CSVsunset((int)d2.X) - d1.CSVuse((int)d2.X);//日の出時刻(秒)を求める
        //時間を(日の出時刻)　- (南中時刻のずれ) にずらす
     
        Sunwarp((risetime /86400));//1日=86400秒　アニメーションを飛ばす
        
        Sunrisetime(risetime/3600);//1時間=3600秒 timekeeperに干渉
    }

    public void Hinode_shikatanai()//日の出ボタン押したときの制御
    {

        //無形文化遺産コピー
        csvload d1 = scriptbox.GetComponent<csvload>();
        SunPosition d2 = scriptbox.GetComponent<SunPosition>();
        risetime = d1.CSVsunrise((int)d2.X) - d1.CSVuse((int)d2.X);//日の出時刻(秒)を求める
        settime = d1.CSVsunset((int)d2.X) - d1.CSVuse((int)d2.X);//日の出時刻(秒)を求める
        risetime_time = d1.CSVsunrise((int)d2.X);
        settime_time = d1.CSVsunset((int)d2.X);
        //時間を(日の出時刻)　- (南中時刻のずれ) にずらす

    }


    public void Sunwarp(float time)//1で終了
    {

        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        var m_stateInfo = _minianimator.GetCurrentAnimatorStateInfo(0);
        var SstateInfo = _animatorS.GetCurrentAnimatorStateInfo(0);
        var SM_stateInfo = _animatorSM.GetCurrentAnimatorStateInfo(0);
        var WstateInfo = _animatorW.GetCurrentAnimatorStateInfo(0);
        var WM_stateInfo = _animatorWM.GetCurrentAnimatorStateInfo(0);
        
        var animationHash = stateInfo.shortNameHash;
        var m_animationHash = m_stateInfo.shortNameHash;
        var SanimationHash = SstateInfo.shortNameHash;
        var SM_animationHash = SM_stateInfo.shortNameHash;
        var WanimationHash = WstateInfo.shortNameHash;
        var WM_animationHash = WM_stateInfo.shortNameHash;
        
        //ここで10分ずつくらいずらす必要があるはずだが…

        _animator.Play(animationHash, 0, time);//第三変数,timeが1で一周である
        _minianimator.Play(m_animationHash, 0, time);//
        _animatorS.Play(SanimationHash, 0, time+0.00424f);//夏は6分6秒=366秒進んでいる,366/86400 =0.00423611...
        _animatorSM.Play(SM_animationHash, 0, time + 0.00424f);//★謎…なぜかtime+(366/86400)とするとダメだった
        _animatorW.Play(WanimationHash, 0, time + 0.00640f);//冬は9分13秒=553秒進んでいる  0.006400462962963
        _animatorWM.Play(WM_animationHash, 0, time + 0.00640f);

       // Debug.Log(time);
    }



    public void Sunrisetime(float time)
    {
        new_timekeeper d3 = scriptbox.GetComponent<new_timekeeper>();
        d3.duration = time;
    }

    public void Shrink()
    {
        new_timekeeper d3 = scriptbox.GetComponent<new_timekeeper>();
        Sunwarp(d3.duration/24);
        B_shrinking.SetActive(true);
        Invoke("SDelayMethod", 7f);
    }


    void SDelayMethod()
    {
        B_shrinking.SetActive(false);
        B_shrinked.SetActive(true);
        Debug.Log("Delay call");
    }
}