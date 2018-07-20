using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//5秒で半球を消す
public class expand_disappear : MonoBehaviour {
    public GameObject transparenthemisphere;
    public GameObject B_expanding;
    public GameObject B_expanded;
	
    // Update is called once per frame
    public void expand()
    {
        B_expanding.SetActive(true);
        StartCoroutine("Sample");　//コルーチンを呼び出す

    }

    // コルーチン
    private IEnumerator Sample()
    {


        yield return new WaitForSeconds(9.0f);　 //2秒たってから
        transparenthemisphere.SetActive(false);     //画面遷移
        B_expanding.SetActive(false);
        B_expanded.SetActive(true);

    }
}
