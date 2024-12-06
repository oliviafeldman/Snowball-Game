using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BallRollingAudio : MonoBehaviour
{
    [SerializeField] private EventReference ballRollingEvent;
    private EventInstance rollingSoundInstance;
    private Rigidbody rb;
    private bool isGrounded = false;

    // Adjustable parameters for fade-out behavior
    [SerializeField] private float maxVelocity = 5f;       // Velocity at which volume is maxed out
    [SerializeField] private float minVelocityThreshold = 0.05f; // Velocity below which sound stops
    [SerializeField] private float fadeSpeed = 10f;       // Speed at which volume fades out

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (AudioManager.instance != null)
        {
            rollingSoundInstance = AudioManager.instance.CreateInstance(ballRollingEvent);
            rollingSoundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position)); 
            rollingSoundInstance.start();
            rollingSoundInstance.setPaused(true); // Initially paused
        }
        else
        {
            Debug.LogError("AudioManager instance not found. Ensure AudioManager is in the scene.");
        }
    }

    private void Update()
    {
        if (rollingSoundInstance.isValid() && rb != null)
        {
            // Update the 3D position to follow the ball's position
            rollingSoundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));

            float velocityMagnitude = rb.linearVelocity.magnitude;

            if (isGrounded && velocityMagnitude > minVelocityThreshold)
            {
                rollingSoundInstance.setPaused(false);

                // Adjust volume smoothly based on velocity
                float normalizedVelocity = Mathf.Clamp01(velocityMagnitude / maxVelocity);
                rollingSoundInstance.setParameterByName("Volume", normalizedVelocity);
            }
            else if (velocityMagnitude <= minVelocityThreshold || !isGrounded)
            {
                // Fade out the volume quickly when stopping
                rollingSoundInstance.setParameterByName("Volume", 0f);
                rollingSoundInstance.setPaused(true); // Pause the sound when it's fully faded
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Set isGrounded to true if the ball is in contact with any collider
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Set isGrounded to false when the ball leaves contact with the ground
        isGrounded = false;
    }

    private void OnDestroy()
    {
        if (rollingSoundInstance.isValid())
        {
            rollingSoundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            rollingSoundInstance.release();
        }
    }
}
