using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabSpawn;
    
    private float _middleSpawnCooldown = 10f;
    public float middleSpawnCooldown
    {
        get { return _middleSpawnCooldown;}
        set { _middleSpawnCooldown = value;}
    }

    private float _rangeSpawnCooldown = 5f;
    public float rangeSpawnCooldown
    {
        get { return _rangeSpawnCooldown;}
        set { _rangeSpawnCooldown = value;}
    }

    private float currentTimer;
    private float currentCooldown;
    void Start()
    {
        currentCooldown = Random.Range(_middleSpawnCooldown - _rangeSpawnCooldown, _middleSpawnCooldown - _rangeSpawnCooldown);
        currentTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        if(currentTimer > currentCooldown)
        {
            currentTimer = 0f;
            currentCooldown = currentCooldown = Random.Range(_middleSpawnCooldown - _rangeSpawnCooldown, _middleSpawnCooldown - _rangeSpawnCooldown);
            Instantiate(prefabSpawn, new Vector3(Random.Range(-10, 10), -1f, Random.Range(-10, 10)) + gameObject.GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
