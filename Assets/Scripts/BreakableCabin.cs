using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject[] cabinParts; 
    public float baseForce = 500f; 
    public float radiusMultiplier = 2f; 
    public float sizeThreshold = 1f; // Minimum size of the collider to break
    public BoxCollider boxCollider;

    private bool hasBroken = false;

    void OnCollisionEnter(Collision collision)
    {
        if (hasBroken) return;

        Collider collider = collision.collider;
        Vector3 colliderSize = collider.bounds.size;

        float colliderVolume = colliderSize.x * colliderSize.y * colliderSize.z;

        if (colliderVolume > sizeThreshold)
        {
            Vector3 impactPoint = collision.GetContact(0).point;
            BreakCabin(impactPoint);
            hasBroken = true;
            boxCollider.enabled = false;
        }
    }

    void BreakCabin(Vector3 impactPoint)
    {
        foreach (GameObject part in cabinParts)
        {
            Rigidbody rb = part.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;

                float distance = Vector3.Distance(impactPoint, part.transform.position);

                float force = Mathf.Clamp(baseForce / (distance + 1), 0, baseForce);

                Vector3 direction = (part.transform.position - impactPoint).normalized;

                rb.AddForce(direction * force, ForceMode.Impulse);

                Vector3 randomTorque = Random.insideUnitSphere * force * 0.1f;
                rb.AddTorque(randomTorque, ForceMode.Impulse);
            }
        }
    }
}
