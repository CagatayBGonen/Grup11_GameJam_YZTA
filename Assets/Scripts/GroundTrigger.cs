using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    GroundSpawner groundSpawner = new GroundSpawner();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTrigger"))
        {
            
        }
    }
}
