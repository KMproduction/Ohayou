using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TouchScript.Gestures;
using System.IO;

public class enshutu : MonoBehaviour {
    [SerializeField]
    Transform rectTran;
    public GameObject GashaTop;
    public GameObject result;//親となる
    public GameObject scriptbox;
    public GameObject sankaku;
    public GameObject instruction;
    public bool flickflag;
    public int atarinum;//当たった三角の番号
    public Text rarelity_t;
    public Text number_t;
    public Text name_t;
    public Text info_t;
    public Text new_t;
    public int ssr_omomi;//重み〇以下ならssr,今回は10
    public int sr_omomi;//重み〇未満ならsr,今回は10
    public int r_omomi;//重み〇未満ならr,今回は10
    public GameObject Reffect;
    public GameObject SReffect;
    public GameObject SSReffect;
    public Material jikimat;
    public Sprite jikispr;
    public Sprite defospr;
    public Material defomat;
    public string jikiname;

    savedata sv = new savedata();
    string json;


    jikidata_json jd = new jikidata_json();

    //1.ガシャの準備,フリック画面の償還
    public void ReadytoGasha(int num)
    {//引数…当たりのフリック
        atarinum = num;
        GashaTop.SetActive(false);
        instruction.SetActive(true);
        flickflag = true;
        Debug.Log("ready?"+flickflag);

    }
    
    //2.フリック入力受付
    //ここからフリック関係????????????????????????????????????????????期間限定で隠してる
   private void OnEnable()
    {
        GetComponent<FlickGesture>().Flicked += OnFlick;
    }
    private void OnDisable()
    {
        GetComponent<FlickGesture>().Flicked -= OnFlick;
    }
    private void OnFlick(object sender, System.EventArgs e)
    {
        Gasha_SE se = scriptbox.GetComponent<Gasha_SE>();//スコアを取得   

        if (flickflag == false)
            return;
        Debug.Log("you flicked");
        var down = new Vector3(0, -1, 0);//下
        var gesture = sender as FlickGesture;
        string str = "フリック: " + gesture.ScreenFlickVector + " (" + gesture.ScreenFlickTime + "秒)";
        var Fvector = gesture.ScreenFlickVector.normalized;
        //  Vector3.Dot(Fvector, uptri);
        if (Vector3.Dot(Fvector, down) > 0.5f)
        {
            GetComponent<AudioSource>().PlayOneShot(se.flick);//効果音を鳴らす
            GashaDid(atarinum);
            flickflag = false;
        }
        Debug.Log("OnFlickEND");
    }
//ここまでフリック関係



        //ガシャ引いた時の演出
    public void GashaDid(int num)
    {
        instruction.SetActive(false);
        GashaTop.SetActive(false);
        atarinum = num;
        string kari = "no" + atarinum;
        //        Material a=Resources.Load("/Materials/no6", typeof(Material)) as Material;
        if (jikimat = Resources.Load<Material>("Materials/no" + atarinum))
        {
            sankaku.GetComponent<SpriteRenderer>().material = jikimat;
            sankaku.GetComponent<SpriteRenderer>().sprite = defospr;
        }
        else
        {
            sankaku.GetComponent<SpriteRenderer>().material = defomat;
            jikispr = Resources.Load<Sprite>("Materials/no" + atarinum);
            sankaku.GetComponent<SpriteRenderer>().sprite = jikispr;
            Debug.Log("ないじゃｎ");
        }
//        sankaku.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Materials/no"+atarinum);
        var center = new Vector3(0, 0, 0);
        rectTran.DOLocalMove(center, 0.3f);
        rectTran.DOScale(6.0f, 0.4f);
        jikiname = jd.name[atarinum];
        //DelayMethodを3.5秒後に呼び出す
        Invoke("DelayResult", 0.8f);
        
    }

    public void DelayResult()
    {
        Debug.Log("DRstarted");
        Gasha_SE se = scriptbox.GetComponent<Gasha_SE>();//スコアを取得   
        result.SetActive(true);
        if (jd.rarelity[atarinum] <= ssr_omomi)
        {
            rarelity_t.text = "SSレア!!!!!!";
            GetComponent<AudioSource>().PlayOneShot(se.SSR);//効果音を鳴らす
            SSReffect.SetActive(true);
        } else
          if (jd.rarelity[atarinum] <= sr_omomi)
        {
            rarelity_t.text = "Sレア!!";
            GetComponent<AudioSource>().PlayOneShot(se.SR);//効果音を鳴らす
            SReffect.SetActive(true);
        }
        else
        if (jd.rarelity[atarinum] <= r_omomi)
        {
            GetComponent<AudioSource>().PlayOneShot(se.R);//効果音を鳴らす
            rarelity_t.text = "レア";
            Reffect.SetActive(true);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(se.N);//効果音を鳴らす
            rarelity_t.text = "ノーマル";
        }
  //      number_t.text = "No."+jd.materialnum[atarinum].ToString();
        name_t.text = jd.name[atarinum];
        info_t.text = jd.info[atarinum];
        Debug.Log("無事成功");
        //ここから新作かどうかの判定
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        if(sv._jikiflag[atarinum] == false){
            new_t.text = ("new!!");
  
        }
        else
        {
            new_t.text=("");
        }
    }

    //デバッグ用、全部未開放にする
    public void JikiSeal()
    {
        //ここから新作かどうかの判定
        json = File.ReadAllText(Application.persistentDataPath + "/data.json");//読み取ってるよ
        json = encryption.DecryptString(json);
        JsonUtility.FromJsonOverwrite(json, sv);//読み取ったのを変換してるよ
        Debug.Log(json);
        for (int i = 1; i < sv._jikiflag.Count; i++)
        {
            sv._jikiflag[i] = false;
        }

            json = JsonUtility.ToJson(sv);
            Debug.Log(json);
        json = encryption.EncryptString(json);
        File.WriteAllText(Application.persistentDataPath + "/data.json", json);//結局これでよかった
    }

    public void triangle_reset()
    {
       // result.SetActive(false);
        rectTran.transform.localScale=new Vector3(1,1,1);
       rectTran.transform.position = new Vector3(0,10,0);
    }

    public void effectfinish()
    {
        Reffect.SetActive(false);
        SReffect.SetActive(false);
        SSReffect.SetActive(false);
    }

}
