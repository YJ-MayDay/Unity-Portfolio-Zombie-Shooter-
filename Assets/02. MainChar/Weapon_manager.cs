using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Fire_Gun))]
public class Weapon_manager : MonoBehaviour
{
    public static bool isChangeWeapon = false; //정적 변수
    public static Transform currentWeapon; //현재 무기
    public static Animator currentWeaponAni; //무기 애니
    public Animator cc_ani;

    [SerializeField]
    private string currentWeaponType;

    [SerializeField]
    private float changeWeaponDelaytime = 0.03f;
    [SerializeField]
    private float changeWeaponEndDelaytime;

    [SerializeField]
    private Gun[] guns;

    //무기 관리
    private Dictionary<string, Gun> GunDic = new Dictionary<string, Gun>();

    [SerializeField]
    private Fire_Gun GunControl;

    // Start is called before the first frame update
    void Start()
    {
        cc_ani = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        GunControl = GameObject.FindWithTag("Player").GetComponent<Fire_Gun>();

        currentWeapon = guns[0].GetComponent<Transform>();
        for (int i = 0; i < guns.Length; i++)
        {
            GunDic.Add(guns[i].gunName, guns[i]);
            if (i != 0)
            {
                guns[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChangeWeapon)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(ChangeWeaponCoroutin("Gun", guns[0].name));
                cc_ani.SetTrigger("Weapon0");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(ChangeWeaponCoroutin("Gun", guns[1].name));
                cc_ani.SetTrigger("Weapon1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(ChangeWeaponCoroutin("Gun", guns[2].name));
                cc_ani.SetTrigger("Weapon2");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                StartCoroutine(ChangeWeaponCoroutin("Gun", guns[3].name));
                cc_ani.SetTrigger("Weapon3");
            }
        }
    }

    public IEnumerator ChangeWeaponCoroutin(string type,string name)
    {
        Debug.Log("check");
        isChangeWeapon = true;

        WeaponChange(type,name);
        yield return new WaitForSeconds(changeWeaponDelaytime);
        currentWeaponType = type;
        isChangeWeapon = false;
    }

    private  void WeaponChange(string type,string name)
    {
        if(type == "Gun")
        {
            GunControl.GunChange(GunDic[name]);
        }
    }
}
