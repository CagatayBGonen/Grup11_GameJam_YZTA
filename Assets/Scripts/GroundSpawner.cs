using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundPrefabs; // spawn olacak ground objeleri
    public Transform spawnPoint; // spawn olacaklari konum
    private float groundWidth = 20f; // prefab'in genisligi
    [SerializeField]
    private float groundSpawnTime = 2f;
    private float timeUntilNextSpawn;

    

    private void Update()
    {
        SpawnGround();
    }

    private void SpawnGround() // ground spawn ediyor.
    {
        timeUntilNextSpawn += Time.deltaTime; 
        if(timeUntilNextSpawn >= groundSpawnTime) // belirledigimiz zamanýn gelip gelmedigini kontrol ediyor.
        {
            Spawn(groundPrefabs); // ground prefablerini spawn ettiriyoruz.
            timeUntilNextSpawn = 0f; // timer'i sifirliyoruz.
        }
        
    }
    private void Spawn(GameObject[] prefabsObj) // listeden obje spawn ediyor
    {
        GameObject ObjectToSpawn = prefabsObj[Random.Range(0, prefabsObj.Length)];
        GameObject spawnedObject = Instantiate(ObjectToSpawn, spawnPoint.position, Quaternion.identity);
       
    }
}
