using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GroundSpawner groundSpawner; // Inspector’dan verilecek

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            groundSpawner.SpawnTile();
        }
    }
}
