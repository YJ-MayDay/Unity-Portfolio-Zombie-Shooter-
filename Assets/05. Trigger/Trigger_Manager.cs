using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Manager : MonoBehaviour
{
    public GameObject[] trigger;
    public GameObject trigger1;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GameObject.FindGameObjectsWithTag("Trigger");

        for (int i = 0; i < trigger.Length; i++)
        {
            trigger[i].gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < trigger.Length; i++)
        {
            if (other.tag == "Player")
            {
                trigger[i].SetActive(true);
            }
        }
    }
}
