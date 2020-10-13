using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName;          //총 이름
    public float range;             //사거리
    public float fireRate;          //연사 속도
    public int damage;              //데미지
    public int carryBulletCount;    //현재 소유한 갯수

    public ParticleSystem muzzleFlash;
    public AudioClip fireSound;
}

// public int maxBulletCount;      //최대 소유 가능 갯수
// public float reroadTime;        //재장전 시간
// public int reroadBulletCount;   //재장전 총알 갯수
// public int currentBulletCount;  //현재 남은 총알 갯수