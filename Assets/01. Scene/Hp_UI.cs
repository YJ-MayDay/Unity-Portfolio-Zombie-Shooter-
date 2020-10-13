using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hp_UI : MonoBehaviour
{
    private Char ch;
    private Char_Controller Char;
    private Text text;
    private float per_hp;

    static float fullHP;

    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
        text = GetComponent<Text>();
        fullHP = ch.hp;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.Minus))
        //   ch.hp -= 5;

        per_hp = (float)ch.hp / fullHP * 100;
        text.text = string.Format("{0}", (int)per_hp);

        if (per_hp < 0)
        {
            ch.hp = 0;
        }
    }
}
