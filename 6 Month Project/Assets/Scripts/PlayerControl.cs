using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float horizontalValue, verticalValue;

    private PlayerMovement pM;
    private PlayerHP pH;

    private PlayerAttack pA;
    // Start is called before the first frame update
    void Start()
    {
        pM = gameObject.GetComponent<PlayerMovement>();
        pH = gameObject.GetComponent<PlayerHP>();
        pA = gameObject.GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pA.attacking)
        {
            horizontalValue = Input.GetAxis("Horizontal");
            verticalValue = Input.GetAxis("Vertical");
        }
        else{
            horizontalValue = 0;
            verticalValue = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space)&&(!pA.attacking || pA.cancellable))
        {
            pA.StopAllCoroutines();
            StartCoroutine(pA.attack());
        }
    }

    void FixedUpdate()
    {
        pM.Move(horizontalValue, verticalValue);
    }

}
