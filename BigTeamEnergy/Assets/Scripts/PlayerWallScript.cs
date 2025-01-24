using UnityEngine;

public class PlayerWallScript : MonoBehaviour
{
    [SerializeField] int playerNum;

    private void OnCollisionEnter(Collision collision)
    {
            if (playerNum == 1) ScoreManager.Instance.P1Score += 1;
            if (playerNum == 2) ScoreManager.Instance.P2Score += 2;

            ScoreManager.Instance.SetScoreText();
        }
    }
