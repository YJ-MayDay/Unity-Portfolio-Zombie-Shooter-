using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHPBox : MonoBehaviour
{
    public Char ch;
    public AudioSource audio_;

    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
        audio_ = GameObject.Find("health_Sound").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
            ch.hp -= 5;
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (this.tag == "health" && coll.tag == "Player" && ch.hp < 1000)
        {
            audio_.Play();
            ch.hp = ch.hp + 50;
            Destroy(this.gameObject);
        }
    }
}
