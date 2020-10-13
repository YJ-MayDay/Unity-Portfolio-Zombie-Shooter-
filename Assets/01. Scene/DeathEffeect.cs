using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeathEffeect : MonoBehaviour
{
    private Char ch;
    public GameObject death;
    public GameObject death_menu;
    public bool ending = false;

    public float delay = 0;
    public float time;
    public float fades = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
        death = GameObject.Find("Death");
        death.GetComponent<Image>().color = new Color(255, 0, 0, 0);
        death_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ch.isDead)
        {
            delay += Time.deltaTime;
            if (delay > 5f)
            {
                time += Time.deltaTime;
                if (fades < 0.5f && time >= 0.1f)
                {
                    fades += 0.1f;
                    death.GetComponent<Image>().color = new Color(255, 0, 0, fades);

                    time = 0;
                    if(death.GetComponent<Image>().color.a >= 0.5)
                    {
                        death_menu.SetActive(true);
                    }
                }
                else if (fades >= 1.0f)
                {
                    time = 0;
                }
            }
        }
    }
}
