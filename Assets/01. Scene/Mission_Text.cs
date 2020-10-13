using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class Mission_Text : MonoBehaviour
{
    private Text text;
    public string fileName;
    private string strPath = "Assets/Resources/";
    private string readStr;
    FileStream fs;
    StreamReader sr;

    void Start()
    {
        text = GetComponent<Text>();
        strPath = strPath + fileName;

        fs = new FileStream(strPath, FileMode.Open);
        sr = new StreamReader(fs);

        readStr = sr.ReadLine();
        text.text = string.Format("{0}", readStr);
    }

    public void GetText()
    {
        readStr = sr.ReadLine();
        text.text = string.Format("{0}", readStr);
    }
}
