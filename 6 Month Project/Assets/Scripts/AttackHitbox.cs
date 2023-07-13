using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField]
    private float damage = 1;
    private bool hasAttacked = false;

    public AttackData attackData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        hasAttacked = false;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Hit");
        if(!hasAttacked && attackData.enemy && other.gameObject.GetComponent<PlayerHP>()){
            hasAttacked = true;
            other.gameObject.GetComponent<PlayerHP>().TakeDamage(damage);
        }else if(!hasAttacked && !attackData.enemy && other.gameObject.GetComponent<EnemyHP>()){     
            hasAttacked = true;
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
        }
    }
}
