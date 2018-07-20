using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    SpriteRenderer img;

    void Start()
    {
        img = GetComponent<SpriteRenderer>();
        img.color = Color.clear;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.img.color = new Color(255f, 255f, 255f, 255f);
        }
        else
        {
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime*20);
        }
    }
}