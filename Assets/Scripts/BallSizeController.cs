using UnityEngine;

public class BallSizeController : MonoBehaviour
{
    public static BallSizeController Instance;
    public float CurrentScale => transform.localScale.x;

    public GameObject ball;
    public float scaleSpeed = 0.1f;

    private Vector3 scaleChange;


    void Start()
    {
        Instance = this;
        scaleChange = Vector3.zero;
    }

    void Update()
    {
        if (scaleChange != Vector3.zero) {
            ball.transform.localScale += scaleChange * Time.deltaTime;
        }
    }

    public void gainSize() 
    {
        scaleChange = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
    }

    public void steadySize()
    {
        scaleChange = Vector3.zero;
    }

    public void loseSize() {
        scaleChange = new Vector3(scaleSpeed * -3, scaleSpeed * -3, scaleSpeed * -3);
    }

}
