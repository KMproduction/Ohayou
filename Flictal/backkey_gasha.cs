using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする


public class backkey_gasha : MonoBehaviour
{
    public GameObject gashatop;
    public GameObject result;
    public GameObject scriptbox;
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // エスケープキー取得
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (result.activeSelf)
                {
                    enshutu es = scriptbox.GetComponent<enshutu>();
                    result.SetActive(false);
                    gashatop.SetActive(true);
                    es.triangle_reset();
                }
                else if (gashatop.activeSelf)
                {
                    SceneManager.LoadScene("title");
                }
                else 
                {
                }
                // アプリケーション終了                
            }
        }
    }
}
