using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item : MonoBehaviour
{
    private Monster mon;
    public GameObject m1_ammo, mg42_ammo, bazooka_ammo;
    public GameObject health;
    // Start is called before the first frame update
    void Start()
    {
        mon = GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mon.isDead)
            StartCoroutine(DropItem());
    }

    // 드랍율 조정
    IEnumerator DropItem()
    {
        yield return new WaitForSeconds(3f);
        int i = Random.Range(0, 10);
        switch (i)
        {
            case 0:
            case 9:
                Instantiate(m1_ammo, mon.transform.localPosition, mon.transform.localRotation);
                break;
            case 1:
            case 8:
                Instantiate(mg42_ammo, mon.transform.localPosition, mon.transform.localRotation);
                break;
            case 2:
            case 7:
                Instantiate(bazooka_ammo, mon.transform.localPosition, mon.transform.localRotation);
                break;
            case 5:
                Instantiate(health, mon.transform.localPosition, mon.transform.localRotation);
                break;
            default:
                break;
        }

        Destroy(this.gameObject);
    }
}
