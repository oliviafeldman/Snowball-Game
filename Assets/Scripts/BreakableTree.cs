using UnityEngine;

public class BreakableTree : MonoBehaviour
{
    public float sizeThreshold = 3f;
    public Rigidbody treeRigidbody;

    private bool hasFallen = false;

    void Start()
    {
        if (treeRigidbody == null)
        {
            treeRigidbody = GetComponent<Rigidbody>();
        }
        
        if (treeRigidbody != null)
        {
            treeRigidbody.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasFallen) return;

        Collider collider = collision.collider;
        Vector3 colliderSize = collider.bounds.size;

        float colliderVolume = colliderSize.x * colliderSize.y * colliderSize.z;

        if (colliderVolume > sizeThreshold)
        {
            TriggerFall();
            hasFallen = true;
        }
    }

    void TriggerFall()
    {
        if (treeRigidbody != null)
        {
            treeRigidbody.isKinematic = false;
        }
    }
}

