using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Vector3 respawnLocation;

    void Start()
    {
        if (respawnLocation == null)
        {
            respawnLocation = transform.position;
        }
    }

    public void Respawn()
    {
        transform.position = respawnLocation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void UpdateRespawnLocation(Vector3 newRespawnLocation)
    {
        if (newRespawnLocation != null)
        {
            respawnLocation = newRespawnLocation;
        }

    }
}
