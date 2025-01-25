using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene(2);
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene(3);
    }
    public void Exitutton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
