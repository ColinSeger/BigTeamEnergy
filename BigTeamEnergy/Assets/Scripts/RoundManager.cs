using UnityEngine;
using TMPro;
using FMODUnity;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;

    public static MusicLoop musicLoop;

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

    [SerializeField] TextMeshProUGUI timerDisplay;

    [SerializeField] float roundTime;
    [SerializeField] GameObject endRoundMenu;
    [SerializeField] TextMeshProUGUI P1WinsText;
    [SerializeField] TextMeshProUGUI P2WinsText;
    [SerializeField] WaveManager spawner;
    [SerializeField] GameObject scoreMenu;

    [SerializeField] private EventReference gameDoneSound;

    float timer;
    public int round;
    public bool isRound = true;

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
        timerDisplay.text = "time left: " + timer.ToString("F0");
    }
    public void newRound()
    {
        scoreMenu.SetActive(true);
        Time.timeScale = 1f;
        round += 1;

        isRound = true;

        ScoreManager.Instance.P1Score = 0;
        ScoreManager.Instance.P2Score = 0;
        ScoreManager.Instance.SetScoreText();

        timer = roundTime;
        spawner.gameObject.SetActive(true);
        spawner.StartCoroutine(spawner.WaveSpawn());

    }
    void EndRound()
    {
        isRound = false;
        scoreMenu.SetActive(false);

        //spawner.StopCoroutine(spawner.WaveSpawn());
        spawner.gameObject.SetActive(false);
        spawner.Reset();

        if (ScoreManager.Instance.P1Score > ScoreManager.Instance.P2Score) ScoreManager.Instance.P1Wins += 1;
        else if (ScoreManager.Instance.P2Score > ScoreManager.Instance.P1Score) ScoreManager.Instance.P2Wins += 1;

        P1WinsText.text = "player One Wins: " + ScoreManager.Instance.P1Wins + "\n Score: " + ScoreManager.Instance.P1Score;
        P2WinsText.text = "player Two Wins: " + ScoreManager.Instance.P2Wins + "\n Score: " + ScoreManager.Instance.P2Score;

        endRoundMenu.SetActive(true);
        musicLoop.StopMusic();
        AudioManager.instance.PlayOneShot(gameDoneSound);
        Time.timeScale = 0f;
        
    }
}
