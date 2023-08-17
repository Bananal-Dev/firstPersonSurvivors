using System.Collections;
using System.Collections.Generic;
using Sketchfab;
using Unity.VisualScripting;
using UnityEngine;

public class ThunderWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem thunderParticle;

    private float _cooldown = 5f;
    public float cooldown
    {
        get { return _cooldown; }
        set { _cooldown = value; }
    }

    private float _currentCooldown = 0f;
    public float currentCooldown
    {
        get { return _currentCooldown; }
        set { _currentCooldown = value; }
    }
    private float _damage = 30f;
    public float damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private int _numberOfBolts = 10;
    public int numberOfBolts
    {
        get { return _numberOfBolts;}
        set { _numberOfBolts = value;}
    }

    void Start()
    {
        
    }

    void Update()
    {
        currentCooldown += Time.deltaTime;
        if(currentCooldown >= cooldown)
        {
            StartAttack();
            currentCooldown = 0f;
        }
    }

    void StartAttack()
    {
        for(int i = 0; i < numberOfBolts; i++)
        {
            SpawnBolt();
        }
    }

    void SpawnBolt()
    {
        ParticleSystem bolt = Instantiate(thunderParticle, gameObject.GetComponent<Transform>());
        Vector3 randomPoint = Utils.RandomPointInCircle2D(20f);
        bolt.transform.position += new Vector3(0, 10f, 0) + randomPoint;
        bolt.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        bolt.GetComponent<ThunderBolt>().damage = damage;
    }

}