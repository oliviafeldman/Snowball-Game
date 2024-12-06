using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ballThudAudio : MonoBehaviour
{
    [SerializeField] private EventReference thudSoundEvent; 
    private EventInstance thudSoundInstance;

    [SerializeField] private float minImpactForce = 1.0f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minImpactForce)
        {
            RuntimeManager.PlayOneShot(thudSoundEvent, transform.position);
        }
    }
}

