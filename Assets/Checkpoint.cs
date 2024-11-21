using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Attempt to find a RespawnPoint component on the player or elsewhere
            RespawnPoint respawnPoint = other.GetComponent<RespawnPoint>();

            if (respawnPoint != null)
            {
                // Update the respawn location to this checkpoint's position
                respawnPoint.UpdateRespawnLocation(transform);
                Debug.Log("Respawn location updated to checkpoint: " + transform.position);
            }
            else
            {
                Debug.LogWarning("No RespawnPoint component found on: " + other.name);
            }
        }
    }
}

