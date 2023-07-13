using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public Vector2 targetRotation;
    public float sensitivity = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        targetRotation.y = Mathf.Clamp(targetRotation.y, -60, 60);
        targetRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(-targetRotation.y, targetRotation.x, 0);
        transform.position = player.position;
    }
}
