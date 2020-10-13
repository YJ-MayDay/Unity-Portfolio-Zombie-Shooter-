using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Char : MonoBehaviour
{
    public int hp = 1000;

    public float h = 0.0f, v = 0.0f;
    public float speed = 40.0f;

    public bool isRun = false;
    public bool isAttack = false;
    public bool isDead = false;

    public int killCount = 0;

    public Animator ani;
    public Rigidbody rigid;

    public bool isImportant_Item = false;
}
