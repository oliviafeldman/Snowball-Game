using FMODUnity;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private EventReference musicEvent; 
    private EventInstance musicInstance;
    private static bool musicStarted = false; // Tracks if music has already started

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ResetMusic();
        }
    }

    private void Start()
    {
        if (musicEvent.IsNull)
        {
            Debug.LogError("No music event assigned to BackgroundMusic script.");
            return;
        }

        if (!musicStarted)
        {
            musicInstance = RuntimeManager.CreateInstance(musicEvent);
            musicInstance.start();
            musicStarted = true;
        }
    }

    private void OnDestroy()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
        }
    }

    private void ResetMusic()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
            musicStarted = false;
        }
    }
}


