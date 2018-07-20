using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class gotogame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Buttonpushed()
    {
        SceneManager.LoadScene("puzzle");//puzzleシーンをロードする
    }
    public void SurvivalButtonpushed()
    {
        SceneManager.LoadScene("puzzle");//puzzleシーンをロードする
    }
    public void gashaButtonpushed()
    {
        SceneManager.LoadScene("gasha");//puzzleシーンをロードする
    }
}