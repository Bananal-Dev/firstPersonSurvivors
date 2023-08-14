using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public GameObject targetToFollow;
    private float _speed = 2.25f;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 myPoint = new Vector3(gameObject.GetComponent<Transform>().position.x, 0f, gameObject.GetComponent<Transform>().position.z);
        Vector3 targetPoint = new Vector3(targetToFollow.transform.position.x, 0f, targetToFollow.transform.position.z);

        if( Vector3.Distance(myPoint, targetPoint) > 1.1f )
            gameObject.GetComponent<Transform>().position = Vector3.MoveTowards(gameObject.GetComponent<Transform>().position, targetToFollow.GetComponent<Transform>().position, speed*Time.deltaTime);
    }
}
