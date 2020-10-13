using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    private Text txt;
    public float second, minute, hour;

    private bool InfoCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;

        if(second > 59)
        {
            second = 0;
            minute++;

            if(minute >59)
            {
                minute = 0;
                hour++;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            InfoCheck = !InfoCheck;
        }

        if (InfoCheck)
            txt.text = string.Format("PlayTime : {0:00} : {1:00} : {2:00}", hour, minute, second);
        if (!InfoCheck)
            txt.text = string.Format("");
    }
}
