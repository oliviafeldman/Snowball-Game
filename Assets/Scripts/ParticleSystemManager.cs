using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectController : MonoBehaviour
{
    [SerializeField]
    private Transform ball;
    [SerializeField]
    private ParticleSystem particleEffect;
    
    private BallTerrainDetection terrainDetection;
    private Transform originalParent;
    void Start()
    {
        terrainDetection = ball.GetComponent<BallTerrainDetection>();
        if (terrainDetection == null)
        {
            Debug.LogError("TerrainDetection component is missing on the ball!");
        }

        originalParent = particleEffect.transform.parent;
    }

    void Update()
    {
        if (terrainDetection != null && terrainDetection.terrainType == "Snow")
        {
            ReattachParticleEffect();
        }
        else
        {
            DetachParticleEffect();
        }
    }

    private void DetachParticleEffect()
    {
        if (particleEffect.transform.parent != null)
        {
            particleEffect.transform.parent = null;
            Debug.Log("Particle effect detached.");
        }
    }

    private void ReattachParticleEffect()
    {
        if (particleEffect.transform.parent == null)
        {
            particleEffect.transform.parent = ball; 
            particleEffect.transform.position = ball.position;
            particleEffect.transform.localRotation = Quaternion.identity;
            Debug.Log("Particle effect reattached at snow terrain.");
        }
    }
}