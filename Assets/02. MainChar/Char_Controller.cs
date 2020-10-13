using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    private Char ch;
    Vector3 move;
    private PauseMenu pause;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<Char>();
        ch.rigid = GetComponent<Rigidbody>();
        ch.ani = GetComponent<Animator>();
        pause = GameObject.Find("Main Camera").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause.paused)
        {
            if (!ch.isDead)
            {
                Run();

                ch.h = Input.GetAxis("Horizontal");
                ch.v = Input.GetAxis("Vertical");

                if (ch.isRun)
                {
                    ch.speed = 80.0f;
                }
                else
                    ch.speed = 40.0f;

                move.Set(ch.h, 0, ch.v);
                ch.ani.SetFloat("h", ch.h);
                ch.ani.SetFloat("v", ch.v);
                move = move.normalized * ch.speed * Time.deltaTime;

                if (Input.GetMouseButton(0))
                {
                    ch.isAttack = true;
                    ch.ani.SetBool("isAttack", ch.isAttack);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    ch.isAttack = false;
                    ch.ani.SetBool("isAttack", ch.isAttack);
                }

                Rotate();

                ch.rigid.MovePosition(transform.position + move);
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ch.hp = 0;
                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    ch.isImportant_Item = true;
                }

                if (ch.hp <= 0 && !ch.isDead)
                {
                    DeathCheck();
                }
            }
        }
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ch.isRun = true;
            ch.ani.SetBool("isRun", ch.isRun);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ch.isRun = false;
            ch.ani.SetBool("isRun", ch.isRun);
        }
    }

    private void Rotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float dist;
        if (ground.Raycast(ray, out dist))
        {
            Vector3 point = ray.GetPoint(dist);
            transform.LookAt(point);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(point);
                Debug.Log(dist);
            }
        }
    }

    private void DeathCheck()
    {
        PlayerPrefs.SetInt("Kill", ch.killCount);
        ch.isDead = true;
        ch.ani.SetTrigger("isDead");
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy_Weapon" && !coll.transform.parent.GetComponentInParent<Monster>().isDead)
            ch.hp = ch.hp - coll.transform.parent.GetComponentInParent<Monster>().attack_Damage;
    }

}


