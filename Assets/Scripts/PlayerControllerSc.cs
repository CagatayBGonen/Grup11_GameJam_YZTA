using UnityEngine;

public class PlayerControllerSc : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = true;
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Animator varsa al, yoksa hata vermez
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;

            if (animator != null)
                animator.SetTrigger("Jump");
        }

        if (animator != null)
            animator.SetBool("IsRunning", isGrounded); // örnek koşma animasyonu kontrolü
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // basit zemin kontrolü
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if (animator != null)
                animator.SetTrigger("Land");
        }
    }
}
