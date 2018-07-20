using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchScript.Gestures;
using DG.Tweening;

public class titleFlick : MonoBehaviour
{
    public GameObject scriptbox;
    public int dir;
    public GameObject Explanation;

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
        explanataion ex = scriptbox.GetComponent<explanataion>();
        if (!Explanation.activeSelf)
            return;

        var right = new Vector3(1, 0, 0);//右
        var left = new Vector3(-1, 0, 0);//左
        var gesture = sender as FlickGesture;
        var Fvector = gesture.ScreenFlickVector.normalized;
        if (Vector3.Dot(Fvector, left) > 0.5f)
        {
            Debug.Log("next");
            ex.pagenext();
        }
        else if (Vector3.Dot(Fvector, right) > 0.5f)
        {
            ex.pageback();
        }
    }
}