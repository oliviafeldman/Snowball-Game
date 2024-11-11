using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;

    public bool isMoving;

    private void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");  

        if (moveHorizontal > 0 || moveVertical > 0) {
            isMoving = true;
        } else if (moveHorizontal == 0 && moveVertical == 0) {
            isMoving = false;
            rigBod.linearVelocity = new Vector3(0, rigBod.linearVelocity.y, 0);
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

    }
}    
