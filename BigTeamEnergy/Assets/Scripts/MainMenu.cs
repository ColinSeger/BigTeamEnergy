using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] RectTransform startB;
    [SerializeField] RectTransform creditsB;
    [SerializeField] RectTransform optionsB;
    [SerializeField] RectTransform exitB;
    [SerializeField] RectTransform moveTo;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject timeBut;
    [SerializeField] GameObject pointBut;
    [SerializeField] Sprite openBut;
    [SerializeField] Sprite closedBut;
    float movespeed = 5f;
    bool timeMode = true;
    [SerializeField] float activationDistance = 50f;

    public bool creditsMove = false;
    public bool optionsMove = false;

    Vector2 creditsOrigin;
    Vector2 optionsOrigin;
    private void Start()
    {
        creditsOrigin = creditsB.anchoredPosition;
        optionsOrigin = optionsB.anchoredPosition;
    }
    private void Update()
    {
        if (creditsMove && !optionsMove)
        {
            if (Vector2.Distance(creditsB.anchoredPosition, moveTo.anchoredPosition) > 0.05f)
            {
                creditsB.anchoredPosition = Vector2.Lerp(creditsB.anchoredPosition, moveTo.anchoredPosition, movespeed * Time.deltaTime);
            }
            if(Vector2.Distance(creditsB.anchoredPosition, moveTo.anchoredPosition) < activationDistance)
            {
                CreditsActive(creditsMove);
            }
        }
        else if (!creditsMove)
        {
            if (Vector2.Distance(creditsB.anchoredPosition, creditsOrigin) > 0.05f)
            {
                creditsB.anchoredPosition = Vector2.Lerp(creditsB.anchoredPosition, creditsOrigin, movespeed * Time.deltaTime);
            }
            if (Vector2.Distance(creditsB.anchoredPosition, moveTo.anchoredPosition) > activationDistance)

            {
                CreditsActive(creditsMove);
            }
        }

        if (optionsMove && !creditsMove)
        {
            if (Vector2.Distance(optionsB.anchoredPosition, moveTo.anchoredPosition) > 0.05f)
            {
                optionsB.anchoredPosition = Vector2.Lerp(optionsB.anchoredPosition, moveTo.anchoredPosition, movespeed * Time.deltaTime);
            }
            if (Vector2.Distance(optionsB.anchoredPosition, moveTo.anchoredPosition) < activationDistance)
            {
                OptionsActive(optionsMove);
            }
        }
        else if (!optionsMove)
        {
            if (Vector2.Distance(optionsB.anchoredPosition, optionsOrigin) > 0.05f)
            {
                optionsB.anchoredPosition = Vector2.Lerp(optionsB.anchoredPosition, optionsOrigin, movespeed * Time.deltaTime);
            }
            OptionsActive(optionsMove);
        }

    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionsButton()
    {
        optionsMove = !optionsMove;
    }
    public void CreditsButton()
    {
        creditsMove = !creditsMove;
    }
    public void Exitutton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    void CreditsActive(bool active)
    {
        if(active)
        {
            startB.gameObject.SetActive(false);
            optionsB.gameObject.SetActive(false);
            exitB.gameObject.SetActive(false);

            creditsPanel.SetActive(true);
        }

        else if (!active)
        {
            startB.gameObject.SetActive(true);
            optionsB.gameObject.SetActive(true);
            exitB.gameObject.SetActive(true);

            creditsPanel.SetActive(false);
        }
    }
    void OptionsActive(bool active)
    {
        if (active)
        {
            startB.gameObject.SetActive(false);
            creditsB.gameObject.SetActive(false);
            exitB.gameObject.SetActive(false);

            optionsPanel.SetActive(true);
        }

        else if (!active)
        {
            startB.gameObject.SetActive(true);
            creditsB.gameObject.SetActive(true);
            exitB.gameObject.SetActive(true);

            optionsPanel.SetActive(false);
        }
    }
    public void toggleGame()
    {
        timeMode = !timeMode;
        if (timeMode)
        {
            PlayerPrefs.SetInt("gameMode", 0);
            timeBut.GetComponent<Image>().sprite = closedBut;
            pointBut.GetComponent<Image>().sprite = openBut;
        }
        if (!timeMode)
        {
            PlayerPrefs.SetInt("gameMode", 1);
            timeBut.GetComponent<Image>().sprite = openBut;
            pointBut.GetComponent<Image>().sprite = closedBut;
        }

    }
}
