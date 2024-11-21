using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;


public class BallMovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;
    
    [SerializeField]
    private float gravityScaler = 1.05f;

    private Vector3 originalGravity;

    public bool isMoving;

    public float maxVelocity;

    private BallTerrainDetection ballTerrainDetection;

    private void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
        originalGravity = Physics.gravity;
        ballTerrainDetection = GetComponent<BallTerrainDetection>();
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

        float clampedX = Mathf.Clamp(rigBod.linearVelocity.x, -maxVelocity, maxVelocity);
        float clampedZ = Mathf.Clamp(rigBod.linearVelocity.z, -maxVelocity, maxVelocity);
        rigBod.linearVelocity = new Vector3(clampedX, rigBod.linearVelocity.y, clampedZ);

        //if (rigBod.linearVelocity.sqrMagnitude > maxVelocity ) {    
            //rigBod.linearVelocity *= 0.99f;
        //}

        if (ballTerrainDetection.terrainType == "Air") {
            Physics.gravity *= gravityScaler;
        } else {
            Physics.gravity = originalGravity;
        }


    }
    
}    
