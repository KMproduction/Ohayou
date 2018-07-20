using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedchanger : MonoBehaviour {
    public GameObject sli;
    public GameObject nisshu;
    public GameObject nisshuS;//サブ
    public GameObject nisshuW;//サブ
    public GameObject text;
    public float speedfix = 0.5f;//timekeeperと連動すべし
    public int stopflag = 0;
    float rememberspeed = 1;

    private Animator _animator;
    private Animator _animatorS;
    private Animator _animatorW;
    private Slider slider;
    private Text targetText;
    // Use this for initialization

    void Start()
    {
        //stopフラグを立てて停止
        speedchange(0);
    }

    public void SliderValueChanged(float val)
    {
        //一時停止中…スピードを覚えるだけ
        //再生中…スピードを覚えて速度変更
        //val =2 のとき speedchange(2) =「1倍速」
        if (stopflag == 0)//
        {
            speedchange(val);
        }
        rememberspeed = val;//覚えておく
    }

    public void stop()
    {
        //stopフラグを立てて停止
        stopflag = 1;
        speedchange(0);
    }

    public void speedchange(float val)
    {
        _animator = nisshu.gameObject.GetComponent<Animator>();
        _animator.speed = val * speedfix;//slider.value;
        _animatorS = nisshuS.gameObject.GetComponent<Animator>();
        _animatorS.speed = val * speedfix;//slider.value;
        _animatorW = nisshuW.gameObject.GetComponent<Animator>();
        _animatorW.speed = val * speedfix;//slider.value;
        this.targetText = text.GetComponent<Text>();
        this.targetText.text = (val * 0.5f) + "倍速";
    }

    public void restart()
    {
        //stopフラグを折って覚えていたスピードで再開
        stopflag = 0;
        speedchange(rememberspeed);
    }


}
