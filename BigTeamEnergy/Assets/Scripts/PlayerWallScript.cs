using UnityEngine;

enum Players : byte
{
    Player1,
    Player2
}

public class PlayerWallScript : MonoBehaviour
{
    [SerializeField] private Players playerNum;
    // Assign your particle effect prefab here in the Inspector
    [SerializeField] private GameObject bubblePopEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bubble collidedBubble = collision.gameObject.GetComponent<Bubble>();

        if (collidedBubble != null)
        {
            // Update score
            if (playerNum == Players.Player1)
            {
                ScoreManager.Instance.P1Score += collidedBubble.Value;
            }
            else if (playerNum == Players.Player2)
            {
                ScoreManager.Instance.P2Score += collidedBubble.Value;
            }

            // Instantiate the particle effect at the bubble's position
            if (bubblePopEffect != null)
            {
                Instantiate(bubblePopEffect, collidedBubble.transform.position, Quaternion.identity);
            }

            // Destroy the bubble
            Destroy(collidedBubble.gameObject);

            // Update score text
            ScoreManager.Instance.SetScoreText();
        }
    }
}