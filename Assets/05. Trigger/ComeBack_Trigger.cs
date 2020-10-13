using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeBack_Trigger : MonoBehaviour
{
    private Char _char;
    private GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        _char = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
        back = GameObject.Find("Go_Back");
        back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_char.isImportant_Item == true)
        {
            back.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
