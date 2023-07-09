using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float horizontalValue, verticalValue;

    private PlayerMovement pM;
    private PlayerHP pH;
    // Start is called before the first frame update
    void Start()
    {
        pM = gameObject.GetComponent<PlayerMovement>();
        pH = gameObject.GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pH.TakeDamage(1);
        }
    }

    void FixedUpdate()
    {
        pM.Move(horizontalValue, verticalValue);
    }

}
