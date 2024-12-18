using UnityEngine;

public class BallWeightController : MonoBehaviour
{

    private Rigidbody Rigidbody;

    public float weightSpeed = 0.03f;

    private float weightChange;

    public BallSizeController ballSizeController;

    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        ballSizeController = GetComponent<BallSizeController>();
        weightChange = 0;
    }

    void Update()
    {
        if (weightChange != 0) {
            Rigidbody.mass += weightChange*Time.deltaTime;
        }
    }
    
    public void gainWeight() 
    {
        if (ballSizeController.ShouldGrow()) {
            weightChange = weightSpeed;
        } else {
            weightChange = 0;
        }
    }

    public void steadyWeight()
    {
        weightChange = 0;
    }

    public void loseWeight() 
    {
        if (ballSizeController.ShouldShrink()) {
            weightChange = weightSpeed * -3;
        } else {
            weightChange = 0;
        }
    }
}
