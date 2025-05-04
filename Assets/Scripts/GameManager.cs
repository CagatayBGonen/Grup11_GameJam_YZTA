using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameOver gameOver;

    public GameObject player;

    public int energyCount = 0; // enerji say�s�n� tutacak
    public int energyGoal = 10; // toplam enerji limiti

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void CollectEnergy() // enerji say�s�n� art�r�r
    {
        energyCount++;
        Debug.Log("Enerji Topland�: " + energyCount);

        if(energyCount >= energyGoal) // ama�lanan enerji seviyesine gelinip gelinmedigi kontrol ediliyior.
        {
            LevelCompleted(); // level tamamland�g�nda cal�st�r�lan method
        } 
    }
    public void LooseEnergy()
    {
        energyCount--;
        Debug.Log("Enerji kaybedildi: " + energyCount);
    }
    
    private void LevelCompleted() // level tamamland�g�nda cal�st�r�lan metho
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // bir sonraki index s�ras�ndaki scene ac�l�r.
    }

    public void GameOver()
    {
        gameOver.Setup(energyCount);
        player.SetActive(false);
    }
}
