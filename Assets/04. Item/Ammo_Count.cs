using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ammo_Count : MonoBehaviour
{
    private Text Count;
    private int bulletCount;

    public Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        Count = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        bulletCount = gun.carryBulletCount;
        Count.text = string.Format("{0}", bulletCount);
    }
}
