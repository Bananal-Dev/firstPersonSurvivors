using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float _life = 100f;
    public float life
    {
        get { return _life; }
        set {
             _life = value; 
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_life <= 0f)
        {
            DestroyImmediate(gameObject);
        }
    }

    public void Damage(float damage, Vector3 origin)
    {
        life = life - damage;
        Transform myTransform = gameObject.GetComponent<Transform>();
        Vector3 direction = myTransform.position - origin;
        Vector3 moveVector = direction.normalized * 0.2f;
        myTransform.Translate(moveVector);
    }
    public void MoveAwayFrom(Vector3 point)
    {
        Transform myTransform = gameObject.GetComponent<Transform>();
        Vector3 direction = myTransform.position - point;
        Vector3 moveVector = direction.normalized * 0.2f;
        myTransform.Translate(moveVector);
    }
}
