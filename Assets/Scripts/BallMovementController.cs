using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rigBod;
    private BallGrowthController growthController;

    private void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
        growthController = gameObject.GetComponent<BallGrowthController>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigBod.AddForce(Vector3.right * speed);
            growthController.setMoving();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigBod.AddForce(Vector3.left * speed);
            growthController.setMoving();
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigBod.AddForce(Vector3.forward * speed);
            growthController.setMoving();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigBod.AddForce(Vector3.back * speed);
            growthController.setMoving();
        }
        else
        {
            growthController.setStationary();
        }
    }
}    
