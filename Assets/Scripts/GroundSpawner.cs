using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
public GameObject tilePrefab; // GroundTile prefab
    public int initialTiles = 2; // Başlangıçta kaç tane tile spawnlansın
    private Transform lastSpawnPoint;

    void Start()
    {
        // İlk platformu koy
        GameObject firstTile = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
        lastSpawnPoint = firstTile.transform.Find("NextSpawnPoint");

        // İlk başta birkaç tile diz
        for (int i = 0; i < initialTiles - 1; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject newTile = Instantiate(tilePrefab, lastSpawnPoint.position, Quaternion.identity);
        lastSpawnPoint = newTile.transform.Find("NextSpawnPoint");
    }

}
