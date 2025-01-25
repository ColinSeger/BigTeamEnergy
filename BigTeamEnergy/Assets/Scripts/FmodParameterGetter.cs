using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FmodParameterGetter : MonoBehaviour
{

    //[EventRef]
    //public string eventPath; // Assign FMOD event path in Inspector

    //private EventInstance eventInstance;

    //void Start()
    //{
    //    // Create an instance of the event
    //    eventInstance = RuntimeManager.CreateInstance(eventPath);

    //    // Start playing the event
    //    eventInstance.start();

    //    SetParameter("Speed", 5.0f);
    //}

    //// Function to set a specific FMOD parameter
    //public void SetParameter(string paramName, float value)
    //{
    //    eventInstance.setParameterByName(paramName, value);
    //}

    //// Function to get the value of an FMOD parameter
    //public float GetParameter(string paramName)
    //{
    //    float value;
    //    eventInstance.getParameterByName(paramName, out value);
    //    return value;
    //}

    //private void OnDestroy()
    //{
    //    eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    //    eventInstance.release();
    //}


}
