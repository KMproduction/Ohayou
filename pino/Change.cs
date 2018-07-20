using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Change : MonoBehaviour
{
    public static int score;

    int[] Varray = new[] { 15, 30, 45, 60, 75, 90, 105 };//dbg
    int[] Yososu = new[] { 14, 14, 14 ,4};
    public static Text text;


    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;

        Varray = Varray.Shuffle();//dbg
    }


    void Update()
    {

        if (score == 0)
            text.text = "Ready?";
        else if (score <= Yososu[3])
            text.text = "Practice: " + score ;
        else if (score <= Yososu[3]+Yososu[0])
            text.text = "Test: " + (score-4) + "垂直";
        else if (score <= Yososu[3] + Yososu[0]+Yososu[1])
            text.text = "Test: " + (score - 4) + "水平首振り";
        else if (score <= Yososu[3] + Yososu[0] + Yososu[1] + Yososu[2])
            text.text = "Test: " + (score-4) + "水平体回転";

        else
            text.text = "End";//Test: " + score;

            
        //text.text ="あ" + Varray[1]+Varray[2];
    }
}