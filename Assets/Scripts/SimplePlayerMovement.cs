using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

}
