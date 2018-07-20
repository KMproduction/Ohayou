using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TriangleButton : Button, ICanvasRaycastFilter
{
    [SerializeField]
    float radius = 500f;
    Vector3 a = new Vector3(-242, 140, 0);//140,-242
    Vector3 b = new Vector3(242, 140, 0);//140,242
    Vector3 c = new Vector3(0,-250, 0);


    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        Vector2 xx = transform.InverseTransformPoint(sp);
        bool inside = false;
        float magnification = (float)Screen.height / 1920;//FullHDからみた縦横比
        Vector3 p = new Vector3(xx.x, xx.y, 0);
        Vector3 crossA = Vector3.Cross(a - c, p - a) * magnification;//CA×AP
        Vector3 crossB = Vector3.Cross(c - b, p - c) * magnification;//BC×CP
        Vector3 crossC = Vector3.Cross(b - a, p - b) * magnification;//AB×BP
        if (Vector3.Dot(crossA, crossB) > 0.99f && Vector3.Dot(crossB, crossC) > 0.99f && Vector3.Dot(crossC, crossA) > 0.99f)
        {
            inside = true;
        }
        return (inside);
    }


    //ベクトル引
}

/*
 * canvas scalerに追従していないどうしよう
 * 　ここで、canvas scaler の比率はScr3een.width.1080でとれることに注目
 * 　中央は、この式でわかった
 * 　        Vector2 xx = transform.InverseTransformPoint(sp);

    （魔法の呪文）
    今回は三角形が幸いにも中央なのでなんとかなってラッキー（アンカーは真ん中に白）
    最後の疑問…横持だとできないのはなぜ？
    */