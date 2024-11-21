using UnityEngine;

public class PlayerRespawnSystem : MonoBehaviour
{
    [SerializeField]
    private RespawnPoint respawnPoint;
    [SerializeField]
    private float fallThreshold = -10f;

    void Start() {
        respawnPoint = GetComponent<RespawnPoint>();
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            respawnPoint.Respawn();
        }
    }
}
