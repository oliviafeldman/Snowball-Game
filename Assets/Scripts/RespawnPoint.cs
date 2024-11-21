using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Transform respawnLocation;

    void Start()
    {
        if (respawnLocation == null)
        {
            respawnLocation = transform;
        }
    }

    public void Respawn()
    {
        transform.position = respawnLocation.position;
        transform.rotation = respawnLocation.rotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void UpdateRespawnLocation(Transform newRespawnLocation)
    {
        if (newRespawnLocation != null)
        {
            respawnLocation = newRespawnLocation;
        }

    }
}
