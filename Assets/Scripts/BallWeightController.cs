using UnityEngine;

public class BallWeightController : MonoBehaviour
{

    private Rigidbody rigidbody;

    public float weightSpeed = 0.03f;

    private float weightChange;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
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
        weightChange = weightSpeed * -3;
    }
}
