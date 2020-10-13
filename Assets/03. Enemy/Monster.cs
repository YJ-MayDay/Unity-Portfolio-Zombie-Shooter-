using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp;
    public int attack_Damage;
    public float damping;
    public float speed;

    public float attack_range = 20f;

    public float Death_check;

    public bool isRun = false;
    public bool isAttack0 = false;
    public bool isAttack1 = false;
    public bool isDead = false;

    public AudioClip growling_Sound;
    public AudioClip attack_Sound;
    public AudioClip death_Sound;
}
