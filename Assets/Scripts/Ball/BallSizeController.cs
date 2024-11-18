using Unity.VisualScripting;
using UnityEngine;

public class BallSizeController : MonoBehaviour
{
    public GameObject ball;
    public float scaleSpeed = 0.1f;

    public float minSize = 5f;
    
    public float maxSize = 20f;

    private Vector3 scaleChange;


    void Start()
    {
        scaleChange = Vector3.zero;
    }

    void Update()
    {
        if (scaleChange != Vector3.zero) {
            ball.transform.localScale += scaleChange * Time.deltaTime;
        }

        if (!ShouldShrink()) {

        }
    }

    public bool ShouldShrink() {
        return ball.transform.localScale.x > minSize;
    }

    public bool ShouldGrow() {
        return ball.transform.localScale.x < maxSize;
    }

    public void gainSize() 
    {
        if (ShouldGrow()) {
            scaleChange = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
        } else {
            scaleChange = Vector3.zero;
        }
    }

    public void steadySize()
    {
        scaleChange = Vector3.zero;
    }

    public void loseSize() {
        if (ShouldShrink()) {
            scaleChange = new Vector3(scaleSpeed * -3, scaleSpeed * -3, scaleSpeed * -3);
        } else {
            scaleChange = Vector3.zero;
        }

    }

}
