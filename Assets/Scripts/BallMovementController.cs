using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;


public class BallMovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;

    public bool isMoving;
    public float maxVelocity;

    private Vector3 lastPosition;
    public float movementThreshold = 0.01f;

    private void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
        lastPosition = transform.position;
    }
    
    //audio
    
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigBod.AddForce(movement * speed);

        float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        isMoving = distanceMoved > movementThreshold;

        lastPosition = transform.position;
        
        if (rigBod.linearVelocity.sqrMagnitude > maxVelocity ) {    
            rigBod.linearVelocity *= 0.99f;
        }
    }
    
}    
