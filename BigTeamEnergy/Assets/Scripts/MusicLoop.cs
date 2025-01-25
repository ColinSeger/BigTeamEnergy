using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/MusicMain");
    }
}
