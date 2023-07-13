using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float hp, startingHP = 10;
    // Start is called before the first frame update
    void Start()
    {
        hp = startingHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            Die();
        }
    }

    void Die() => gameObject.SetActive(false);
}
