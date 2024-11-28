using System;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;

    [SerializeField]
    private float gravityScaler = 1.015f;

    public bool isMoving;

    public float maxVelocity = 10f;
    public float maxGravity = 20f;

    private Vector3 originalGravity;

    private BallTerrainDetection ballTerrainDetection;

    private void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
        originalGravity = Physics.gravity;
        ballTerrainDetection = GetComponent<BallTerrainDetection>();
    }

    private void Update()
    {
        HandleMovement();
        LimitVelocity();
        HandleGravity();
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        isMoving = moveHorizontal != 0 || moveVertical != 0;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigBod.AddForce(movement * speed);
    }

    private void LimitVelocity()
    {
        Vector3 velocity = rigBod.linearVelocity;
        velocity.x = Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity);
        velocity.z = Mathf.Clamp(velocity.z, -maxVelocity, maxVelocity);
        rigBod.linearVelocity = velocity;
    }

    private void HandleGravity()
    {
        if (ballTerrainDetection.terrainType == "Untagged")
        {
            if (Physics.gravity.y > -maxGravity)
            {
                Physics.gravity *= gravityScaler;
            }
        }
        else
        {
            Physics.gravity = originalGravity;
        }
    }
}
