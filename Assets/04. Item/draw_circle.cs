using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw_circle : MonoBehaviour
{
    public Color color;
    public int segments;
    public float xradius;
    public float yradius;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;

        line.material.color = color;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float y = 0f;
        float z;

        float angle = 20f;
        for(int i =0;i<(segments +1);i++)
        {
            x = Mathf.Cos(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;

            line.SetPosition(i, new Vector3(x, y, z));
            angle += (360f / segments);
        }
    }
}
