using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameOver gameOver;

    public GameObject player;

    public int energyCount = 0; // enerji sayýsýný tutacak
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

    public void CollectEnergy() // enerji sayýsýný artýrýr
    {
        energyCount++;
        Debug.Log("Enerji Toplandý: " + energyCount);

        if(energyCount >= energyGoal) // amaçlanan enerji seviyesine gelinip gelinmedigi kontrol ediliyior.
        {
            LevelCompleted(); // level tamamlandýgýnda calýstýrýlan method
        } 
    }
    public void LooseEnergy()
    {
        energyCount--;
        Debug.Log("Enerji kaybedildi: " + energyCount);
    }
    
    private void LevelCompleted() // level tamamlandýgýnda calýstýrýlan metho
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // bir sonraki index sýrasýndaki scene acýlýr.
    }

    public void GameOver()
    {
        gameOver.Setup(energyCount);
        player.SetActive(false);
    }
}
