using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public GameObject playButton;
    public GameObject quitButton;
    public GameObject settingsButton;
    public GameObject gameNameText;
     public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); // bir sonraki index'li sahne devreye girer.
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsGame()
    {
        settingsPanel.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        settingsButton.SetActive(false);
        gameNameText.SetActive(false);
        
    }

    public void BackToMainMenu()
    {
        settingsPanel.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        settingsButton.SetActive(true);
        gameNameText.SetActive(true);
    }
}
