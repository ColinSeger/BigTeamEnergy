using UnityEngine;

public class PlayerWallScript : MonoBehaviour
{
    [SerializeField] int playerNum;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bubble colidedBubble = collision.gameObject.GetComponent<Bubble>();

        if (colidedBubble != null)
        {
            if (playerNum == 1) ScoreManager.Instance.P2Score += colidedBubble.Value;
            if (playerNum == 2) ScoreManager.Instance.P2Score += colidedBubble.Value;

            Destroy(colidedBubble.gameObject);

            ScoreManager.Instance.SetScoreText();
        }
    }
}
