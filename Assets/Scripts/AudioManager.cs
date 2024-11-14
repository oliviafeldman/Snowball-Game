using System.Collections.Generic;
using System.Collections;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Audio Manager");
        }
        instance = this;
     }
    
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
