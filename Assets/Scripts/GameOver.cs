using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public AudioClip hoverSound; // Ses dosyasını buraya at
    private AudioSource audioSource;
    public TextMeshProUGUI energyCountText;

void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayHoverSound()
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }
    public void Setup(int energyCount)
    {
        gameObject.SetActive(true);
        energyCountText.text = energyCount.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenuButton()
    {
        SceneManager.LoadScene("GameMenu");

    }
}
