using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Text_Contoller : MonoBehaviour
{
    public GameObject[] effect;
    public float time;
    public void Start()
    {
        for (int i = 0; i < effect.Length; i++)
        {
            effect[i].SetActive(false);
        }
    }

    public void Update()
    {
        time += Time.deltaTime;
        if(time > 5f)
            effect[0].SetActive(true);
        if (time > 10f)
            effect[1].SetActive(true);
        if (time > 15f)
            effect[2].SetActive(true);

        if(time > 20f)
            SceneManager.LoadScene("0.Main");
    }
}
