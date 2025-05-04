using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
public List<GameObject> groundPrefabs; // Platform prefabları (0: sabit başlangıç)
    public int initialTiles = 3; // Oyunun başında kaç tane tile spawn edilecek
    private Transform lastSpawnPoint;

    void Start()
    {
        // İlk sabit platformu yerleştir
        GameObject firstTile = Instantiate(groundPrefabs[0], Vector3.zero, Quaternion.identity);
        lastSpawnPoint = firstTile.transform.Find("NextSpawnPoint");

        if (lastSpawnPoint == null)
        {
            Debug.LogError("İlk prefab içinde 'NextSpawnPoint' yok!");
            return;
        }

        // Geri kalan başlangıç platformlarını rastgele yerleştir
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
            Debug.LogError("Yeni prefab içinde 'NextSpawnPoint' eksik!");
        }
    }

    GameObject GetRandomPrefab()
    {
        // İlk prefab (index 0) sabit başlangıç olduğu için 1'den başlıyoruz
        int index = Random.Range(1, groundPrefabs.Count);
        return groundPrefabs[index];
    }

}
