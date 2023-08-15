using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] GameObject targetToFollow;
    [SerializeField] Transform transformToFollow;
    private float _speed = 3f;
    public Animator zombieAnimations;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    
    private float attackCooldown = 0.9f;
    private float attackTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        targetToFollow = GameObject.Find("Player");
        Transform[] childrenObjects = targetToFollow.GetComponentsInChildren<Transform>();
        foreach(Transform child in childrenObjects)
        {

            if(child.gameObject.name == "Capsule")
            {
                transformToFollow = child;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        Vector3 myPoint = new Vector3(gameObject.GetComponent<Transform>().position.x, 0f, gameObject.GetComponent<Transform>().position.z);
        Vector3 targetPoint = new Vector3(transformToFollow.position.x, 0f, transformToFollow.position.z);
        Vector3 targetDirection = transformToFollow.position - gameObject.GetComponent<Transform>().position;
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        if( Vector3.Distance(myPoint, targetPoint) > 1.1f )
        {
            gameObject.GetComponent<Transform>().position = Vector3.MoveTowards(gameObject.GetComponent<Transform>().position, transformToFollow.position, speed*Time.deltaTime);
            zombieAnimations.SetBool("AttackZombie", false);
        }
        else
        {   
            if(attackTimer > attackCooldown)
            {
                zombieAnimations.SetBool("AttackZombie", true);
                float currentAnimProgress = zombieAnimations.GetCurrentAnimatorStateInfo(0).normalizedTime;
                if( (currentAnimProgress - Mathf.Floor(currentAnimProgress))>= 0.6f && zombieAnimations.GetCurrentAnimatorStateInfo(0).IsName("Attacking") && (currentAnimProgress - Mathf.Floor(currentAnimProgress)) < 0.65f)
                {
                    attackTimer = 0f;
                    targetToFollow.GetComponent<PlayerManager>().TakeDamage(15f);
                    attackTimer = 0f;
                }

            }           
        }
        gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, targetRotation, 15f*Time.deltaTime);

    }
}
