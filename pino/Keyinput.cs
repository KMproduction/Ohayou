using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Keyinput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Change.score -= 1;
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + "TextData.txt", true);//("../TextData.txt", true);// TextData.txtというファイルを新規で用意
            sw.WriteLine("\n********************戻る処理**********************\n");
            sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
            sw.Close();// ファイルを閉じる
        }

    }
}
