using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

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

    public int P1Score;
    public int P2Score;

    [SerializeField] TextMeshProUGUI p1TextMesh;
    [SerializeField] TextMeshProUGUI p2TextMesh;

    public void SetScoreText()
    {
        p1TextMesh.text = "player 1 Score: " + P1Score;
        p2TextMesh.text = "player 2 Score: " + P2Score;
    }


}
