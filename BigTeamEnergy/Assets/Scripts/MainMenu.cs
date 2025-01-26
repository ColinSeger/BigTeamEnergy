using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] RectTransform startB;
    [SerializeField] RectTransform creditsB;
    [SerializeField] RectTransform optionsB;
    [SerializeField] RectTransform exitB;
    [SerializeField] RectTransform moveTo;
    float movespeed = 5f;

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
        }
        else if (!creditsMove)
        {
            if (Vector2.Distance(creditsB.anchoredPosition, creditsOrigin) > 0.05f)
            {
                creditsB.anchoredPosition = Vector2.Lerp(creditsB.anchoredPosition, creditsOrigin, movespeed * Time.deltaTime);
            }
        }

        if (optionsMove && !creditsMove)
        {
            if (Vector2.Distance(optionsB.anchoredPosition, moveTo.anchoredPosition) > 0.05f)
            {
                optionsB.anchoredPosition = Vector2.Lerp(optionsB.anchoredPosition, moveTo.anchoredPosition, movespeed * Time.deltaTime);
            }
        }
        else if (!optionsMove)
        {
            if (Vector2.Distance(optionsB.anchoredPosition, optionsOrigin) > 0.05f)
            {
                optionsB.anchoredPosition = Vector2.Lerp(optionsB.anchoredPosition, optionsOrigin, movespeed * Time.deltaTime);
            }
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
            
        }

        else if (!active)
        {

        }
    }
}
