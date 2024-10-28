using UnityEngine;

public class BallGrowthController : MonoBehaviour
{
    
    private Vector3 scaleChange;
    public GameObject ball;
    private SphereCollider sphereCollider;

    void Start()
    {
        scaleChange = Vector3.zero;
        sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setMoving() 
    {
        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    }

    public void setStationary()
    {
        scaleChange = Vector3.zero;
    }


    private void OnCollisionStay(Collision other) {
    if (other.collider.tag=="Snow");

        ball.transform.localScale += scaleChange;

    }

}
