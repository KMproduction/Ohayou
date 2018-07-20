using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patternset : MonoBehaviour {
    public GameObject triup;
    public GameObject trileft;
    public GameObject triright;
    public GameObject scriptbox;
 

    // Use this for initialization
    public void set (bool[] pattern) {
        triup.SetActive(pattern[0]);
        trileft.SetActive(pattern[1]);
        triright.SetActive(pattern[2]);
    }
    public void setrand(bool[] pattern)
    {
        int rand0 = Random.Range(0, 2);//0か1を生成

        triup.SetActive(RandomBool());
        trileft.SetActive(RandomBool());
        triright.SetActive(RandomBool());
    }

    public void kinsoku(bool[] pattern)//完全に同じ奴が生成されたらやり直し
    {
        while(triup.activeSelf==pattern[0]&&
            trileft.activeSelf==pattern[1]&&
            triright.activeSelf == pattern[2])
        {
            setrand(pattern);
        }
    }

    public static bool RandomBool() //boolのランダム作成
    {
        return Random.Range(0, 2) == 0;
    }


    public void colorchange() //全てが用済みになった後に、色変更
    {
        ImportantValue v0 = scriptbox.GetComponent<ImportantValue>();
        int rand0 = Random.Range(0, 2);//0か1を生成
        if (v0.matFound == true)
        {
            Debug.Log("大丈夫だよね？");
            triup.GetComponent<SpriteRenderer>().material = v0.jikimat;
            triup.GetComponent<SpriteRenderer>().color = Color.white;
            trileft.GetComponent<SpriteRenderer>().material = v0.jikimat;
            trileft.GetComponent<SpriteRenderer>().color = Color.white;
            triright.GetComponent<SpriteRenderer>().material = v0.jikimat;
            triright.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            triup.GetComponent<SpriteRenderer>().color = Color.white;
            triup.GetComponent<SpriteRenderer>().sprite = v0.jikispr;
            trileft.GetComponent<SpriteRenderer>().color = Color.white;
            trileft.GetComponent<SpriteRenderer>().sprite = v0.jikispr;
            triright.GetComponent<SpriteRenderer>().color = Color.white;
            triright.GetComponent<SpriteRenderer>().sprite = v0.jikispr;
        }

/*        triup.GetComponent<SpriteRenderer>().color = v0.mycolor;
        trileft.GetComponent<SpriteRenderer>().color = v0.mycolor;
        triright.GetComponent<SpriteRenderer>().color = v0.mycolor;
        triup.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Materials/no" + v0.jiki);
        trileft.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Materials/no" + v0.jiki);
        triright.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Materials/no" + v0.jiki);
        */
    }

    public void aroundcolorchange() //全てが用済みになった後に、色変更
    {
        ImportantValue v0 = scriptbox.GetComponent<ImportantValue>();
        triup.GetComponent<SpriteRenderer>().material = v0.defomat ;
            trileft.GetComponent<SpriteRenderer>().material = v0.defomat;
            triright.GetComponent<SpriteRenderer>().material = v0.defomat;
        triup.GetComponent<SpriteRenderer>().sprite = v0.defospr;
        trileft.GetComponent<SpriteRenderer>().sprite = v0.defospr;
        triright.GetComponent<SpriteRenderer>().sprite = v0.defospr;
        triup.GetComponent<SpriteRenderer>().color = v0.aroundcolor;
        trileft.GetComponent<SpriteRenderer>().color = v0.aroundcolor;
        triright.GetComponent<SpriteRenderer>().color = v0.aroundcolor;
    }

    public bool[] statusback()
    {
        bool[] status = { triup.activeSelf, trileft.activeSelf, triright.activeSelf };
        return (status);
    }

}
