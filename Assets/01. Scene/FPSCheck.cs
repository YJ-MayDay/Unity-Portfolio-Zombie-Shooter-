using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FPSCheck : MonoBehaviour
{
    float time = 0.0f;
    private Text text;

    public bool InfoCheck = false;
    void Start()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        time += (Time.deltaTime - time) * 0.1f;

        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = time * 1000.0f;
        float fps = 1.0f / time;

        if (Input.GetKeyDown(KeyCode.I))
        {
            InfoCheck = !InfoCheck;
        }

        if (InfoCheck)
            text.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        if (!InfoCheck)
            text.text = string.Format("");
    }
}
