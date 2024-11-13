using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

public class BallTerrainDetection : MonoBehaviour
{

    public String terrainType;

    private void OnCollisionStay(Collision other) {
        if (other.collider.tag=="Snow") {

            terrainType = "Snow";

        }

        if (other.collider.tag=="Ground") {

            terrainType = "Ground";
        }

        if (other.collider.tag=="Fire") {
            terrainType = "Fire";
        }
    }
}    
