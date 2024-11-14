using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject[] cabinParts; 
    public float baseForce = 500f; 
    public float radiusMultiplier = 2f; 
    public float damageThreshold = 5f; 
    public BoxCollider boxCollider;

    private bool hasBroken = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasBroken && collision.relativeVelocity.magnitude > damageThreshold)
        {
            Vector3 impactPoint = collision.GetContact(0).point; 
            BreakCabin(impactPoint, collision.relativeVelocity.magnitude);
            hasBroken = true;
            boxCollider.enabled = false;
        }
    }

    void BreakCabin(Vector3 impactPoint, float impactForce)
    {
        float explosionRadius = impactForce * radiusMultiplier;

        foreach (GameObject part in cabinParts)
        {
            Rigidbody rb = part.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;

                
                float distance = Vector3.Distance(impactPoint, part.transform.position);

                
                float force = Mathf.Clamp(baseForce / (distance + 1), 0, baseForce) * impactForce;

                Vector3 direction = (part.transform.position - impactPoint).normalized;

                rb.AddForce(direction * force, ForceMode.Impulse);

                Vector3 randomTorque = Random.insideUnitSphere * force * 0.1f;
                rb.AddTorque(randomTorque, ForceMode.Impulse);
            }
        }
    }
}
