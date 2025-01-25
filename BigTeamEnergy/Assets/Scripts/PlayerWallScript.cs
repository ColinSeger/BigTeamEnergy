using UnityEngine;
<<<<<<< Updated upstream

enum Players : byte
{
=======
using TMPro;
enum Players :byte{
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
            // Instantiate the particle effect at the bubble's position
            if (bubblePopEffect != null)
            {
                Instantiate(bubblePopEffect, collidedBubble.transform.position, Quaternion.identity);
            }
=======

            GameObject spawnedPopUp = Instantiate(ScoreManager.Instance.PopUp, collision.transform.position, ScoreManager.Instance.PopUp.transform.rotation);
            
            spawnedPopUp.GetComponent<TextMeshPro>().text = "+" + colidedBubble.Value;
            Destroy(colidedBubble.gameObject);
>>>>>>> Stashed changes

            // Destroy the bubble
            Destroy(collidedBubble.gameObject);

            // Update score text
            ScoreManager.Instance.SetScoreText();
        }
    }
}