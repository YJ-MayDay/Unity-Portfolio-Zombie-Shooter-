using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public int Getbullet;
    public GameObject bullet;

    public GameObject[] guns = new GameObject[3];
    public AudioSource audio1;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GameObject.Find("reload_1").GetComponent<AudioSource>();

        guns[0] = GameObject.Find("WeaponContainer").transform.GetChild(1).gameObject;
        guns[1] = GameObject.Find("WeaponContainer").transform.GetChild(2).gameObject;
        guns[2] = GameObject.Find("WeaponContainer").transform.GetChild(3).gameObject;
    }

    // 문제는 오브젝트 비활성화로 인해 오브젝트를 받아오지 못하는 것
    private void OnTriggerEnter(Collider coll)
    {
        if (this.tag == "Ammo" && coll.tag == "Player")
        {
            switch (Getbullet)
            {
                case 30:
                    audio1.Play();
                    Destroy(bullet);
                    guns[0].GetComponent<Gun>().carryBulletCount = guns[0].GetComponent<Gun>().carryBulletCount + Getbullet;
                    break;
                case 50:
                    audio1.Play();
                    Destroy(bullet);
                    guns[1].GetComponent<Gun>().carryBulletCount = guns[1].GetComponent<Gun>().carryBulletCount + Getbullet;
                    break;
                case 10:
                    audio1.Play();
                    Destroy(bullet);
                    guns[2].GetComponent<Gun>().carryBulletCount = guns[2].GetComponent<Gun>().carryBulletCount + Getbullet;
                    break;
            }
        }
    }
}
