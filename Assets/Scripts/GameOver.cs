using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI energyCountText;

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
