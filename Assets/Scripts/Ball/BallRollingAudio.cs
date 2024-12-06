using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BallRollingAudio : MonoBehaviour
{
    [SerializeField] private EventReference ballRollingEvent; // FMOD Event for the rolling sound
    private EventInstance rollingSoundInstance;
    private Rigidbody rb;
    private bool isGrounded = false;

    [SerializeField] private float maxVelocity = 5f;       // Velocity at which volume reaches 1
    [SerializeField] private float minVelocityThreshold = 0.1f; // Velocity below which volume is 0

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (AudioManager.instance != null)
        {
            rollingSoundInstance = AudioManager.instance.CreateInstance(ballRollingEvent);
            rollingSoundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position)); 
            rollingSoundInstance.start();
            rollingSoundInstance.setPaused(true); // Start the sound paused
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

                // Map velocity to volume between 0 and 1
                float normalizedVelocity = Mathf.Clamp01(velocityMagnitude / maxVelocity);
                rollingSoundInstance.setParameterByName("Volume", normalizedVelocity);
            }
            else
            {
                // Pause the sound if velocity is below threshold or not grounded
                rollingSoundInstance.setPaused(true);
                rollingSoundInstance.setParameterByName("Volume", 0f);
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
