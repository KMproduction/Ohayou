using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//もはや遺産
public class loading : MonoBehaviour {
	// Use this for initialization
	void Start () {

        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
	
	// Update is called once per frame
/*	void Update () {
        //    SceneManager.LoadScene("next_scene");
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
        switch (scenemover.loadnextscene())
        {
            case 0:
                SceneManager.LoadScene("title");
                break;
            case 1:
                SceneManager.LoadScene("puzzle");
                break;
            case 2:
                SceneManager.LoadScene("gasha");
                break;
        }
        
    }

    */
}
