using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject storyPanel;
    public GameObject creditsPanel;

    public GameObject playButton;
    public GameObject quitButton;
    public GameObject creditsButton;
    public GameObject tutorialButton;
    public GameObject storyButton;
    public GameObject gameNameText;
    public GameObject gameNameText2;

    public AudioClip hoverSound; // Ses dosyasını buraya at
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Bu fonksiyon UI butonlarına atanabilir
    public void PlayHoverSound()
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CreditsGame()
    {
        HideMainMenuUI();
        creditsPanel.SetActive(true);
    }

    public void TutorialGame()
    {
        HideMainMenuUI();
        tutorialPanel.SetActive(true);
    }

    public void StoryGame()
    {
        HideMainMenuUI();
        storyPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        tutorialButton.SetActive(true);
        storyButton.SetActive(true);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        creditsButton.SetActive(true);
        gameNameText.SetActive(true);
        gameNameText2.SetActive(true);

        tutorialPanel.SetActive(false);
        storyPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    private void HideMainMenuUI()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        storyButton.SetActive(false);
        gameNameText.SetActive(false);
        gameNameText2.SetActive(false);
        creditsButton.SetActive(false);
        tutorialButton.SetActive(false);
    }
}
