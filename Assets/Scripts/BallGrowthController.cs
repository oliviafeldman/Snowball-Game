using UnityEngine;

public class BallGrowthController : MonoBehaviour
{
    
    private Vector3 scaleChange;
    public GameObject ball;
    private SphereCollider sphereCollider;

    private BallMovementController movementController;
    private BallTerrainDetection terrainDetection;

    public float scaleSpeed = 0.5f;

    void Start()
    {
        scaleChange = Vector3.zero;
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        movementController = gameObject.GetComponent<BallMovementController>();
        terrainDetection = gameObject.GetComponent<BallTerrainDetection>();
    }

    void Update() {
        if (terrainDetection.terrainType == "Snow" && movementController.isMoving) {
            startGrowing();
        } else {
            stopGrowing();
        }

        if (terrainDetection.terrainType == "Fire") {
            startShrinking();
        }

        if (scaleChange != Vector3.zero) {
            ball.transform.localScale += scaleChange * Time.deltaTime;
        }
    }

    public void startGrowing() 
    {
        scaleChange = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
    }

    public void stopGrowing()
    {
        scaleChange = Vector3.zero;
    }

    public void startShrinking() {
        scaleChange = new Vector3(scaleSpeed * -1, scaleSpeed * -1, scaleSpeed * -1);
    }

}
