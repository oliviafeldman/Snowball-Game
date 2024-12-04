using Unity.Cinemachine;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static float SizeID = Shader.PropertyToID("_Size");
    public Material WallMaterial;
    public Material SnowMaterial;
    public CinemachineCamera Camera;

    public LayerMask Mask;

    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, Mask)) {
            WallMaterial.SetFloat((int)SizeID, 0.5f);
            SnowMaterial.SetFloat((int)SizeID, 0.5f);
        } else {
            WallMaterial.SetFloat((int)SizeID, 0);
            SnowMaterial.SetFloat((int)SizeID, 0);
        }
        
    }
}
