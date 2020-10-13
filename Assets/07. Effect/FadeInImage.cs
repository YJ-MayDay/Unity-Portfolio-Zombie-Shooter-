using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeInImage : MonoBehaviour
{
    public RawImage image;
    public Button[] button;
    public Text text;
    public Text text1;

    public float fades = 1.0f;
    public float time = 0;

    public bool buttonClick = false;
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("RawImage").GetComponent<RawImage>();
        button = GameObject.Find("RawImage").GetComponentsInChildren<Button>();
        text = button[0].GetComponentInChildren<Text>();
        text1 = button[1].GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonClick)
        {
            time += Time.deltaTime;
            if (fades > 0.0f && time >= 0.1f)
            {
                fades -= 0.1f;
                image.color = new Color(255, 255, 255, fades);

                for (int i = 0; i < button.Length; i++)
                {
                    ColorBlock block = button[i].colors;
                    block.normalColor = new Color(255, 255, 255, fades);
                    button[i].colors = block;
                }

                text.color = new Color(255, 255, 255, fades);
                text1.color = new Color(255, 255, 255, fades);
                time = 0;
            }
            else if (fades <= 0.0f)
            {
                time = 0;
            }
        }
    }
}
