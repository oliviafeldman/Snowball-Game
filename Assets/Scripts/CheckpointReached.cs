using UnityEngine;

public class CheckpointReached : MonoBehaviour
{
    private ParticleSystem checkpointEffect;

    private bool hasEntered = false;

    private void Start()
    {
        checkpointEffect = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasEntered == false)
        {
            if (checkpointEffect != null && !checkpointEffect.isPlaying)
            {
                checkpointEffect.Play();
                hasEntered = true;
            }
        }
    }
}
