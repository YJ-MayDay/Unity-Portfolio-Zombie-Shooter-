using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Mon_Controller : MonoBehaviour
{
    private Transform player_tr;
    private Fire_Gun currentGun;
    private Transform tr;
    private Monster monster;
    private NavMeshAgent nav;

    private Collider coll;
    private Animator mon_ani;
    private AudioSource audioSource;

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        player_tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentGun = GameObject.FindGameObjectWithTag("Player").GetComponent<Fire_Gun>();
        //currentGun.currentGun.damage;
        tr = GetComponent<Transform>();
        monster = GetComponent<Monster>();
        nav = GetComponent<NavMeshAgent>();

        coll = GetComponent<Collider>();
        mon_ani = GetComponent<Animator>();
        audioSource = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        nav.speed = monster.speed;
         
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(tr.position, player_tr.position);
        nav.SetDestination(player_tr.position);

        if (!monster.isDead)
        {
            if (!audioSource.isPlaying && !monster.isRun)
                PlaySE(monster.growling_Sound);
            if (dist > monster.attack_range)
            {
                monster.isRun = true;
                mon_ani.SetBool("IsRun", monster.isRun);

                if(monster.isAttack0 || monster.isAttack1)
                {
                    monster.isAttack0 = false;
                    monster.isAttack1 = false;
                    mon_ani.SetBool("IsAttack0", monster.isAttack0);
                    mon_ani.SetBool("IsAttack1", monster.isAttack1);
                }

                Quaternion rot = Quaternion.LookRotation(player_tr.position - tr.position);
                tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * monster.damping);
                tr.Translate(Vector3.forward * Time.deltaTime * monster.speed);
            }
            else if (dist <= monster.attack_range)
            {
                if (!audioSource.isPlaying)
                    PlaySE(monster.attack_Sound);
                monster.isRun = false;
                mon_ani.SetBool("IsRun", monster.isRun);

                if (!monster.isAttack0 && !monster.isAttack1)
                {
                    int rand = Random.Range(0, 2);
                    switch(rand)
                    {
                        case 0:
                            monster.isAttack0 = true;
                            mon_ani.SetBool("IsAttack0", monster.isAttack0);
                            break;
                        case 1:
                            monster.isAttack1 = true;
                            mon_ani.SetBool("IsAttack1", monster.isAttack1);
                            break;
                    }
                }
            }
        }

        if (monster.hp <= 0 && monster.isDead == false)
        {
            if (!audioSource.isPlaying)
                PlaySE(monster.death_Sound);
            monster.isDead = true;
            int rand = Random.Range(0, 2);
            mon_ani.SetTrigger("IsDead" + rand);

            Char ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Char>();
            ch.killCount += 1;
        }

        if (monster.isDead)
        {
            monster.Death_check += Time.deltaTime;
            nav.speed = 0;
            if (monster.Death_check > 10f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void PlaySE(AudioClip Source)
    {
        audioSource.clip = Source;
        audioSource.Play();
    }
    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Bullet")
        {
            monster.hp -= currentGun.currentGun.damage; ;
            if (monster.hp > 0)
            {
                mon_ani.SetTrigger("IsDamage");
            }
            if (coll.name == "rocket(Clone)")
                Instantiate(Explosion, monster.transform.position, monster.transform.rotation);
            Destroy(coll.gameObject);
        }

    }
}
    