using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Active : MonoBehaviour
{
    public GameObject spot;
    [SerializeField]
    private Mission_Text mission;
    private int TextCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        spot.SetActive(false);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
            spot.SetActive(true);

        if (this.name == "Front_Trigger2" && coll.tag == "Player" && TextCount == 0)
        {
            TextCount++;
            mission.GetText();
        }
        if (this.name == "Front_Trigger3" && coll.tag == "Player" && TextCount == 0)
        {
            TextCount++;
            mission.GetText();
        }
        if (this.name == "Lab_Respawn_Trigger" && coll.tag == "Player" && TextCount == 0)
        {
            TextCount++;
            mission.GetText();
        }
    }
}
