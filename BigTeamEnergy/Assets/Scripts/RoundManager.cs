using UnityEngine;
using TMPro;
public class RoundManager : MonoBehaviour
{

[SerializeField] TextMeshProUGUI timerDisplay;

    [SerializeField] float roundTime;
    [SerializeField] GameObject endRoundMenu;
    [SerializeField] TextMeshProUGUI P1WinsText;
    [SerializeField] TextMeshProUGUI P2WinsText;

    float timer;
    public int round;
    bool isRound = true;

    private void Start()
    {
        timer = roundTime;
    }
    private void Update()
    {
        if (isRound) timerHandler();

        if (
            timer <= 0 
            || ScoreManager.Instance.P1Score>= ScoreManager.Instance.winScore 
            || ScoreManager.Instance.P2Score>= ScoreManager.Instance.winScore 
            )
        {
            if(isRound) EndRound();

        }
    }
    void timerHandler()
    {
        timer -= Time.deltaTime;
        timerDisplay.text = "time left: " + timer;
    }
    public void newRound()
    {
        round += 1;

        isRound = true;

        ScoreManager.Instance.P1Score = 0;
        ScoreManager.Instance.P2Score = 0;

        timer = roundTime;

    }
    void EndRound()
    {
        isRound = false;

             if (ScoreManager.Instance.P1Score > ScoreManager.Instance.P2Score) ScoreManager.Instance.P1Wins += 1;
        else if (ScoreManager.Instance.P2Score > ScoreManager.Instance.P1Score) ScoreManager.Instance.P2Wins += 1;

        P1WinsText.text = "player One Wins: " + ScoreManager.Instance.P1Wins;
        P2WinsText.text = "player Two Wins: " + ScoreManager.Instance.P2Wins;

        endRoundMenu.SetActive(true);
    }
}
