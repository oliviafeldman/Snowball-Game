using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        // Ensure the EventReference is valid
        if (eventReference.IsNull)
        {
            Debug.LogError("EventReference is null. Assign a valid FMOD Event in the Inspector.");
            return default;
        }

        // Use RuntimeManager to create and return the EventInstance
        return RuntimeManager.CreateInstance(eventReference);
    }
}