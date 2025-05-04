using UnityEngine;

public class TileCleaner : MonoBehaviour
{
public Transform player;  
    public float deleteDistance = 50f;  
    public float followDistance = 30f; 
    public float tileDeleteRadius = 5f;  

    private void Update()
    {
        if (player != null)
        {
       
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > deleteDistance)
            {
           
                Destroy(gameObject);
            }

          
            Vector3 targetPos = player.position - new Vector3(followDistance, 0, 0);
            transform.position = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        }

      
        DeleteTilesInRange();
    }

   
    private void DeleteTilesInRange()
    {
    
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("SpawnMapTile");

        foreach (GameObject tile in tiles)
        {
         
            float distance = Vector3.Distance(transform.position, tile.transform.position);

     
            if (distance < tileDeleteRadius)
            {
                Destroy(tile);  
                Debug.Log("Silindi: " + tile.name);
            }
        }
    }
}

