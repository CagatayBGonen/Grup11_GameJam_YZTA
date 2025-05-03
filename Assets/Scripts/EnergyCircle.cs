using UnityEngine;

public class EnergyCircle : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player ile carpisti");
            GameManager.Instance.CollectEnergy(); // GameManager scriptindeki CollectEnergy methodunu calistiriyoruz.
            Destroy(gameObject);
        }
    }

}
