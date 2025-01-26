using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class WindLoop : MonoBehaviour
{

    private EventInstance windLoop;

    [SerializeField] private EventReference windEvent;  // Assign your FMOD music event in Inspector
    private EventInstance windInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        windLoop = AudioManager.instance.CreateInstance(FmodEvents.instance.MusicMain);
        PlayWindLoop();
    }


    public void PlayWindLoop()
    {
        if (windInstance.isValid())
        {
            windInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            windInstance.release();
        }

        if (!windEvent.IsNull)
        {
            windInstance = RuntimeManager.CreateInstance(windEvent);
            windInstance.start();
            windInstance.setParameterByName("Loop", 1);  // Optional: Set loop parameter if needed
            windInstance.release();  // Release the instance to avoid memory leaks
        }
        else
        {
            Debug.LogWarning("FMOD music event not assigned.");
        }
    }

    public void StopWind()
    {
        if (windInstance.isValid())
        {
            windInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            windInstance.release();
        }
    }



    
}
