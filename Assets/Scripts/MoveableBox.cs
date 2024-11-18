using UnityEngine;

public class MoveableBox : MonoBehaviour
{
    public float sizeThreshold = 3f;
    public Rigidbody boxRigidbody;

    void Start()
    {
        if (boxRigidbody == null)
        {
            boxRigidbody = GetComponent<Rigidbody>();
        }
        
        if (boxRigidbody != null)
        {
            boxRigidbody.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        Vector3 colliderSize = collider.bounds.size;

        float colliderVolume = colliderSize.x * colliderSize.y * colliderSize.z;

        if (colliderVolume > sizeThreshold)
        {
            Move();
        }
    }

    void Move()
    {
        if (boxRigidbody != null)
        {
            boxRigidbody.isKinematic = false;
        }
    }

}
