using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f, rotationSpeed = 15f;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Rigidbody rb;


    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = Vector3.zero;
    }

    public void Move(float horizontal, float vertical)
    {
        if(horizontal != 0 || vertical != 0)
        {
            Vector3 cameraForward = playerCamera.transform.forward;
            Vector3 cameraRight = playerCamera.transform.right;
            Vector3 newSpeed = (horizontal*cameraRight+vertical*cameraForward);
            newSpeed.y = 0;
            rb.velocity = newSpeed.normalized * speed;
            Rotate(horizontal,vertical);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity,Vector3.zero,0.3f);
            if(rb.velocity.magnitude < 0.2)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    void Rotate(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        direction = playerCamera.gameObject.transform.TransformDirection(direction);
        direction.y = 0;

        Quaternion target = Quaternion.LookRotation(direction, Vector3.up);
        Quaternion increment = Quaternion.Lerp(rb.rotation, target, rotationSpeed * Time.deltaTime);
        rb.MoveRotation(target);
    }
}
