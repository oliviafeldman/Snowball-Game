using Unity.Cinemachine;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static float SizeID = Shader.PropertyToID("_Size");
    public Material WallMaterial;
    public CinemachineCamera Camera;

    public LayerMask Mask;

    private float currentSize = 0f;
    public float growthSpeed = 1f;
    public float maxSize = 0.5f;

    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, Mask)) {
            currentSize = Mathf.MoveTowards(currentSize, maxSize, growthSpeed * Time.deltaTime);
        } else {
            currentSize = Mathf.MoveTowards(currentSize, 0f, growthSpeed * Time.deltaTime);
        }

        WallMaterial.SetFloat((int)SizeID, currentSize);
    }
}
