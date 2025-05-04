using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
 public List<GameObject> groundPrefabs; // 5 farklı platform prefabı
    public int initialTiles = 3; // Oyunun başında kaç tane tile spawn edilecek
    private Transform lastSpawnPoint;

    void Start()
    {
        // İlk prefabı sahneye koy, bu önemli çünkü ilk pozisyonu referans alacağız
        GameObject firstTile = Instantiate(GetRandomPrefab(), Vector3.zero, Quaternion.identity);
        lastSpawnPoint = firstTile.transform.Find("NextSpawnPoint");

        // Diğer başlangıç tile'larını spawnla
        for (int i = 0; i < initialTiles - 1; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject prefabToSpawn = GetRandomPrefab();
        GameObject newTile = Instantiate(prefabToSpawn, lastSpawnPoint.position, Quaternion.identity);
        lastSpawnPoint = newTile.transform.Find("NextSpawnPoint");

        if (lastSpawnPoint == null)
        {
            Debug.LogError("NextSpawnPoint bulunamadı! Prefab içindeki 'NextSpawnPoint' boşluğu eksik olabilir.");
        }
    }

    GameObject GetRandomPrefab()
    {
        int index = Random.Range(0, groundPrefabs.Count);
        return groundPrefabs[index];
    }

}
