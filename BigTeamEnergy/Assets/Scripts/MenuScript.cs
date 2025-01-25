using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject menu;
    bool isPaused = false;
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Time.timeScale = 1f;
                menu.SetActive(false);
                isPaused = false;
            }else{
                Time.timeScale = 0;
                menu.SetActive(true);
                isPaused = true;
            }
        }
    }
    public void ReturnToMainMenu(){
        SceneManager.LoadScene("Main Manu");
    }
    public void ExitGame(){
        Application.Quit();
    }
}
