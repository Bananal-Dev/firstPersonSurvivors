using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float _life = 100f;
    public Animator zombieAnimations;
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
        if(zombieAnimations)
            zombieAnimations.SetFloat("GetHitTime", zombieAnimations.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
    void LateUpdate()
    {
        zombieAnimations.ResetTrigger("GetHit");
    }
    public void Damage(float damage, Vector3 origin)
    {
        life = life - damage;
        zombieAnimations.SetTrigger("GetHit");
        MoveAwayFrom(origin);
    }
    public void MoveAwayFrom(Vector3 point)
    {
        Rigidbody myTransform = gameObject.GetComponent<Rigidbody>();
        Vector3 direction = myTransform.position - point + new Vector3(0f, 1.2f, 0f);
        Vector3 moveVector = direction.normalized * 1f;
        myTransform.AddForce(moveVector, ForceMode.Impulse);
    }
}
