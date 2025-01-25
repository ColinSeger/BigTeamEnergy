using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Bubble : MonoBehaviour
{
    public int Value;
    public int Size;
    public int BubbleId;


    public Rigidbody2D rb;

    private void Start()
    {
        SpawnManager.Instance.BubbleNumber += 1;
        BubbleId = SpawnManager.Instance.BubbleNumber;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bubble colidedBubble = collision.gameObject.GetComponent<Bubble>();

        BubbleCollision(colidedBubble);
      
    }
    private void Update()
    {
        if(RoundManager.Instance != null)
        {
        if (!RoundManager.Instance.isRound) Destroy(this.gameObject);

        }
    }

    void BubbleCollision(Bubble colidedBubble)
    {
        if (colidedBubble != null)
        {
            if (colidedBubble.Size == 3)
            {
            
                PlayOneShotWithParameter("Large Bounce", 0f);
                return;
            }
            else if (colidedBubble.Size > Size || colidedBubble.Size < Size) 
            {
               
                if (Size == 2)
                {
                   
                    PlayOneShotWithParameter("Medium Bounce", 0f);
                }
                return;
            }
        else if (colidedBubble.Size == Size)
        {
            if (colidedBubble.BubbleId > BubbleId)
            {
                return;
            }
            else
            {
                SpawnManager.Instance.MergeBubble(this, colidedBubble);
            }
        }
        }
    }


    //[EventRef]
    public string EventReference; // Assign in the Inspector

    public void PlayOneShotWithParameter(string paramName, float paramValue)
    {
        // Create an instance of the event
        EventInstance instance = RuntimeManager.CreateInstance(EventReference);

        // Set the parameter
        instance.setParameterByName(paramName, paramValue);
        
        Debug.Log(paramValue);

        // Start playback (one-shot)
        instance.start();

        // Release the instance to free memory once it finishes
        instance.release();
    }



}
