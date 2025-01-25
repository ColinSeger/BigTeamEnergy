using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;

public class GruntRandomiser : MonoBehaviour
{
    [SerializeField] private EventReference soundEvent;  // Assign the FMOD event in Inspector
    public float minInterval = 2f;   // Minimum delay between sounds
    public float maxInterval = 5f;   // Maximum delay between sounds
    [Range(0f, 1f)] public float playChance = 0.5f;

    private void OnDestroy()
    {
            StartCoroutine(PlaySoundWithRandomChance());
    }

    private IEnumerator PlaySoundWithRandomChance()
    {
        while (true)
        {
            float randomDelay = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randomDelay);

            float randomValue = Random.value;  // Generates a value between 0.0 and 1.0
            if (randomValue <= playChance)
            {
                if (!soundEvent.IsNull)
                {
                    FMOD.Studio.EventInstance soundInstance = RuntimeManager.CreateInstance(soundEvent);
                    soundInstance.start();
                    soundInstance.release();  // Release the instance to avoid memory leaks
                }
                else
                {
                    Debug.LogWarning("FMOD event not assigned.");
                }
            }
        }

    }
}
