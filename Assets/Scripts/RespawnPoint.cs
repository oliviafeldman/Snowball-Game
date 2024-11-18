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

    public void Respawn(GameObject obj)
    {
        obj.transform.position = respawnLocation.position;
        obj.transform.rotation = respawnLocation.rotation;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
