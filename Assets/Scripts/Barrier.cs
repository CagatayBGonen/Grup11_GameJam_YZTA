using UnityEngine;

public class Barrier : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Oyuncu Barriere carpti");
    //        GameManager.Instance.LooseEnergy();
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
            //Destroy(gameObject);
        }
    }
}
