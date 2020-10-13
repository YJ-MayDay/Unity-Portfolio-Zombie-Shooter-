using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet_wall_crash : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Bullet")
        {
            Debug.Log("bullet_Delete");
            if (coll.transform.parent != null)
                Destroy(coll.transform.parent.gameObject);
            else if (coll.transform.parent == null)
            {
                if (explosion != null)
                    Instantiate(explosion, this.transform.position, this.transform.rotation);
                Destroy(coll.gameObject,3f);
            }
        }
    }
}
