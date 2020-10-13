using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Trigger : MonoBehaviour
{
    private Transform[] Respawn_Point;
    public GameObject F_Mon_prefab;
    public GameObject M_Mon_prefab;
    public GameObject Hulk_prefab;
    public GameObject Tank_prefab;

    public float Create_Time;
    public int maxMonster = 20;
    public int currentCount = 0;

    public int NamedCount;
    public int Max_Named;

    // Start is called before the first frame update
    void Start()
    {
        Respawn_Point = GetComponentsInChildren<Transform>();

        if (Respawn_Point.Length > 0)
        {
            StartCoroutine(this.CreateMonster());
        }
    }

    IEnumerator CreateMonster()
    {
        while(currentCount != maxMonster)
        {
            int MonsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (MonsterCount < maxMonster)
            {
                yield return new WaitForSeconds(Create_Time);
                int index = Random.Range(1, Respawn_Point.Length);
                int random = Random.Range(0, 5);
                switch (random)
                {
                    case 0:
                    case 1:
                    case 2:
                        Instantiate(F_Mon_prefab, Respawn_Point[index].position, Respawn_Point[index].rotation);
                        currentCount++;
                        break;
                    case 3:
                    case 4:
                        Instantiate(M_Mon_prefab, Respawn_Point[index].position, Respawn_Point[index].rotation);
                        currentCount++;
                        break;
                }
            }
            if(NamedCount < Max_Named)
            {
                int index = Random.Range(1, Respawn_Point.Length);
                int random = Random.Range(0, 5);
                switch (random)
                {
                    case 0:
                    case 1:
                        Instantiate(Hulk_prefab, Respawn_Point[index].position, Respawn_Point[index].rotation);
                        NamedCount++;
                        break;
                    case 2:
                    case 3:
                        Instantiate(Tank_prefab, Respawn_Point[index].position, Respawn_Point[index].rotation);
                        NamedCount++;
                        break;
                    case 4:
                        break;
                }

            }
            else
                yield return null;
        }
    }
}
