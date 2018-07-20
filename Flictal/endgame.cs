using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame : MonoBehaviour {
    public GameObject darkmask;
    public GameObject endmenu;
    public GameObject menu;
    public GameObject setting;
    public GameObject jiki;
    public GameObject ranking;
    public GameObject makename;
    public GameObject rename;//
    public GameObject credit;
    public GameObject licence;
    public GameObject explanation;
    public bool endflag;


	// Use this for initialization
	public void endpushed () {
        endmenu.SetActive(true);
        darkmask.SetActive(true);
        endflag = true;
	}

    public void endcancel()
    {
        endmenu.SetActive(false);
        darkmask.SetActive(false);
        endflag = false;
    }

    public void quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            // エスケープキー取得
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (setting.activeSelf)
                {
                    setting.SetActive(false);
                    menu.SetActive(true);
                }
                else if (jiki.activeSelf)
                {
                    jiki.SetActive(false);
                    menu.SetActive(true);
                }
                else if (ranking.activeSelf)
                {
                    ranking.SetActive(false);
                    menu.SetActive(true);
                }
                else if (makename.activeSelf)
                {
                    makename.SetActive(false);
                    ranking.SetActive(true);
                }
                else if (rename.activeSelf)
                {
                    rename.SetActive(false);
                    setting.SetActive(true);
                }
                else if (credit.activeSelf)
                {
                    credit.SetActive(false);
                    setting.SetActive(true);
                }
                else if (licence.activeSelf)
                {
                    licence.SetActive(false);
                    setting.SetActive(true);
                }
                else if (explanation.activeSelf)
                {
                    explanation.SetActive(false);
                    menu.SetActive(true);
                }
                else if (endflag == false)
                {
                    endpushed();
                }
                else
                {
                    quit();
                }
                // アプリケーション終了                
            }
        }
    }
    
}