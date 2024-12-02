using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

public class BallTerrainDetection : MonoBehaviour
{

    public String terrainType;

    void OnCollisionExit(Collision other)
    {
        terrainType = "Untagged";
    }

    private void OnCollisionStay(Collision other) {
        terrainType = other.collider.gameObject.tag;

    }

}    
