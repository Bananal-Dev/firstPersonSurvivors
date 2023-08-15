using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BookWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> bookObjects = new List<GameObject>();
    private float cooldown = 5f;
    private float currentTimer = 0f;
    private bool attacking = false;
    private float currentAngle = 0f;
    private float radius = 0f;
    private float maxRadius = 4f;
    private float angleSpeed = 450f;
    private float radiusSpeed = 3f;
    private float damage = 15f;
    private float maxAngle = 2000f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        if(currentTimer > cooldown)
        {
            attacking = true;
        }
        ManageAttack();
    }

    void ManageAttack()
    {
        if(!attacking)
            return;
        int bookNumber = 0;
        currentAngle += angleSpeed*Time.deltaTime;
        if(radius < maxRadius)
            radius += radiusSpeed*Time.deltaTime;
        foreach(GameObject book in bookObjects)
        {
            if(!book.activeSelf)
                book.SetActive(true);
            else
            {
                float x = radius*Mathf.Cos((currentAngle + bookNumber*(360/bookObjects.Count)) * Mathf.Deg2Rad);
                float y = book.GetComponent<Transform>().localPosition.y;
                float z = radius*Mathf.Sin((currentAngle + bookNumber*(360/bookObjects.Count)) * Mathf.Deg2Rad);
                book.GetComponent<Transform>().localPosition = new Vector3(x, y, z);
            }
            if(currentAngle >= maxAngle)
            {
                book.SetActive(false);
            }
            bookNumber++;
        }
        if(currentAngle >= maxAngle)
        {
            currentAngle = 0f;
            radius = 0;
            currentTimer = 0f;
            attacking = false;
        }
    }
    
    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == 6)
        {
            c.gameObject.GetComponent<EnemyManager>().Damage(damage, gameObject.transform.position);
        }
    }
    void OnTriggerStay(Collider c)
    {
        if(c.gameObject.layer == 6)
        {
            c.gameObject.GetComponent<EnemyManager>().MoveAwayFrom(gameObject.transform.position);
        }
    }
}
