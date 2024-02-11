using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [Header("                            Панели")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winMenu;

    private void Start()
    {
        Time.timeScale = 1;

        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseOpen() 
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);        
    }

    public void PauseClose() 
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();

        Debug.Log("Опа, вышли...");
    }
}
