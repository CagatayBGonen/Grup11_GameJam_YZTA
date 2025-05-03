using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyuncu Barriere carpti");
            GameManager.Instance.LooseEnergy();
            Destroy(gameObject);
        }
    }
}
