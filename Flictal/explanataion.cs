using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class explanataion : MonoBehaviour {
    private int nowpage;
    public Vector3 nowpos;
    [SerializeField]
    RectTransform Allzu;
    private GameObject showingcontent;
    public GameObject Oya;
    public GameObject scriptbox;
    public Color c1;
    public Color c2;

    // Use this for initialization
    void Start () {
        nowpage = 1;
	}
	
	// Update is called once per frame
	public void gotopage(int targetpos) {
        /*    case 1:
                Allzu.DOLocalMove(new Vector3(3500,0,0), 0.1f);
                nowpage = 1;
                break;*/
        nowpage = targetpos;
        circlepainter(nowpage);
        Allzu.DOLocalMove(new Vector3(-1000 * nowpage + 5500, 0, 0), 0.1f);
        Title_SE se = scriptbox.GetComponent<Title_SE>();//スコアを取得   
        GetComponent<AudioSource>().PlayOneShot(se.flick);//効果音を鳴らす
    }

    public void pagenext()
    {
        if (nowpage != 10)
        {
            nowpage++;
            circlepainter(nowpage);
            Allzu.DOLocalMove(new Vector3(-1000*nowpage+5500, 0, 0), 0.1f); ;
            Title_SE se = scriptbox.GetComponent<Title_SE>();//スコアを取得   
            GetComponent<AudioSource>().PlayOneShot(se.flick);//効果音を鳴らす
        }

    }

    public void pageback()
    {
        if (nowpage != 1)
        {
            nowpage--;
            circlepainter(nowpage);
            Allzu.DOLocalMove(new Vector3(-1000 * nowpage + 5500, 0, 0), 0.1f);
            Title_SE se = scriptbox.GetComponent<Title_SE>();//スコアを取得   
            GetComponent<AudioSource>().PlayOneShot(se.flick);//効果音を鳴らす
        }

    }

    public void circlepainter(int page)
    {
        int i;
        for (i = 1; i <= 10; i++)
        {
            showingcontent = Oya.transform.Find("Button (" + i + ")").gameObject; //まずitem (i)を捕獲※activeでないので親から辿る必要あり
            Debug.Log("nihhj");
            if (i == page)
            {
                showingcontent.GetComponent<Image>().color = Color.black;
            }
            else
            {
                if (i < 9) {
                    showingcontent.GetComponent<Image>().color = c1;
                }
                else
                {
                    showingcontent.GetComponent<Image>().color = c2;
                }
            }
        }
    }

}

