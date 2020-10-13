using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetImportant : MonoBehaviour
{
    private Char ch;
    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ch.isImportant_Item = true;
            this.gameObject.SetActive(false);
            //나중에 디스트로이어로 변경
        }
    }
}
