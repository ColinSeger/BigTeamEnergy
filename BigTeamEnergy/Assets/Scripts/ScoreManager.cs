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
    [SerializeField] int winScore = 100;

    [SerializeField] TextMeshProUGUI p1TextMesh;
    [SerializeField] TextMeshProUGUI p2TextMesh;
    [SerializeField] TextMeshProUGUI winnerWinner;

    public void SetScoreText()
    {
        p1TextMesh.text = "player 1 Score: " + P1Score;
        p2TextMesh.text = "player 2 Score: " + P2Score;
    }

    void Update(){
        if(P1Score >= winScore){
            //Debug.Log("Player 1 won");
            winnerWinner.text = "Player 1 won";
            winnerWinner.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if(P2Score >= winScore){
            //Debug.Log("Player2 won");
            winnerWinner.text = "Player 2 won";
            winnerWinner.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
