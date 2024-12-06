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

        // Create an EventInstance from the EventReference
        fireCrackleInstance = AudioManager.instance.CreateInstance(fireCrackleEvent);

        // Set 3D attributes for the fire's position and start the sound
        fireCrackleInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        fireCrackleInstance.start();
    }

    void Update()
    {
        // Update 3D attributes for positional audio
        if (fireCrackleInstance.isValid())
        {
            fireCrackleInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        }
    }
}
