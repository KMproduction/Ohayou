using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    Transform rectTran;
    public int  hyojiscore;
    public int type;//0…プラス　1…マイナス　2…2倍

    private Text damageText;
    //　テキストの透明度
    private float alpha;
    //　フェードアウトするスピード
    private float fadeOutSpeed = 1.0f;
    //　移動値
    [SerializeField]
    private float moveValue = 0.03f;

    void Start()
    {
        damageText = GetComponentInChildren<Text>();
        //　不透明度は最初は1.0f
        alpha = 1f;
    }

    void LateUpdate()
    {
        //　少しづつ透明にしていく
        switch (type)
        {
            case 0:
            alpha -= fadeOutSpeed * Time.deltaTime;
            //　テキストのcolorを設定
            damageText.text = "+" + hyojiscore;
            damageText.color = new Color(0f, 0f, 0f, alpha);
            transform.position += Vector3.up * moveValue * 20 * Time.deltaTime;
            //        rectTran.DOLocalMove(new Vector3(0, 0, -10), 0.1f);//flick3のみ、親も戻る
            if (alpha < 0f)
            {
                Destroy(gameObject);
            }
                break;
            case 1:
                alpha -= fadeOutSpeed * Time.deltaTime;
                //　テキストのcolorを設定
                damageText.text = "-" + hyojiscore;
                damageText.color = new Color(1f, 0f, 0f, alpha);
                transform.position += Vector3.up * moveValue * 20 * Time.deltaTime;
                //        rectTran.DOLocalMove(new Vector3(0, 0, -10), 0.1f);//flick3のみ、親も戻る
                if (alpha < 0f)
                {
                    Destroy(gameObject);
                }
                break;

            case 2:
                alpha -= fadeOutSpeed * Time.deltaTime;
                //　テキストのcolorを設定
                damageText.text = "×2";
                damageText.fontSize =120;
                damageText.color = new Color(0f, 0f, 1f, alpha);
                transform.position += Vector3.up * moveValue * 20 * Time.deltaTime;
                //        rectTran.DOLocalMove(new Vector3(0, 0, -10), 0.1f);//flick3のみ、親も戻る
                if (alpha < 0f)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}