using UnityEngine;
using UnityEngine.UI;

public class SongsNode : MonoBehaviour
{
    public Text buttonText;

    // 押したら更新するText
    public Text detailText;

    public void Initialize(string buttonString, Text detailText)
    {
        this.buttonText.text = buttonString;
        this.detailText = detailText;
    }

    public void OnButtonClick()
    {
        detailText.text = buttonText.text;
    }
}