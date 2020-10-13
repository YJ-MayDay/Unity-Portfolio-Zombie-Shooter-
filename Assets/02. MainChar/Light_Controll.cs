using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controll : MonoBehaviour
{
    private Char ch;
    private Light light;
    private int count;
    private bool toggle = true;
    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
        light = GetComponent<Light>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ch.isImportant_Item && count < 40)
        {
            if (toggle)
            {
                toggle = false;
                light.range = 500;
                count++;
            }
           else if (!toggle)
            {
                toggle = true;
                light.range = 0;
                count++;
            }
        }

        if (count > 40)
            light.range = 0;
    }
}
