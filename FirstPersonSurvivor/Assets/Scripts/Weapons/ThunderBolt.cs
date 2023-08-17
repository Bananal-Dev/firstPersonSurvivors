using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThunderBolt : MonoBehaviour
{
    private float _damage;
    public float damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        int particleCount = particleSystem.GetParticles(particles);
        for (int i = 0; i < particleCount; i++)
        {
            // Set the velocity of each particle to zero
            particles[i].position += new Vector3(0f, -10f, 0f);
            particles[i].velocity = new Vector3(0f, 0f, 0f);
        }
        // Apply the modified particles back to the Particle System
        particleSystem.SetParticles(particles, particleCount);
        if(other.layer == 6)
        {
            other.GetComponent<EnemyManager>().Damage(damage);
            Debug.Log("Damage monster");
        }
        Destroy(gameObject, 1f);
    }
}
