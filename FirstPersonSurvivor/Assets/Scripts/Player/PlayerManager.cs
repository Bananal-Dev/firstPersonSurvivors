using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float _life = 100f;
    public float life
    {
        get { return _life; }
        set {
            
            if(value>=0)
            {
                lifeBar.GetComponent<RectTransform>().localScale = new Vector3(value/100f, 1f, 1f);
                _life = value; 
            }
            else
            {
                lifeBar.GetComponent<RectTransform>().localScale = new Vector3(0f, 1f, 1f);
                _life = 0f;
            }
        }
    }
    public GameObject lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        // Debug.Log(life);
    }
}
