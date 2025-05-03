using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // hareket etme hýzý

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // platform hareket ettirme
        //float deleteX = Camera.main.transform.position.x - 25f; // dinamik sinir.

        //if(transform.position.x < deleteX) // ekran disine ciktiginde sil
        //{
        //    Destroy(gameObject);
        //}
    }

}
