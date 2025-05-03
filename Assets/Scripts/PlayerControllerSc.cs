using UnityEngine;

public class PlayerControllerSc : MonoBehaviour
{
    public float jumpForce = 7f; // Karakter zıplama gücü
    private Rigidbody2D rb;
    private Animator animator; // Animator bileşeni
    private bool isGrounded = true;  // Karakterin zeminle temas edip etmediğini kontrol etmek için

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Zıplama hareketi
            isGrounded = false;

            if (animator != null)
                animator.SetTrigger("isJumping"); // Zıplama animasyonu tetikle
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if (animator != null)
                animator.SetBool("isJumping", false); // Zıplama animasyonunu kapat
        }
    }
}
