using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controller : MonoBehaviour
{
    public GameObject[] light_trigger;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        light_trigger = GameObject.FindGameObjectsWithTag("Trigger");
        light = GetComponent<Light>();
        light.intensity = light.intensity - 0.4f;
    }

}
