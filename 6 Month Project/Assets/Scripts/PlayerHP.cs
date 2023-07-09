using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{

    [SerializeField]
    private float hp, startingHP = 10;
    [SerializeField]
    private TextMeshProUGUI hpUI;
    // Start is called before the first frame update
    void Start()
    {
        hp = startingHP;
        hpUI.text = hp.ToString();
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
            //InvokeDeathEvent
        }
        hpUI.text = hp.ToString();
    }
}
