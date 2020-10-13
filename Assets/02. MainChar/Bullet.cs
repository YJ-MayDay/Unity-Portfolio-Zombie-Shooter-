using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletspeed = 20000.0f;
    private Char_Controller Char;
    
    // Start is called before the first frame update
    void Start()
    {
        Char = GameObject.Find("US_Soldier").GetComponent<Char_Controller>();
        GetComponent<Rigidbody>().AddForce(Char.transform.forward * bulletspeed);

        if (this.transform.parent != null)
            Destroy(this.transform.parent.gameObject, 30.0f);
        else if (this.transform.parent == null)
        {
            Destroy(this.gameObject, 30.0f);
        }
    }
}
