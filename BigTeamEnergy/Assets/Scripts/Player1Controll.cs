using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;

public class Player1Controll : MonoBehaviour
{
    [SerializeField]float speed;
    float distance = 0.2f;

    // Audio stuff
    [SerializeField] private EventReference soundEvent;  // Assign the FMOD event in Inspector
    public float minInterval = 2f;   // Minimum delay between sounds
    public float maxInterval = 5f;   // Maximum delay between sounds
    [Range(0f, 1f)] public float playChance = 0.5f;  // Chance to play sound (0.0 to 1.0)
    void FixedUpdate(){
        var up = Physics2D.Raycast(this.transform.position ,Vector2.up, distance);
        var down = Physics2D.Raycast(this.transform.position ,Vector2.down, distance);
        if(Input.GetKey(KeyCode.W) && !up){
            this.transform.position += new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
            StartCoroutine(PlaySoundWithRandomChance());
            StopCoroutine(PlaySoundWithRandomChance());
        }
        else if(Input.GetKey(KeyCode.S) && !down){
            this.transform.position -= new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
            StartCoroutine(PlaySoundWithRandomChance());
            StopCoroutine(PlaySoundWithRandomChance());
        } 
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
