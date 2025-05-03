using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject[] groundPrefabs;
    public float groundSpeed = 5f;
    public int initialTiles = 6;
    public float tileWidth = 30f; // Manuel belirle: örneðin 10 birim

    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnX = 0f;
    public float cameraBuffer = 1f;

    void Start()
    {
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        GameObject firstTile = activeTiles[0];
        float spriteWidth = firstTile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float tileWidth = spriteWidth * firstTile.transform.localScale.x;

        if (firstTile.transform.position.x + tileWidth < -cameraBuffer)
        {
            DeleteOldestTile();
            SpawnTile();
        }


    }

    void SpawnTile()
    {
        GameObject prefab = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        GameObject tile = Instantiate(prefab);

        float spriteWidth = prefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float tileWidth = spriteWidth * prefab.transform.localScale.x;

        Vector3 spawnPos = new Vector3(spawnX, 0, 0);
        tile.transform.position = spawnPos;

        spawnX += tileWidth;
        activeTiles.Add(tile);
    }


    void DeleteOldestTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
