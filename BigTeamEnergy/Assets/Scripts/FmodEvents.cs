using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FmodEvents : MonoBehaviour
{
    [field: Header("Music Looop")]

    [field: SerializeField] public EventReference MusicMain{ get; private set; }
    public static FmodEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Fmod Events scrips");
        }
        instance = this;
    }

    
}
