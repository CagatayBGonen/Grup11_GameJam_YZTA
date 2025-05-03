using UnityEngine;

public class EnergyCircle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("player ile carpisti");
            GameManager.Instance.CollectEnergy(); // GameManager scriptindeki CollectEnergy methodunu calistiriyoruz.
            Destroy(gameObject);
        }
        
    }

}
