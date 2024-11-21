using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;


public class BallMovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;

    public float gravityMultiplier = 3f;

    public bool isMoving;

    public float maxVelocity;

    private void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
        isMoving = false;

        Physics.gravity *= gravityMultiplier;
    }
    
    //audio
    
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0) {
            isMoving = true;
        } else {
            isMoving = false;
        }
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigBod.AddForce(movement * speed);

        if (rigBod.linearVelocity.sqrMagnitude > maxVelocity ) {    
            rigBod.linearVelocity *= 0.99f;
        }
    }
    
}    
