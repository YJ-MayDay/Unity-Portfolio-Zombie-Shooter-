using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Gun : MonoBehaviour
{

    public enum Weapon
    {
        weapon_tokarev,
        weapon_M1carbine,
        weapon_mg42,
        weapon_bazooka
    };

    public Weapon weapon;
    public GameObject bullet;
    public GameObject rocket;
    public Transform firepos;

    public float timer;
    public float waiting_time;

    [SerializeField]
    public Gun currentGun;

    private float currentFireRate;
    public AudioSource Audiosource;


    // Start is called before the first frame update
    void Start()
    {
        currentGun = GameObject.Find("weapon_tokarev").GetComponent<Gun>();
        Audiosource = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        timer = 7.0f;
        waiting_time = 1.0f;

        currentFireRate = currentGun.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        weapon = GunTypeCheck();
        switch (weapon)
        {
            case Weapon.weapon_tokarev:
                firepos = GameObject.Find("tokarev_Firepos").GetComponent<Transform>();
                break;
            case Weapon.weapon_M1carbine:
                firepos = GameObject.Find("m1_Firepos").GetComponent<Transform>();
                break;
            case Weapon.weapon_mg42:
                firepos = GameObject.Find("mg42_Firepos").GetComponent<Transform>();
                break;
            case Weapon.weapon_bazooka:
                firepos = GameObject.Find("bazooka_Firepos").GetComponent<Transform>();
                break;
        }
        GunFireRateCalc();
        TryFire();
    }

    private void GunFireRateCalc()
    {
       currentFireRate -= Time.deltaTime;
    }

    private void TryFire()
    {
        if (Input.GetMouseButton(0) && currentFireRate <= 0)
            Fire();
    }

    private void Fire()
    {
        currentFireRate = currentGun.fireRate;
        if (currentGun.carryBulletCount > 0)
            Shoot();
    }

    private void Shoot()
    {
        PlaySE(currentGun.fireSound);
        if (currentGun.gunName != "weapon_bazooka")
            Instantiate(bullet, firepos.position, firepos.rotation);
        else
            Instantiate(rocket, firepos.position, firepos.rotation);

        if (currentGun.muzzleFlash != null)
            currentGun.muzzleFlash.Play();
        currentGun.carryBulletCount -= 1;
        Debug.Log("shoot!!");
    }

    private void PlaySE(AudioClip _clip)
    {
        Audiosource.clip = _clip;
        Audiosource.Play();
    }

    public void GunChange(Gun gun)
    {
        if(Weapon_manager.currentWeapon != null)
        {
            Weapon_manager.currentWeapon.gameObject.SetActive (false);

            currentGun = gun;
            Weapon_manager.currentWeapon = currentGun.GetComponent<Transform>();
            currentGun.gameObject.SetActive(true);
        }
    }

    private Weapon GunTypeCheck()
    {
        if (currentGun.gunName == "weapon_tokarev")
            return Weapon.weapon_tokarev;
        else if (currentGun.gunName == "weapon_M1carbine")
            return Weapon.weapon_M1carbine;
        else if (currentGun.gunName == "weapon_mg42")
            return Weapon.weapon_mg42;
        else if (currentGun.gunName == "weapon_bazooka")
            return Weapon.weapon_bazooka;

        return Weapon.weapon_tokarev;
    }

}
