using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class MusicLoop : MonoBehaviour
{
  

    private EventInstance musicLoop;

    [SerializeField] private EventReference musicEvent;  // Assign your FMOD music event in Inspector
    private EventInstance musicInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        musicLoop = AudioManager.instance.CreateInstance(FmodEvents.instance.MusicMain);
        PlayMusicLoop();
    }


    public void PlayMusicLoop()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicInstance.release();
        }

        if (!musicEvent.IsNull)
        {
            musicInstance = RuntimeManager.CreateInstance(musicEvent);
            musicInstance.start();
            musicInstance.setParameterByName("Loop", 1);  // Optional: Set loop parameter if needed
            musicInstance.release();  // Release the instance to avoid memory leaks
        }
        else
        {
            Debug.LogWarning("FMOD music event not assigned.");
        }
    }

    public void StopMusic()
    {
        if (musicInstance.isValid())
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicInstance.release();
        }
    }

}
