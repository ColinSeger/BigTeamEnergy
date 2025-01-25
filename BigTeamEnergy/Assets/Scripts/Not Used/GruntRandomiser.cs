using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;

public class SoundRandomiser : MonoBehaviour
{
    [SerializeField] private EventReference soundEvent;  // Assign the FMOD event in Inspector
    public float minInterval = 2f;   // Minimum delay between sounds
    public float maxInterval = 5f;   // Maximum delay between sounds

    private void Start()
    {
        StartCoroutine(PlaySoundAtRandomIntervals());
    }

    private IEnumerator PlaySoundAtRandomIntervals()
    {
        while (true)
        {
            float randomDelay = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randomDelay);

            if (soundEvent.IsNull)
            {
                Debug.LogWarning("FMOD event not assigned.");
                continue;
            }

            FMOD.Studio.EventInstance soundInstance = RuntimeManager.CreateInstance(soundEvent);
            soundInstance.start();
            soundInstance.release();  // Release the instance to avoid memory leaks
        }
    }

}
