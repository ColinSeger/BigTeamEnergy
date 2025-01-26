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
    public int winScore = 100;

    public int P1Wins;
    public int P2Wins;

    [SerializeField] TextMeshProUGUI p1TextMesh;
    [SerializeField] TextMeshProUGUI p2TextMesh;
    [SerializeField] TextMeshProUGUI winnerWinner;
    public GameObject PopUp;

    public void SetScoreText()
    {
        p1TextMesh.text = "" +P1Score;
        p2TextMesh.text = "" + P2Score;
    }

    void Update(){
        //if(P1Score >= winScore){
        //    Debug.Log("Player 1 won");
        //    winnerWinner.text = "Player 1 won";
        //    winnerWinner.gameObject.SetActive(true);
        //    Time.timeScale = 0f;
        //}
        //if(P2Score >= winScore){
        //    Debug.Log("Player2 won");
        //    winnerWinner.text = "Player 2 won";
        //    winnerWinner.gameObject.SetActive(true);
        //    Time.timeScale = 0f;
        //}
    }

}
