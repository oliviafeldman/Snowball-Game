using UnityEngine;

public class BallWeightController : MonoBehaviour
{

    private Rigidbody rigidbody;

    public float weightSpeed = 0.03f;

    private float weightChange;

    public BallSizeController ballSizeController;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        ballSizeController = GetComponent<BallSizeController>();
        weightChange = 0;
    }

    void Update()
    {
        if (weightChange != 0) {
            rigidbody.mass += weightChange*Time.deltaTime;
        }
    }
    
    public void gainWeight() 
    {
        weightChange = weightSpeed;
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
