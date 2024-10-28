using Unity.Physics;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;

    private void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigBod.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigBod.AddForce(Vector3.left * speed);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigBod.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigBod.AddForce(Vector3.back * speed);
        }

    }
}    
