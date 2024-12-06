using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FireCrackleAudio : MonoBehaviour
{
    [SerializeField] private EventReference fireCrackleEvent; // Assign in Unity Inspector
    private EventInstance fireCrackleInstance;

    void Start()
    {
        // Ensure the AudioManager exists and the event reference is valid
        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager instance not found. Ensure AudioManager is in the scene.");
            return;
        }
        
        if (fireCrackleEvent.IsNull)
        {
            Debug.LogError("No fire crackle event assigned in the Inspector.");
            return;
        }

        fireCrackleInstance = AudioManager.instance.CreateInstance(fireCrackleEvent);

        fireCrackleInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        fireCrackleInstance.start();
    }

    void Update()
    {

        if (fireCrackleInstance.isValid())
        {
            fireCrackleInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        }
    }
}
