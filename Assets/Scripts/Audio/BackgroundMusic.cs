using System;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private EventReference musicEvent; // Assign the FMOD music event in the Inspector
    private EventInstance musicInstance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (musicEvent.IsNull)
        {
            Debug.LogError("No music event assigned to BackgroundMusic script.");
            return;
        }

        musicInstance = RuntimeManager.CreateInstance(musicEvent);
        musicInstance.start();
    }

    private void OnDestroy()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
        }
    }
}

