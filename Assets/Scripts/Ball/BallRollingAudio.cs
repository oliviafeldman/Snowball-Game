using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BallRollingAudio : MonoBehaviour
{
    [SerializeField] private EventReference ballRollingEvent;
    private EventInstance rollingSoundInstance;
    private Rigidbody rb;
    private bool isGrounded = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (AudioManager.instance != null)
        {
            rollingSoundInstance = AudioManager.instance.CreateInstance(ballRollingEvent);
            rollingSoundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position)); 
            rollingSoundInstance.start();
            rollingSoundInstance.setPaused(true);
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

            if (isGrounded && rb.linearVelocity.magnitude > 0.1f)
            {
                rollingSoundInstance.setPaused(false);
            }
            else
            {
                rollingSoundInstance.setPaused(true);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {   
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