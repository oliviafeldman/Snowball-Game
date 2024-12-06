using System;
using UnityEngine;

public class BallFireDetector : MonoBehaviour
{
    
    public String ballStatus;
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] LayerMask fireLayerMask;

    void Update() {
        Collider[] detectedFires = Physics.OverlapSphere(transform.position, sphereCollider.radius * sphereCollider.transform.localScale.x, fireLayerMask);
        if (detectedFires.Length > 0) {
            ballStatus = "Melting";
        } else {
            ballStatus = "Chilling";
        }
    }

}
