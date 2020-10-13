using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private Char ch;
    public GameObject end;
    public bool ending = false;

    public float delay = 0;
    public float time;
    public float fades = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
        end = GameObject.Find("Ending");
        end.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ending)
        {
            delay += Time.deltaTime;
            if (delay > 5f)
            {
                time += Time.deltaTime;
                if (fades < 1.0f && time >= 0.1f)
                {
                    fades += 0.1f;
                    end.GetComponent<Image>().color = new Color(255, 255, 255, fades);

                    time = 0;
                    if(end.GetComponent<Image>().color.a >= 1)
                    {
                        SceneManager.LoadScene("2.Ending");
                    }
                }
                else if (fades >= 1.0f)
                {
                    time = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && ch.isImportant_Item)
        {
            ending = true;
        }
    }
}
