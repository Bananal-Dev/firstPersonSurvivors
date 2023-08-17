using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGem : MonoBehaviour
{
    public GameObject gemPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Instantiate(gemPrefab, gameObject.transform.position + Vector3.up*0.2f, Quaternion.identity);
    }
}