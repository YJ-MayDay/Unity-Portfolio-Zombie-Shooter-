using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float dist = 20.0f;
    public float height = 100.0f;
    public float smooth_Rotate = 5.0f;

    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float cullYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, 
            smooth_Rotate * Time.deltaTime);
        tr.position = target.position - (Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target);
    }
}
