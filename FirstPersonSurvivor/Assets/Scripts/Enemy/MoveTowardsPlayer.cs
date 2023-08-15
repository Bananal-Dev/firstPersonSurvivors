using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] GameObject targetToFollow;
    [SerializeField] Transform transformToFollow;
    private float _speed = 2.25f;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    
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

        Vector3 myPoint = new Vector3(gameObject.GetComponent<Transform>().position.x, 0f, gameObject.GetComponent<Transform>().position.z);
        Vector3 targetPoint = new Vector3(transformToFollow.position.x, 0f, transformToFollow.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(transformToFollow.position - gameObject.GetComponent<Transform>().position);

        if( Vector3.Distance(myPoint, targetPoint) > 1.1f )
            gameObject.GetComponent<Transform>().position = Vector3.MoveTowards(gameObject.GetComponent<Transform>().position, transformToFollow.position, speed*Time.deltaTime);
        gameObject.GetComponent<Transform>().rotation = Quaternion.Lerp(gameObject.GetComponent<Transform>().rotation, targetRotation, 15f*Time.deltaTime);
    }
}
