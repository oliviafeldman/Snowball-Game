using System;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;
    [SerializeField] private float gravityScaler = 1.015f;
    public bool isMoving;
    public float maxVelocity = 10f;
    public float maxGravity = 20f;

    public float velocityThreshold = 0.5f;
    private Vector3 originalGravity;
    private BallTerrainDetection ballTerrainDetection;

    private void Start()
    {
        rigBod = GetComponent<Rigidbody>();
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

        isMoving = rigBod.linearVelocity.magnitude > velocityThreshold;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigBod.AddForce(movement * speed * Time.deltaTime, ForceMode.Acceleration);
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
                Physics.gravity *= Mathf.Pow(gravityScaler, Time.deltaTime);
            }
        }
        else
        {
            Physics.gravity = originalGravity;
        }
    }
}
