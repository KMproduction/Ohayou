using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class new_speedchanger : MonoBehaviour
{
 
    public GameObject nisshu;
    public GameObject mininisshu;
    public GameObject nisshuS;//サブ
    public GameObject nisshuW;//サブ
    public GameObject nisshuSM;//サブ
    public GameObject nisshuWM;//サブ
    public GameObject text;
    public GameObject b_normal;
    public GameObject b_fast;
    public float speedfix = 0.5f;//timekeeperと連動すべし
    float rememberspeed = 1;

    private Animator _animator;
    private Animator _minianimator;
    private Animator _animatorS;
    private Animator _animatorW;
    private Animator _animatorSM;
    private Animator _animatorWM;
    private Slider slider;
    private Text targetText;
    // Use this for initialization

    void Start()
    {
        //stopフラグを立てて停止
        speedchange(0);
    }



    public void speedchange(float val)
    {
        _animator = nisshu.gameObject.GetComponent<Animator>();
        _minianimator = mininisshu.gameObject.GetComponent<Animator>();
        _animatorS = nisshuS.gameObject.GetComponent<Animator>();
        _animatorW = nisshuW.gameObject.GetComponent<Animator>();
        _animatorSM = nisshuSM.gameObject.GetComponent<Animator>();
        _animatorWM = nisshuWM.gameObject.GetComponent<Animator>();
        _animator.speed = val * speedfix;//slider.value;
        _minianimator.speed = val * speedfix;//slider.value;
        _animatorS.speed = val * speedfix;//slider.value;
        _animatorW.speed = val * speedfix;//slider.value;
        _animatorSM.speed = val * speedfix;//slider.value;
        _animatorWM.speed = val * speedfix;//slider.value;

      //  this.targetText = text.GetComponent<Text>();
      //  this.targetText.text = (val * 0.5f) + "倍速";
    }
    
    public void fast()
    {
        speedchange(3f);
    }
    public void normal()
    {
        speedchange(1.5f);
    }
    public void stop()
    {
        speedchange(0);
    }

}
