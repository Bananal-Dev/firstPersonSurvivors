using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public Vector3 RandomPointInCircle2D(float radius)
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float distance = Mathf.Sqrt(Random.Range(0f, 1f)) * radius;

        float x = Mathf.Cos(angle) * distance;
        float z = Mathf.Sin(angle) * distance;

        return new Vector3(x, 0, z);
    }
}
