using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // hareket etme hýzý

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // platform hareket ettirme

        if(transform.position.x < -20) // ekran disine ciktiginde sil
        {
            Destroy(gameObject);
        }
    }
}
