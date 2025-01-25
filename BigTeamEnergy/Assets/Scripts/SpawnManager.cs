using UnityEngine;

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

    private void Start()
    {
    }
    public void MergeBubble(Bubble firstBubble, Bubble secondBubble)
    {
        Vector2 pos = (firstBubble.transform.position + secondBubble.transform.position) / 2;
        GameObject size = SetSize(firstBubble.Size);
        Vector2 vel = firstBubble.rb.linearVelocity + secondBubble.rb.linearVelocity;

        Destroy(firstBubble.gameObject);
        Destroy(secondBubble.gameObject);
        GameObject mergedBubble = Instantiate(size, pos, firstBubble.transform.rotation);
        Bubble mergedBubbleScript = mergedBubble.GetComponent<Bubble>();

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
