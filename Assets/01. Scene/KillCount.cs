using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    private Char ch;
    private int count = 0;
    private Text text;

    private bool InfoCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        count = ch.killCount;
        if(Input.GetKeyDown(KeyCode.I))
        {
            InfoCheck = !InfoCheck;
        }

        if (InfoCheck)
            text.text = string.Format("KILL : {0}", count);
        if (!InfoCheck)
            text.text = string.Format("");
    }
}
