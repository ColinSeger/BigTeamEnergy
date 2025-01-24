using UnityEngine;

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

    void BubbleCollision(Bubble colidedBubble)
    {
        if (colidedBubble != null)
        {
            if (colidedBubble.Size == 3) return;
            else if (colidedBubble.Size > Size || colidedBubble.Size < Size) return;
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

}
