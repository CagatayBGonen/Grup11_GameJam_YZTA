using UnityEngine;

public class TileTrigger : MonoBehaviour
{
   private GroundSpawner groundSpawner;
    private bool hasTriggered = false;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            // groundSpawner hâlâ null'sa bulmaya çalış
            if (groundSpawner == null)
            {
                groundSpawner = FindObjectOfType<GroundSpawner>();

                if (groundSpawner == null)
                {
                    Debug.LogError("TileTrigger: GroundSpawner sahnede bulunamadı!");
                    return;
                }
            }

            hasTriggered = true;
            groundSpawner.SpawnTile();
        }
    }
}
