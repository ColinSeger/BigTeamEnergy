using UnityEngine;
using FMODUnity;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public int BubbleNumber = 0;
    public GameObject smallBubblePrefab;
    [SerializeField] GameObject mediumBubblePrefab;
    [SerializeField] GameObject largeBubblePrefab;
    [SerializeField] Sprite sprite;
    [SerializeField] Sprite spriter;
    [SerializeField] private EventReference mergeSound;
    
    private void Start()
    {
    }
    public void MergeBubble(Bubble firstBubble, Bubble secondBubble)
    {
        

        var sprite1 = firstBubble.GetComponent<SpriteRenderer>();
        var sprite2 = secondBubble.GetComponent<SpriteRenderer>();

        sprite1.sprite = sprite;
        sprite2.sprite = spriter;
        firstBubble.transform.rotation.SetLookRotation(secondBubble.transform.position);
        secondBubble.transform.rotation.SetLookRotation(firstBubble.transform.position);
        StartCoroutine(KillerBubble(firstBubble, secondBubble));
        
    }
    IEnumerator KillerBubble(Bubble firstBubble, Bubble secondBubble){
        yield return null;
        Vector2 pos = (firstBubble.transform.position + secondBubble.transform.position) / 2;
        GameObject size = SetSize(firstBubble.Size);
        Vector2 vel = firstBubble.rb.linearVelocity + secondBubble.rb.linearVelocity;
        
        if(firstBubble){
            Destroy(firstBubble.gameObject);
        }
        if(secondBubble){
            Destroy(secondBubble.gameObject);            
        }
        
        GameObject mergedBubble = Instantiate(size, pos, firstBubble.transform.rotation);
        Bubble mergedBubbleScript = mergedBubble.GetComponent<Bubble>();
        AudioManager.instance.PlayOneShot(mergeSound);
        mergedBubbleScript.rb.AddForce(vel, ForceMode2D.Impulse);
    }
    GameObject SetSize(int size)
    {
        if (size == 1)
        {
            return mediumBubblePrefab;
        }
        else if (size == 2)
        {
            return largeBubblePrefab;
        }
        else return null;
    }
}
