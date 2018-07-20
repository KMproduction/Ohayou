using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasha_SE : MonoBehaviour
{
    public AudioClip buttonSE;
    public AudioClip backSE;
    public AudioClip doGasha;
    public AudioClip SSR;
    public AudioClip SR;
    public AudioClip R;
    public AudioClip N;
    public AudioClip flick;
    public GameObject BGMplace;

    // Use this for initialization
    void Start()
    {
      //  DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void buttonclicked()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonSE);//効果音を鳴らす
    }
    public void doGashaclicked()
    {
        GetComponent<AudioSource>().PlayOneShot(doGasha);//効果音を鳴らす
  //      AudioListener.volume = 0f;
    }

    public void SEswitch(bool value)
    {
        GetComponent<AudioSource>().enabled = value;
        Debug.Log("ＳＥは" + value);
    }
    public void BGMswitch(bool value)
    {
        BGMplace.GetComponent<AudioSource>().enabled = value;
        Debug.Log("BGMは" + value);
    }


}
