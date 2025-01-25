using UnityEngine;
enum Players :byte{
    Player1,
    Player2
}
public class PlayerWallScript : MonoBehaviour
{
    [SerializeField] Players playerNum;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bubble colidedBubble = collision.gameObject.GetComponent<Bubble>();

        if (colidedBubble != null)
        {
            if (playerNum == Players.Player1) ScoreManager.Instance.P1Score += colidedBubble.Value;
            if (playerNum == Players.Player2) ScoreManager.Instance.P2Score += colidedBubble.Value;

            Destroy(colidedBubble.gameObject);

            ScoreManager.Instance.SetScoreText();
        }
    }
}
