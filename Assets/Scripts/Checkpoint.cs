using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnPoint respawnPoint = other.GetComponent<RespawnPoint>();

            if (respawnPoint != null)
            {
                respawnPoint.UpdateRespawnLocation(transform.position);
            }
        }
    }
}

