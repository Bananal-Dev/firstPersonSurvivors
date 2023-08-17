using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float _life = 100f;
    public Animator enemyAnimations;
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
            Debug.Log("Morri");
            DestroyImmediate(gameObject);
        }
        if(enemyAnimations)
            enemyAnimations.SetFloat("GetHitTime", enemyAnimations.GetCurrentAnimatorStateInfo(1).normalizedTime);
    }
    void LateUpdate()
    {
        enemyAnimations.ResetTrigger("GetHit");
    }
    public void Damage(float damage)
    {
        life = life - damage;
        enemyAnimations.SetTrigger("GetHit");
    }
    public void MoveAwayFrom(Vector3 point)
    {
        Rigidbody myTransform = gameObject.GetComponent<Rigidbody>();
        Vector3 direction = myTransform.position - point + new Vector3(0f, 1.2f, 0f);
        Vector3 moveVector = direction.normalized * 1f;
        myTransform.AddForce(moveVector, ForceMode.Impulse);
    }
}
