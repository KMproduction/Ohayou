using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {
    public Camera mcamera;
    public GameObject background;
    public Color _10;
    public Color _20;
    public Color _30;
    public Sprite _40;
    public Sprite _50;
    public Sprite _60;
    public Sprite _70;
    public Sprite _80;
    public Sprite _90;
    public Sprite _100;
    public Color _110;
    public Color _120;
    public Color _130;
    public Color _140;
    public Sprite _150;
    // Use this for initialization
    public void BGchange (int level) {
        switch (level)
        {
            case 10:
                mcamera.backgroundColor = _10;
                break;
            case 20:
                mcamera.backgroundColor = _20;
                break;
            case 30:
                mcamera.backgroundColor = _30;
                break;
            case 40:
                background.SetActive(true);
                background.GetComponent<SpriteRenderer>().sprite = _40;
                break;
            case 50:
                background.GetComponent<SpriteRenderer>().sprite = _50;
                break;
            case 60:
                background.GetComponent<SpriteRenderer>().sprite = _60;
                break;
            case 70:
                background.GetComponent<SpriteRenderer>().sprite = _70;
                break;
            case 80:
                background.GetComponent<SpriteRenderer>().sprite = _80;
                break;
            case 90:
                background.GetComponent<SpriteRenderer>().sprite = _90;
                break;
            case 100:
                background.GetComponent<SpriteRenderer>().sprite = _100;
                break;
            case 110:
                background.SetActive(false);
                mcamera.backgroundColor = _110;
                break;
            case 120:
                mcamera.backgroundColor = _120;
                break;
            case 130:
                mcamera.backgroundColor = _130;
                break;
            case 140:
                mcamera.backgroundColor = _140;
                break;
            case 150:
                background.SetActive(true);
                background.GetComponent<SpriteRenderer>().sprite = _150;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
