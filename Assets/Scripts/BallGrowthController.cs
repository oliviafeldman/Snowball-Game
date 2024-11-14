using UnityEngine;

public class BallGrowthController : MonoBehaviour
{

    private BallMovementController movementController;
    private BallTerrainDetection terrainDetection;
    private BallWeightController weightController;
    private BallSizeController sizeController;
    private BallFireDetector ballFireDetector;

    void Start()
    {
        movementController = gameObject.GetComponent<BallMovementController>();
        terrainDetection = gameObject.GetComponent<BallTerrainDetection>();
        weightController = gameObject.GetComponent<BallWeightController>();
        sizeController = gameObject.GetComponent<BallSizeController>();
        ballFireDetector = gameObject.GetComponent<BallFireDetector>();

    }

    void Update() {
        if (terrainDetection.terrainType == "Snow" && movementController.isMoving && ballFireDetector.ballStatus != "Melting") {
            startGrowing();
        } else {
            stopGrowing();
        }

        if (ballFireDetector.ballStatus == "Melting") {
            startShrinking();
        }
    }

    public void startGrowing() 
    {
        weightController.gainWeight();
        sizeController.gainSize();
    }

    public void stopGrowing()
    {
        weightController.steadyWeight();
        sizeController.steadySize();
    }

    public void startShrinking() {
        weightController.loseWeight();
        sizeController.loseSize();
    }

}
